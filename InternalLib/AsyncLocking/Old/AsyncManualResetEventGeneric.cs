#if true
using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;

namespace QLib.AsyncLocking.Old;

/// <summary>
/// A flavor of <see cref="ManualResetEvent"/> that can be asynchronously awaited on.
/// </summary>
public class AsyncManualResetEvent<T>
{
    /// <summary>
    /// Whether the task completion source should allow executing continuations synchronously.
    /// </summary>
    private readonly bool allowInliningAwaiters;
    private TaskCreationOptions AllowInliningAwaitersFlag => allowInliningAwaiters ? TaskCreationOptions.RunContinuationsAsynchronously : TaskCreationOptions.None;

    /// <summary>
    /// The object to lock when accessing fields.
    /// </summary>
    private readonly object syncObject = new();

    /// <summary>
    /// The source of the task to return from <see cref="WaitAsync()"/>.
    /// </summary>
    /// <devremarks>
    /// This should not need the volatile modifier because it is
    /// always accessed within a lock.
    /// </devremarks>
    private TaskCompletionSource<T> taskCompletionSource;

    /// <summary>
    /// A flag indicating whether the event is signaled.
    /// When this is set to true, it's possible that
    /// <see cref="taskCompletionSource"/>.Task.IsCompleted is still false
    /// if the completion has been scheduled asynchronously.
    /// Thus, this field should be the definitive answer as to whether
    /// the event is signaled because it is synchronously updated.
    /// </summary>
    /// <devremarks>
    /// This should not need the volatile modifier because it is
    /// always accessed within a lock.
    /// </devremarks>
    private bool isSet;
    private T? value;

    public AsyncManualResetEvent(bool allowInliningAwaiters = false) : this(initialValue: default!, initialState: false, allowInliningAwaiters: allowInliningAwaiters) { }
    public AsyncManualResetEvent(T initialValue, bool allowInliningAwaiters = false) : this(initialValue: initialValue, initialState: true, allowInliningAwaiters: allowInliningAwaiters) { }
    /// <summary>
    /// Initializes a new instance of the <see cref="AsyncManualResetEvent"/> class.
    /// </summary>
    /// <param name="initialState">A value indicating whether the event should be initially signaled.</param>
    /// <param name="allowInliningAwaiters">
    /// A value indicating whether to allow <see cref="WaitAsync()"/> callers' continuations to execute
    /// on the thread that calls <see cref="SetAsync()"/> before the call returns.
    /// <see cref="SetAsync()"/> callers should not hold private locks if this value is <see langword="true" /> to avoid deadlocks.
    /// When <see langword="false" />, the task returned from <see cref="WaitAsync()"/> may not have fully transitioned to
    /// its completed state by the time <see cref="SetAsync()"/> returns to its caller.
    /// </param>
    private AsyncManualResetEvent(T? initialValue = default, bool initialState = false, bool allowInliningAwaiters = false)
    {
        this.allowInliningAwaiters = allowInliningAwaiters;

        taskCompletionSource = CreateTaskSource();
        isSet = initialState;
        if (initialState)
            taskCompletionSource.SetResult(initialValue!);
        else
            ArgumentNullException.ThrowIfNull(initialValue);
    }

    /// <summary>
    /// Gets a value indicating whether the event is currently in a signaled state.
    /// </summary>
    public bool IsSet
    {
        get
        {
            lock (syncObject)
            {
                return isSet;
            }
        }
    }

    /// <summary>
    /// Returns a task that will be completed when this event is set.
    /// </summary>
    public ValueTask<T> WaitAsync() => WaitAsync(CancellationToken.None);

    /// <summary>
    /// Returns a task that will be completed when this event is set.
    /// </summary>
    /// <param name="cancellationToken">A cancellation token.</param>
    /// <returns>A task that completes when the event is set, or cancels with the <paramref name="cancellationToken"/>.</returns>
    public ValueTask<T> WaitAsync(CancellationToken cancellationToken)
    {
        Task<T> task;
        lock (syncObject)
        {
            if (isSet)
            {
#if DEBUG
                Debug.Assert(value != null);
#endif
                return ValueTask.FromResult(value!);
            }
            task = taskCompletionSource.Task;
        }
#if NoCancelCheck
        return new(task.WaitAsync(cancellationToken));
#else
        return new(cancellationToken.CanBeCanceled ? task.WaitAsync(cancellationToken) : task);
#endif
    }
    /// <summary>
    /// Sets this event to unblock callers of <see cref="WaitAsync()"/>.
    /// </summary>
    public void Set(T value)
    {
        TaskCompletionSource<T> previousTCS;
        bool transitionRequired;// = false;
        lock (syncObject)
        {
            transitionRequired = !isSet;
            previousTCS = taskCompletionSource;
            this.value = value;
            isSet = true;
        }
        Debug.Assert(previousTCS != null);

        if (transitionRequired)
            previousTCS.TrySetResult(value);
    }

    /// <summary>
    /// Resets this event to a state that will block callers of <see cref="WaitAsync()"/>.
    /// </summary>
    public void Reset()
    {
        lock (syncObject)
        {
            if (isSet)
            {
                taskCompletionSource = CreateTaskSource();
                value = default;
                isSet = false;
            }
        }
    }

    /// <summary>
    /// Sets and immediately resets this event, allowing all current waiters to unblock.
    /// </summary>
    /// <returns>A task that completes when the signal has been set.</returns>
    public void PulseAll(T value)
    {
        TaskCompletionSource<T> previousTCS;
        lock (syncObject)
        {
            // Atomically replace the completion source with a new, uncompleted source
            // while capturing the previous one so we can complete it.
            // This ensures that we don't leave a gap in time where WaitAsync() will
            // continue to return completed Tasks due to a Pulse method which should
            // execute instantaneously.
            previousTCS = taskCompletionSource;
            taskCompletionSource = CreateTaskSource();
            isSet = false;
        }

        previousTCS.TrySetResult(value);
    }

    /// <summary>
    /// Gets an awaiter that completes when this event is signaled.
    /// </summary>
    [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Reliability", "CA2012:Use ValueTasks correctly", Justification = "<Pending>")]
    public ValueTaskAwaiter<T> GetAwaiter() => WaitAsync().GetAwaiter();

    /// <summary>
    /// Creates a new TaskCompletionSource to represent an unset event.
    /// </summary>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private TaskCompletionSource<T> CreateTaskSource() => new(AllowInliningAwaitersFlag);

    public override string ToString()
    {
        bool isSet = TryGetValueNow(out T value);
        string valueString = isSet ? value?.ToString() ?? "<null>" : "NotAvailable";
        return $"Signaled: {isSet}, Value: {valueString}";
    }

    public bool TryGetValueNow(out T value)
    {
        bool isSet;
        T? tempValue;
        lock (syncObject)
        {
            isSet = this.isSet;
            tempValue = this.value;
        }
        if (isSet)
        {
            value = tempValue!;
            return true;
        }
        else
        {
            value = default!;
            return false;
        }
    }
}
#endif
using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;

namespace QLib.AsyncLocking.Old;

/// <summary>
/// A flavor of <see cref="ManualResetEvent"/> that can be asynchronously awaited on.
/// </summary>
#if !WrappedCore
[DebuggerDisplay("Signaled: {IsSet}")]
#endif
public class AsyncManualResetEvent
{
#if WrappedCore
    /// <summary>
    /// Whether the task completion source should allow executing continuations synchronously.
    /// </summary>
    private readonly AsyncManualResetEvent<byte> core;

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
    public AsyncManualResetEvent(bool initialState = false, bool allowInliningAwaiters = false)
    {
        if (initialState)
            core = new(default, allowInliningAwaiters: allowInliningAwaiters);
        else
            core = new(allowInliningAwaiters);
    }

    /// <summary>
    /// Gets a value indicating whether the event is currently in a signaled state.
    /// </summary>
    public bool IsSet => core.IsSet;

    /// <summary>
    /// Returns a task that will be completed when this event is set.
    /// </summary>
    public ValueTask WaitAsync() => core.WaitAsync().AsValueTask();

    /// <summary>
    /// Returns a task that will be completed when this event is set.
    /// </summary>
    /// <param name="cancellationToken">A cancellation token.</param>
    /// <returns>A task that completes when the event is set, or cancels with the <paramref name="cancellationToken"/>.</returns>
    public ValueTask WaitAsync(CancellationToken cancellationToken) => core.WaitAsync(cancellationToken).AsValueTask();

    /// <summary>
    /// Sets this event to unblock callers of <see cref="WaitAsync()"/>.
    /// </summary>
    public void Set() => core.Set(default);

    /// <summary>
    /// Resets this event to a state that will block callers of <see cref="WaitAsync()"/>.
    /// </summary>
    public void Reset() => core.Reset();

    /// <summary>
    /// Sets and immediately resets this event, allowing all current waiters to unblock.
    /// </summary>
    /// <returns>A task that completes when the signal has been set.</returns>
    public void PulseAll() => core.PulseAll(default);

    /// <summary>
    /// Gets an awaiter that completes when this event is signaled.
    /// </summary>
    [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
    public ValueTaskAwaiter GetAwaiter() => WaitAsync().GetAwaiter();

#else
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
    private TaskCompletionSource taskCompletionSource;

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
    public AsyncManualResetEvent(bool initialState = false, bool allowInliningAwaiters = false)
    {
        this.allowInliningAwaiters = allowInliningAwaiters;

        taskCompletionSource = CreateTaskSource();
        isSet = initialState;
        if (initialState)
            taskCompletionSource.SetResult();
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
    public ValueTask WaitAsync() => WaitAsync(CancellationToken.None);

    /// <summary>
    /// Returns a task that will be completed when this event is set.
    /// </summary>
    /// <param name="cancellationToken">A cancellation token.</param>
    /// <returns>A task that completes when the event is set, or cancels with the <paramref name="cancellationToken"/>.</returns>
    public ValueTask WaitAsync(CancellationToken cancellationToken)
    {
        Task task;
        lock (syncObject)
        {
            if (isSet)
                return ValueTask.CompletedTask;
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
    public void Set()
    {
        TaskCompletionSource previousTCS;
        bool transitionRequired;// = false;
        lock (syncObject)
        {
            transitionRequired = !isSet;
            previousTCS = taskCompletionSource;
            isSet = true;
        }
        Debug.Assert(previousTCS != null);

        if (transitionRequired)
            previousTCS.TrySetResult();
    }
    //TODO: is this right?
    public void Set(Exception ex)
    {
        lock (syncObject)
        {
            taskCompletionSource.SetException(ex);
            isSet = true;
        }
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
                isSet = false;
            }
        }
    }

    /// <summary>
    /// Sets and immediately resets this event, allowing all current waiters to unblock.
    /// </summary>
    /// <returns>A task that completes when the signal has been set.</returns>
    public void PulseAll()
    {
        TaskCompletionSource previousTCS;
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

        previousTCS.TrySetResult();
    }

    /// <summary>
    /// Gets an awaiter that completes when this event is signaled.
    /// </summary>
    [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Reliability", "CA2012:Use ValueTasks correctly", Justification = "<Pending>")]
    public ValueTaskAwaiter GetAwaiter() => WaitAsync().GetAwaiter();

    /// <summary>
    /// Creates a new TaskCompletionSource to represent an unset event.
    /// </summary>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private TaskCompletionSource CreateTaskSource() => new(AllowInliningAwaitersFlag);
#endif
}

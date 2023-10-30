#if false
#define AsyncManualResetEventWithValue
using System;
#if AsyncManualResetEventWithValue
using System.Diagnostics.CodeAnalysis;
#endif
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

namespace DSharpPlus.BetterHosting.Services.Implementation.temp;

internal sealed partial class AsyncManualResetEvent<T>
{
    private readonly ILogger<AsyncManualResetEvent<T>>? logger;

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
    private LockState state;

    public enum LockState
    {
        UnsetClosed,
        SetOpen,
        Failed,
        Cancelled
    }

    /// <summary>
    /// Gets a value indicating whether the event is currently in a signaled state.
    /// </summary>
    [MemberNotNullWhen(true, nameof(value))] //@@AsyncManualResetEventWithValue@@
    public bool IsCompletedSuccessfully
    {
        get
        {
            lock (syncObject)
                return PreLockedIsCompletedSuccessfully;
        }
    }
    [MemberNotNullWhen(true, nameof(value))] //@@AsyncManualResetEventWithValue@@
    private bool PreLockedIsCompletedSuccessfully
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => state == LockState.SetOpen;
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="AsyncManualResetEvent{T}"/> class.
    /// </summary>
    /// <param name="allowInliningAwaiters">
    /// A value indicating whether to allow <see cref="WaitAsync()"/> callers' continuations to execute
    /// on the thread that calls <see cref="SetAsync()"/> before the call returns.
    /// <see cref="SetAsync()"/> callers should not hold private locks if this value is <see langword="true" /> to avoid deadlocks.
    /// When <see langword="false" />, the task returned from <see cref="WaitAsync()"/> may not have fully transitioned to
    /// its completed state by the time <see cref="SetAsync()"/> returns to its caller.
    /// </param>
    public AsyncManualResetEvent(bool allowInliningAwaiters = false, ILogger<AsyncManualResetEvent<T>> logger = null!)
    {
        this.logger = logger;
        this.allowInliningAwaiters = allowInliningAwaiters;
        taskCompletionSource = CreateTaskSource();
        state = LockState.UnsetClosed;
    }

#if AsyncManualResetEventWithValue
    /// <param name="initialValue">A value indicating whether the event should be initially signaled.</param>
    /// <inheritdoc cref="AsyncManualResetEvent{T}(bool, ILogger{AsyncManualResetEvent{T}})"/>
    public AsyncManualResetEvent(T initialValue, bool allowInliningAwaiters = false, ILogger<AsyncManualResetEvent<T>> logger = null!) : this(allowInliningAwaiters, logger)
    {
        state = LockState.SetOpen;
        taskCompletionSource.SetResult(initialValue);
    }
#endif

    /// <inheritdoc cref="AsyncManualResetEvent{T}(bool, ILogger{AsyncManualResetEvent{T}})"/>
    public AsyncManualResetEvent(Exception exception, bool allowInliningAwaiters = false, ILogger<AsyncManualResetEvent<T>> logger = null!) : this(allowInliningAwaiters, logger)
    {
        state = LockState.Failed;
        taskCompletionSource.SetException(exception);
    }
    /// <inheritdoc cref="AsyncManualResetEvent{T}(bool, ILogger{AsyncManualResetEvent{T}})"/>
    public AsyncManualResetEvent(CancellationToken cancellationReason, bool allowInliningAwaiters = false, ILogger<AsyncManualResetEvent<T>> logger = null!) : this(allowInliningAwaiters, logger)
    {
        state = LockState.Failed;
        taskCompletionSource.SetCanceled(cancellationReason);
    }

    /// <summary>
    /// Resets this event to a state that will block callers of <see cref="WaitAsync()"/>.
    /// </summary>
    public void Reset()
    {
        TaskCompletionSource<T>? prevTCS = null;
        lock (syncObject)
        {
            if (state != LockState.UnsetClosed)
            {
                prevTCS= taskCompletionSource;
                taskCompletionSource = CreateTaskSource();
                state = LockState.UnsetClosed;
            }
        }

        prevTCS?.TrySetCanceled();
    }

    public void SetCancelled(CancellationToken reason) => SetCore(LockState.Cancelled, tcs => tcs.TrySetCanceled(reason));
    public void SetFailed(Exception exception) => SetCore(LockState.Failed, tcs => tcs.TrySetException(exception));
    private void SetCore(LockState newState, Func<TaskCompletionSource<T>, bool> transition)
    {
        logger?.LogInformation("Moving barrier to {newState}", newState);
        LockState prevState;
        TaskCompletionSource<T> tcs;
        lock (syncObject)
        {
            if (state == LockState.SetOpen)
                throw new InvalidOperationException("Lock already opened");

            prevState = state;
            tcs = taskCompletionSource;
            value = default!;
            state = newState;
        }

        if (newState == prevState)
        {
            logger?.LogTrace("No work needed, new state is the same as current!");
        }
        else
        {
            bool setOpen = transition(tcs);
            if (!setOpen)
                logger?.LogWarning("Tried to set barrier to {state}, but failed to", newState);
        }
    }

    /// <summary>
    /// Returns a task that will be completed when this event is set.
    /// </summary>
    public ValueTask<T> WaitAsync()
    {
        Task<T> task;
        lock (syncObject)
        {
            if (PreLockedIsCompletedSuccessfully)
                return ValueTask.FromResult(value);
            task = taskCompletionSource.Task;
        }
        return new(task);
    }

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
            if (PreLockedIsCompletedSuccessfully)
                return ValueTask.FromResult(value!);
            task = taskCompletionSource.Task;
        }
        return new(task.WaitAsync(cancellationToken));
    }

    /// <summary>
    /// Gets an awaiter that completes when this event is signaled.
    /// </summary>
    [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
    public ValueTaskAwaiter<T> GetAwaiter() => WaitAsync().GetAwaiter();

    /// <summary>
    /// Creates a new TaskCompletionSource<T> to represent an unset event.
    /// </summary>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private TaskCompletionSource<T> CreateTaskSource() => new(AllowInliningAwaitersFlag);
}
#endif
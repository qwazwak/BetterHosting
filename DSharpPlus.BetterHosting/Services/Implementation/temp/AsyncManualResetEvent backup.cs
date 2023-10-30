#if false
using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;
using DSharpPlus.BetterHosting.Services.Interfaces;
using Microsoft.Extensions.Logging;


namespace DSharpPlus.BetterHosting.Services.Implementation.temp;

internal sealed class AsyncManualResetEvent
{
    private readonly ILogger<AsyncManualResetEvent>? logger;

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
    //private bool isSet;
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
    public bool IsCompletedSuccessfully
    {
        get
        {
            lock (syncObject)
                return PreLockedIsCompletedSuccessfully;
        }
    }
    private bool PreLockedIsCompletedSuccessfully
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => state == LockState.SetOpen;
    }

    public bool IsFailed
    {
        get
        {
            lock (syncObject)
            {
                bool isFailed = state == LockState.Failed;
                Debug.Assert(isFailed == (exception == null));
                Debug.Assert(isFailed != (cancellationReason == null));
                return isFailed;
            }
        }
    }

    private Exception? exception;
    private CancellationToken? cancellationReason;

    /// <summary>
    /// Initializes a new instance of the <see cref="AsyncManualResetEvent"/> class.
    /// </summary>
    /// <param name="allowInliningAwaiters">
    /// A value indicating whether to allow <see cref="WaitAsync()"/> callers' continuations to execute
    /// on the thread that calls <see cref="SetAsync()"/> before the call returns.
    /// <see cref="SetAsync()"/> callers should not hold private locks if this value is <see langword="true" /> to avoid deadlocks.
    /// When <see langword="false" />, the task returned from <see cref="WaitAsync()"/> may not have fully transitioned to
    /// its completed state by the time <see cref="SetAsync()"/> returns to its caller.
    /// </param>
    public AsyncManualResetEvent(bool allowInliningAwaiters = false, ILogger<AsyncManualResetEvent> logger = null!)
    {
        this.logger = logger;
        this.allowInliningAwaiters = allowInliningAwaiters;
        taskCompletionSource = CreateTaskSource();
        state = LockState.UnsetClosed;
    }
    /// <param name="initialState">A value indicating whether the event should be initially signaled.</param>
    /// <inheritdoc cref="AsyncManualResetEvent(bool, ILogger{AsyncManualResetEvent})"/>
    public AsyncManualResetEvent(bool initialState, bool allowInliningAwaiters = false, ILogger<AsyncManualResetEvent> logger = null!) : this(allowInliningAwaiters, logger)
    {
        if (initialState)
        {
            state = LockState.SetOpen;
            taskCompletionSource.SetResult();
        }
    }
    /// <inheritdoc cref="AsyncManualResetEvent(bool, ILogger{AsyncManualResetEvent})"/>
    public AsyncManualResetEvent(Exception exception, bool allowInliningAwaiters = false, ILogger<AsyncManualResetEvent> logger = null!) : this(allowInliningAwaiters, logger)
    {
        state = LockState.Failed;
        this.exception = exception;
        taskCompletionSource.SetException(exception);
    }
    /// <inheritdoc cref="AsyncManualResetEvent(bool, ILogger{AsyncManualResetEvent})"/>
    public AsyncManualResetEvent(CancellationToken cancellationReason, bool allowInliningAwaiters = false, ILogger<AsyncManualResetEvent> logger = null!) : this(allowInliningAwaiters, logger)
    {
        state = LockState.Failed;
        this.cancellationReason = cancellationReason;
        taskCompletionSource.SetCanceled(cancellationReason);
    }

    /// <summary>
    /// Sets this event to unblock callers of <see cref="WaitAsync()"/>.
    /// </summary>
    public void SetOpen()
    {
        logger?.LogInformation("Opening barrier");
        TaskCompletionSource previousTCS;
        LockState prevState;
        lock (syncObject)
        {
            prevState = state;
            previousTCS = taskCompletionSource;
            state = LockState.SetOpen;
            exception = null;
            cancellationReason = null;
        }
        if (LockState.SetOpen == prevState)
        {
            logger?.LogTrace("No work needed, new state is the same as current!");
        }
        else
        {
            bool setOpen = previousTCS.TrySetResult();
            if (!setOpen)
                logger?.LogWarning("Tried to set barrier to open, but failed to");
        }
    }

    /// <summary>
    /// Sets and immediately resets this event, allowing all current waiters to unblock.
    /// </summary>
    /// <returns>A task that completes when the signal has been set.</returns>
    public void PulseAll()
    {
        TaskCompletionSource previousTCS = PulseAllCore();

        bool setOpen = previousTCS.TrySetResult();
        if (!setOpen)
            logger?.LogWarning("Tried to set barrier to open, but failed to");
    }

    /// <summary>
    /// Resets this event to a state that will block callers of <see cref="WaitAsync()"/>.
    /// </summary>
    public void Reset()
    {
        TaskCompletionSource? prevTCS = null;
        lock (syncObject)
        {
            if (state != LockState.UnsetClosed)
            {
                prevTCS= taskCompletionSource;
                taskCompletionSource = CreateTaskSource();
                state = LockState.UnsetClosed;
                exception = null;
                cancellationReason = null;
            }
        }

        prevTCS?.TrySetCanceled();
    }

    public void SetCancelled(CancellationToken reason)
    {
        logger?.LogInformation("Marking barrier as cancelled");
        LockState prevState;
        TaskCompletionSource tcs;
        lock (syncObject)
        {
            prevState = state;
            tcs = taskCompletionSource;
            exception = null;
            cancellationReason = reason;
            state = LockState.Cancelled;
        }
        if (LockState.Failed == prevState)
        {
            logger?.LogTrace("No work needed, new state is the same as current!");
        }
        else
        {
            bool setOpen = tcs.TrySetCanceled(reason);
            if (!setOpen)
                logger?.LogWarning("Tried to set barrier to open, but failed to");
        }
    }
    public void PulseAll(CancellationToken reason)
    {
        TaskCompletionSource previousTCS = PulseAllCore();

        bool setOpen = previousTCS.TrySetCanceled(reason);
        if (!setOpen)
            logger?.LogWarning("Tried to set barrier to canceled, but failed to");
    }

    public void SetFailed(Exception exception)
    {
        logger?.LogInformation("Marking barrier as failed, reason: {message}", exception.Message);
        LockState prevState;
        TaskCompletionSource tcs;
        lock (syncObject)
        {
            prevState = state;
            tcs = taskCompletionSource;
            this.exception = exception;
            cancellationReason = null;
            state = LockState.Failed;
        }
        if (LockState.Failed == prevState)
        {
            logger?.LogTrace("No work needed, new state is the same as current!");
        }
        else
        {
            bool setOpen = tcs.TrySetException(exception);
            if (!setOpen)
                logger?.LogWarning("Tried to set barrier to open, but failed to");
        }
    }
    public void PulseAll(Exception exception)
    {
        TaskCompletionSource previousTCS = PulseAllCore();

        bool setOpen = previousTCS.TrySetException(exception);
        if (!setOpen)
            logger?.LogWarning("Tried to set barrier to exception ({message}), but failed to", exception.Message);
    }

    private TaskCompletionSource PulseAllCore()
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
            exception = null;
            cancellationReason = null;
            state = LockState.UnsetClosed;
        }
        return previousTCS;
    }
    private void SetTemplate(LockState newState, Exception? exception, CancellationToken? cancellationReason)
    {
        Debug.Assert(newState != LockState.UnsetClosed, "state not supported by this method");
#if DEBUG
        switch (newState)
        {
            case LockState.SetOpen:
                Debug.Assert(exception == null);
                Debug.Assert(cancellationReason == null);
                break;
            case LockState.Failed:
                Debug.Assert(exception != null);
                Debug.Assert(cancellationReason == null);
                break;
            case LockState.Cancelled:
                Debug.Assert(exception == null);
                Debug.Assert(cancellationReason != null);
                break;
            default:
                Debug.Fail("Not a valid state");
                break;
        }
#endif
        LockState prevState;
        TaskCompletionSource tcs;
        lock (syncObject)
        {
            prevState = state;
            tcs = taskCompletionSource;
            this.exception = exception;
            this.cancellationReason = cancellationReason;
            state = newState;
        }
        if (newState == prevState)
        {
            logger?.LogTrace("No work needed, new state is the same as previous");
            return;
        }

        bool transitionSuccess = newState switch
        {
            LockState.SetOpen => tcs.TrySetResult(),
            LockState.Failed => tcs.TrySetException(exception!),
            LockState.Cancelled => tcs.TrySetCanceled(cancellationReason!.Value),
            _ => throw new InvalidOperationException("Not a valid state"),
        };

        if (!transitionSuccess)
            logger?.LogWarning("Tried to transition barrier from {prev} to {new}, but failed to", prevState, newState);
    }

    private readonly struct DefaultBarrier(BarrierManager3 parent) : IBarrier
    {
        private readonly BarrierManager3 parent = parent;
        public readonly ValueTask WaitForBarrier => parent.WaitAsync();
    }
    private class DefaultSingletonBarrier(BarrierManager3 parent) : IBarrier
    {
        private readonly BarrierManager3 parent = parent;
        public ValueTask WaitForBarrier => parent.WaitAsync();
    }
    private readonly struct OpenBarrier : IBarrier
    {
        public readonly ValueTask WaitForBarrier => ValueTask.CompletedTask;
    }

    /// <summary>
    /// Returns a task that will be completed when this event is set.
    /// </summary>
    public ValueTask WaitAsync()
    {
        Task task;
        lock (syncObject)
        {
            if (PreLockedIsCompletedSuccessfully)
                return ValueTask.CompletedTask;
            task = taskCompletionSource.Task;
        }
        return new(task);
    }

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
            if (PreLockedIsCompletedSuccessfully)
                return ValueTask.CompletedTask;
            task = taskCompletionSource.Task;
        }
        return new(task.WaitAsync(cancellationToken));
    }

    /// <summary>
    /// Gets an awaiter that completes when this event is signaled.
    /// </summary>
    [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
    public ValueTaskAwaiter GetAwaiter() => WaitAsync().GetAwaiter();

    /// <summary>
    /// Creates a new TaskCompletionSource to represent an unset event.
    /// </summary>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private TaskCompletionSource CreateTaskSource() => new(AllowInliningAwaitersFlag);
}
#endif
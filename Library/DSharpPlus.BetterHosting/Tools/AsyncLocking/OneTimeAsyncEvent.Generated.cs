#define AsyncManualResetEventWithNoValue
#nullable enable
#if !AsyncManualResetEventWithNoValue
#define AsyncManualResetEventWithValue
#endif
using Microsoft.Extensions.Logging;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Threading;
using System;

namespace DSharpPlus.BetterHosting.Tools.AsyncEventBlock;

/// <summary>
/// A flavor of <see cref="ManualResetEvent"/> that can be asynchronously awaited on.
/// </summary>
internal sealed partial class OneTimeAsyncEvent
{
    private readonly ILogger<OneTimeAsyncEvent>? logger;

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
    private readonly TaskCompletionSource taskCompletionSource;

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

    private enum LockState
    {
        UnsetClosed,
        SetOpen,
        Failed,
        Cancelled
    }

    /// <summary>
    /// Gets a value indicating whether the event is currently in a success signaled state.
    /// </summary>
#if AsyncManualResetEventWithValue
    [MemberNotNullWhen(true, nameof(value))]
#endif
    public bool IsCompletedSuccessfully
    {
        get
        {
            lock (syncObject)
                return PreLockedIsCompletedSuccessfully;
        }
    }
    /// <summary>
    /// Gets a value indicating whether the event is currently in a signaled state, which could be an exception or cancelled.
    /// </summary>
    public bool IsCompleted
    {
        get
        {
            lock (syncObject)
                return PreLockedIsCompleted;
        }
    }

#if AsyncManualResetEventWithValue
    [MemberNotNullWhen(true, nameof(value))]
#endif
    private bool PreLockedIsCompletedSuccessfully
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => state == LockState.SetOpen;
    }

    private bool PreLockedIsCompleted
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => state != LockState.UnsetClosed;
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="OneTimeAsyncEvent"/> class.
    /// </summary>
    /// <param name="allowInliningAwaiters">
    /// A value indicating whether to allow <see cref="WaitAsync()"/> callers' continuations to execute
    /// on the thread that calls <see cref="SetOpen()"/> before the call returns.
    /// <see cref="SetOpen()"/> callers should not hold private locks if this value is <see langword="true" /> to avoid deadlocks.
    /// When <see langword="false" />, the task returned from <see cref="WaitAsync()"/> may not have fully transitioned to
    /// its completed state by the time <see cref="SetOpen()"/> returns to its caller.
    /// </param>
    public OneTimeAsyncEvent(bool allowInliningAwaiters = false, ILogger<OneTimeAsyncEvent> logger = null!)
    {
        this.logger = logger;
        taskCompletionSource = new(allowInliningAwaiters ? TaskCreationOptions.RunContinuationsAsynchronously : TaskCreationOptions.None);
        state = LockState.UnsetClosed;
    }

    /// <inheritdoc cref="OneTimeAsyncEvent(bool, ILogger{OneTimeAsyncEvent})"/>
    public OneTimeAsyncEvent(Exception exception, bool allowInliningAwaiters = false, ILogger<OneTimeAsyncEvent> logger = null!) : this(allowInliningAwaiters, logger)
    {
        state = LockState.Failed;
        taskCompletionSource.SetException(exception);
    }

    /// <inheritdoc cref="OneTimeAsyncEvent(bool, ILogger{OneTimeAsyncEvent})"/>
    public OneTimeAsyncEvent(CancellationToken cancellationReason, bool allowInliningAwaiters = false, ILogger<OneTimeAsyncEvent> logger = null!) : this(allowInliningAwaiters, logger)
    {
        state = LockState.Failed;
        taskCompletionSource.SetCanceled(cancellationReason);
    }

#if AsyncManualResetEventWithValue
    /// <summary>
    /// Sets the event to open, unblocking all consumers
    /// </summary>
    /// <param name="value">The value that all consumers will receive</param>
#else
    /// <summary>
    /// Sets the event to open, unblocking all consumers
    /// </summary>
#endif
    public partial void SetOpen();

    public void SetCancelled(CancellationToken reason) => SetCore(LockState.Cancelled, transition: tcs => tcs.TrySetCanceled(reason));
    public void SetFailed(Exception exception) => SetCore(LockState.Failed, transition: tcs => tcs.TrySetException(exception));
#if AsyncManualResetEventWithValue
    private void SetCore(LockState newState, Func<TaskCompletionSource, bool> transition, T? value = default!)
#else
    private void SetCore(LockState newState, Func<TaskCompletionSource, bool> transition)
#endif
    {
        logger?.LogInformation("Attempting to set event to state {newState}", newState);
        TaskCompletionSource tcs;
        LockState prevState;

        lock (syncObject)
        {
            if (PreLockedIsCompleted)
            {
                tcs = null!;
                prevState = default;
            }
            else
            {
                state = LockState.SetOpen;
                tcs = taskCompletionSource;
                prevState = state;
#if AsyncManualResetEventWithValue
                this.value = value;
#endif
            }
        }

        if (tcs is null)
        {
            InvalidOperationException ex = new($"OneTimeAsyncEvent already set to state {state}, cannot move to state {newState}");
            logger?.LogError(ex, "OneTimeAsyncEvent already set to state {state}, cannot move to state {newState}", state, newState);
            throw ex;
        }

        logger?.LogDebug("Successfully set state to {newState} (from {prevState})", newState, prevState);
        bool setOpen = transition(tcs);
        if (!setOpen)
            logger?.LogWarning("Tried to set barrier to {state}, but failed to", newState);
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
    [SuppressMessage("Reliability", "CA2012:Use ValueTasks correctly", Justification = "<Pending>")]
    public ValueTaskAwaiter GetAwaiter() => WaitAsync().GetAwaiter();

    /// <inheritdoc/>
    public override string ToString()
    {
        lock (syncObject)
            return ToString_PreLocked();
    }
    /// <summary>
    /// Core implementation for <see cref="ToString"/>, only called while the <see cref="syncObject"/> lock is held
    /// </summary>
    /// <returns>A string represenation of this object</returns>
    private partial string ToString_PreLocked();
}

using System.Threading.Tasks;
using System.Threading;
using System;
using Microsoft.Extensions.Logging;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;
using BetterHosting.Services.Interfaces;

namespace BetterHosting.Services.Implementation;

/// <summary>
/// A flavor of <see cref="ManualResetEvent"/> that can be asynchronously awaited on.
/// </summary>
public class SingletonManager<T> : ISingletonManager<T> where T : class
{
    /// <summary>
    /// <see cref="TaskCreationOptions"/> for the task completion source creation, mainly if it should allow executing continuations synchronously.
    /// </summary>
    private const TaskCreationOptions AwaiterOptions = TaskCreationOptions.None /*| TaskCreationOptions.LongRunning*/ | TaskCreationOptions.RunContinuationsAsynchronously;

    private readonly ILogger<SingletonManager<T>> logger;

    /// <summary> The object to lock when accessing fields. </summary>
    private readonly object syncObject = new();

    /// <summary>
    /// The source of the task to return from <see cref="WaitAsync()"/>.
    /// </summary>
    /// <devremarks>
    /// This should not need the volatile modifier because it is
    /// always accessed within a lock.
    /// </devremarks>
    private TaskCompletionSource<T> taskCompletionSource = new(AwaiterOptions);

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
    [SuppressMessage("Style", "IDE0032:Use auto property", Justification = "Clarity")]
    private bool isSet;

    /// <summary>
    /// The value represented, only valid when <see cref="IsCompletedSuccessfully"/> is <see langword="true"/>.
    /// </summary>
    /// <devremarks>
    /// This should not need the volatile modifier because it is
    /// always accessed within a lock.
    /// </devremarks>
    private T? value;

    /// <summary>
    /// Constructs a new instance
    /// </summary>
    /// <param name="logger"></param>
    public SingletonManager(ILogger<SingletonManager<T>> logger) => this.logger = logger;

    /// <summary>
    /// Gets a value indicating whether the event is currently in a success signaled state.
    /// </summary>
    [MemberNotNullWhen(true, nameof(value))]
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

    [MemberNotNullWhen(true, nameof(value))]
    private bool PreLockedIsCompletedSuccessfully
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => PreLockedIsCompleted && value != null;
    }

    private bool PreLockedIsCompleted
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => isSet;
    }

    /// <summary>
    /// Without the weight of asyncronous blocking, quickly checks if the event is completed.
    /// </summary>
    /// <param name="value"></param>
    public bool TryGetNow([NotNullWhen(true), MaybeNullWhen(false)] out T value)
    {
        lock (syncObject)
        {
            value = this.value!;
            return PreLockedIsCompletedSuccessfully;
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
            if (PreLockedIsCompletedSuccessfully)
                return ValueTask.FromResult(value);
            task = taskCompletionSource.Task;
        }

        return new(task.WaitAsync(cancellationToken));
    }

    /// <inheritdoc />
    public void Set(T value)
    {
        bool wasSet;
        TaskCompletionSource<T> tcs;
        lock (syncObject)
        {
            tcs = taskCompletionSource;
            wasSet = isSet;
            isSet = true;
            this.value = value;
        }

        if (wasSet)
        {
            InvalidOperationException ex = new($"Unable to set value to {value} and set state to {true} because the event was in set state {wasSet}");
            logger.LogError(ex, "Tried to set value {value} multiple times", value);
            throw ex;
        }

        if (tcs.TrySetResult(value))
            logger.LogDebug("Set value of {value} ", value);
        else
            logger.LogWarning("Set failed to set value of {value}", value);
    }

    /// <inheritdoc />
    public void SetException(Exception exception) => SetCore(tcs => tcs.TrySetException(exception));

    /// <inheritdoc />
    public void SetCancelled(CancellationToken cancellationToken) => SetCore(tcs => tcs.TrySetCanceled(cancellationToken));

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private void SetCore(Func<TaskCompletionSource<T>, bool> transition)
    {
        bool wasSet;
        TaskCompletionSource<T> tcs;
        TaskCompletionSource<T> newTcs = new(AwaiterOptions);
        lock (syncObject)
        {
            wasSet = isSet;
            tcs = taskCompletionSource;
            if (isSet)
                taskCompletionSource = newTcs;

            value = null;
            isSet = true;
        }

        transition.Invoke(tcs);
        if (wasSet)
            transition.Invoke(newTcs);
    }

    /// <summary>
    /// Resets this event to a state that will block callers of <see cref="WaitAsync()"/>.
    /// </summary>
    public void Reset()
    {
        TaskCompletionSource<T> tcs = new(AwaiterOptions);
        lock (syncObject)
        {
            if (isSet)
            {
                taskCompletionSource = tcs;
                isSet = false;
                return;
            }
        }
        logger.LogDebug("Tried to reset manager, but it was already clear!");
    }
    /// <summary>
    /// Gets an awaiter that completes when this event is signaled.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    [SuppressMessage("Reliability", "CA2012:Use ValueTasks correctly", Justification = "Passing along for awaiting")]
    public ValueTaskAwaiter<T> Awaiter => WaitAsync().GetAwaiter();

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
    private string ToString_PreLocked()
    {
        string valueByState = IsCompletedSuccessfully ? value?.ToString() ?? "null" : "<not available>";
        return $"Complete: {IsCompleted}, value: {valueByState}";
    }
}
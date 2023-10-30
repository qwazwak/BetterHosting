using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

namespace DSharpPlus.BetterHosting.Services.Implementation.temp;

internal sealed partial class AsyncManualResetEvent<T>
{
    private T? value;

    public void SetOpen(T value)
    {
        logger?.LogInformation("Opening barrier");
        TaskCompletionSource<T> tcs;
        lock (syncObject)
        {
            if (state != LockState.UnsetClosed)
                taskCompletionSource = tcs = CreateTaskSource();
            else
                tcs = taskCompletionSource;

            // Atomically replace the completion source with a new, source
            // while capturing the previous one so we can complete it.
            // This ensures that we don't leave a gap in time where WaitAsync() will
            // continue to return completed Tasks due to a Pulse method which should
            // execute instantaneously.
            this.value = value;
            state = LockState.SetOpen;
        }
        taskCompletionSource.TrySetResult(value);
    }

    public bool TryGetNow(out T value)
    {
        lock (syncObject)
        {
            if (state != LockState.SetOpen)
            {
                value = this.value!;
                return true;
            }
        }
        value = default!;
        return false;
    }
#if false

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
            this.value = value
            state = LockState.UnsetClosed;
        }

        bool setOpen = previousTCS.TrySetResult(value);
        if (!setOpen)
            logger?.LogWarning("Tried to set barrier to open, but failed to");
    }
    public void PulseAll(CancellationToken reason)
    {
        TaskCompletionSource<T> previousTCS = PulseAllCore();

        bool setOpen = previousTCS.TrySetCanceled(reason);
        if (!setOpen)
            logger?.LogWarning("Tried to set barrier to canceled, but failed to");
    }

    public void PulseAll(Exception exception)
    {
        TaskCompletionSource<T> previousTCS = PulseAllCore();

        bool setOpen = previousTCS.TrySetException(exception);
        if (!setOpen)
            logger?.LogWarning("Tried to set barrier to exception ({message}), but failed to", exception.Message);
    }

    private TaskCompletionSource<T> PulseAllCore()
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
           // exception = null;
            //cancellationReason = null;
            state = LockState.UnsetClosed;
        }
        return previousTCS;
    }
#endif
}
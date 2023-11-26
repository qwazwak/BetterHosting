using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;

namespace BetterHosting.Services.Hosted;

/// <summary>
/// Base class for implementing a long running <see cref="IHostedService"/>.
/// </summary>
public abstract class BackgroundLifecycleService : BackgroundService, IHostedLifecycleService, IDisposable
{
    private Task? startTask;
    private Task? stopTask;
    private CancellationTokenSource? startCTS;
    private CancellationTokenSource? stopCTS;

    /// <summary>
    /// This method is called when the <see cref="IHostedService"/> begins starting. The implementation should return a task that represents
    /// the lifetime of the process to start the service.
    /// </summary>
    /// <param name="stoppingToken">Triggered when <see cref="IHostedService.StopAsync(CancellationToken)"/> is called.</param>
    /// <returns>A <see cref="Task"/> that represents the long running operations.</returns>
    protected abstract Task Start(CancellationToken stoppingToken);
    /// <summary>
    /// This method is called when the <see cref="IHostedService"/> begins stopping. The implementation should return a task that represents
    /// the lifetime of the process to stop the service.
    /// </summary>
    /// <param name="stoppingToken">Triggered when <see cref="IHostedService.StopAsync(CancellationToken)"/> is cancelled.</param>
    /// <returns>A <see cref="Task"/> that represents the long running operations.</returns>
    protected abstract Task Stop(CancellationToken stoppingToken);

    /// <inheritdoc />
    public virtual Task StartingAsync(CancellationToken cancellationToken) => StartTask(Start, out startTask, out startCTS, cancellationToken);
    /// <inheritdoc />
    public virtual Task StartedAsync(CancellationToken cancellationToken)
    {
        if (startTask == null)
            return Task.CompletedTask;

        Task result = startTask;
        startTask = null;
        return result;
    }

    /// <inheritdoc />
    public virtual Task StoppingAsync(CancellationToken cancellationToken) => StartTask(Stop, out stopTask, out stopCTS, cancellationToken);

    /// <inheritdoc />
    public virtual async Task StoppedAsync(CancellationToken cancellationToken)
    {
        if (startTask == null && stopTask == null)
            return;

        // Stop called without start
        try
        {
            // Signal cancellation to the executing method
            //if (startTask != null)
            startCTS?.Cancel();

            //if (stopTask != null)
            stopCTS?.Cancel();
        }
        finally
        {
#pragma warning disable CS8509 // The switch expression does not handle all possible values of its input type (it is not exhaustive).
            Task awaitTask = (startTask != null, stopTask != null) switch
            {
                (true, true) => Task.WhenAll(startTask!, stopTask!),
                (true, false) => startTask!,
                (false, true) => stopTask!
            };
#pragma warning restore CS8509 // The switch expression does not handle all possible values of its input type (it is not exhaustive).
            await SafeAwait(awaitTask, cancellationToken).ConfigureAwait(false);
        }
    }

    private static Task StartTask(Func<CancellationToken, Task> method, out Task task, out CancellationTokenSource cts, CancellationToken cancellationToken)
    {
        // Create linked token to allow cancelling executing task from provided token
        cts = CancellationTokenSource.CreateLinkedTokenSource(cancellationToken);

        // Store the task we're executing
        task = method(cts.Token);

        // If the task is completed then return it, this will bubble cancellation and failure to the caller
        if (task.IsCompleted)
            return task;

        // Otherwise it's running
        return Task.CompletedTask;
    }

    private static async Task SafeAwait(Task task, CancellationToken cancellationToken)
    {
        // Wait until the task completes or the stop token triggers
        TaskCompletionSource<object> tcs = new();
        using CancellationTokenRegistration registration = cancellationToken.Register(s => ((TaskCompletionSource<object>)s!).SetCanceled(), tcs);
        // Do not await the _executeTask because cancelling it will throw an OperationCanceledException which we are explicitly ignoring
        await Task.WhenAny(task, tcs.Task).ConfigureAwait(false);
    }

    /// <inheritdoc />
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Usage", "CA1816:Dispose methods should call SuppressFinalize", Justification = "<Pending>")]
    public override void Dispose()
    {
        startCTS?.Cancel();
        stopCTS?.Cancel();
    }
}

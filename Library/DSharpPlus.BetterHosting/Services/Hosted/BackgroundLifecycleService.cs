using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;

namespace DSharpPlus.BetterHosting.Services.Hosted;

/// <summary>
/// Base class for implementing a long running <see cref="IHostedService"/>.
/// </summary>
public abstract class BackgroundLifecycleService : BackgroundService, IHostedLifecycleService, IDisposable
{
    private Task? startTask;
    private Task? stopTask;
    private CancellationTokenSource? startCTS;
    private CancellationTokenSource? stopCTS;

    protected abstract Task Start(CancellationToken stoppingToken);
    protected abstract Task Stop(CancellationToken stoppingToken);

    /// <inheritdoc />
    public Task StartingAsync(CancellationToken cancellationToken) => StartTask(out startTask, out startCTS, cancellationToken);
    /// <inheritdoc />
    public Task StartedAsync(CancellationToken cancellationToken) => EndTask(startTask, cancellationToken);
    /// <inheritdoc />
    public Task StoppingAsync(CancellationToken cancellationToken) => StartTask(out stopTask, out stopCTS, cancellationToken);
    /// <inheritdoc />
    public Task StoppedAsync(CancellationToken cancellationToken) => EndTask(stopTask, cancellationToken);

    private Task StartTask(out Task task, out CancellationTokenSource cts, CancellationToken cancellationToken)
    {
        // Create linked token to allow cancelling executing task from provided token
        cts = CancellationTokenSource.CreateLinkedTokenSource(cancellationToken);

        // Store the task we're executing
        task = Start(cts.Token);

        // If the task is completed then return it, this will bubble cancellation and failure to the caller
        if (task.IsCompleted)
            return task;

        // Otherwise it's running
        return Task.CompletedTask;
    }

    private async Task EndTask(Task? task, CancellationToken cancellationToken)
    {
        // Stop called without start
        if (task == null)
        {
            return;
        }

        try
        {
            // Signal cancellation to the executing method
            startCTS!.Cancel();
        }
        finally
        {
            // Wait until the task completes or the stop token triggers
            TaskCompletionSource<object> tcs = new();
            using CancellationTokenRegistration registration = cancellationToken.Register(s => ((TaskCompletionSource<object>)s!).SetCanceled(), tcs);
            // Do not await the _executeTask because cancelling it will throw an OperationCanceledException which we are explicitly ignoring
            await Task.WhenAny(task, tcs.Task).ConfigureAwait(false);
        }
    }

    /// <inheritdoc />
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Usage", "CA1816:Dispose methods should call SuppressFinalize", Justification = "<Pending>")]
    public override void Dispose()
    {
        startCTS?.Cancel();
        stopCTS?.Cancel();
    }
}

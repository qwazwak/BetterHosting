using System;
using System.Diagnostics;
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
    public virtual Task StartingAsync(CancellationToken cancellationToken) => StartTask(Start, out startTask, out startCTS, cancellationToken);
    /// <inheritdoc />
    public virtual Task StartedAsync(CancellationToken cancellationToken) => EndTask(startTask, startCTS, cancellationToken);
    /// <inheritdoc />
    public virtual Task StoppingAsync(CancellationToken cancellationToken) => StartTask(Stop, out stopTask, out stopCTS, cancellationToken);
    /// <inheritdoc />
    public virtual Task StoppedAsync(CancellationToken cancellationToken) => EndTask(stopTask, stopCTS, cancellationToken);

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

    private static Task EndTask(Task? task, CancellationTokenSource? cts, CancellationToken cancellationToken)
    {
        // Stop called without start
        if (task == null)
            return Task.CompletedTask;

        Debug.Assert(cts != null);

        return EndTaskAsync(task, cts, cancellationToken);
    }
    private static async Task EndTaskAsync(Task task, CancellationTokenSource cts, CancellationToken cancellationToken)
    {
        try
        {
            // Signal cancellation to the executing method
            cts!.Cancel();
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

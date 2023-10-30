using System;
using System.Threading.Tasks;
using System.Threading;

namespace QLib;
/// <summary>
/// Holds the task for a cancellation token, as well as the token registration. The registration is disposed when this instance is disposed.
/// </summary>
public sealed class CancellationTokenTaskSource<T> : IDisposable
{
    /// <summary>
    /// The cancellation token registration, if any. This is <c>null</c> if the registration was not necessary.
    /// </summary>
    private readonly CancellationTokenRegistration? _registration;

    /// <summary>
    /// Gets the task for the source cancellation token.
    /// </summary>
    public Task<T> Task { get; }

    /// <summary>
    /// Creates a task for the specified cancellation token, registering with the token if necessary.
    /// </summary>
    /// <param name="cancellationToken">The cancellation token to observe.</param>
    public CancellationTokenTaskSource(CancellationToken cancellationToken)
    {
        if (cancellationToken.IsCancellationRequested)
        {
            Task = System.Threading.Tasks.Task.FromCanceled<T>(cancellationToken);
            return;
        }
        TaskCompletionSource<T> tcs = new();
        _registration = cancellationToken.Register(() => tcs.TrySetCanceled(cancellationToken), useSynchronizationContext: false);
        Task = tcs.Task;
    }

    /// <summary>
    /// Disposes the cancellation token registration, if any. Note that this may cause <see cref="Task"/> to never complete.
    /// </summary>
    public void Dispose() => _registration?.Dispose();
}

/// <summary>
/// Holds the task for a cancellation token, as well as the token registration. The registration is disposed when this instance is disposed.
/// </summary>
public sealed class CancellationTokenTaskSource : IDisposable
{
    /// <summary>
    /// The cancellation token registration, if any. This is <c>null</c> if the registration was not necessary.
    /// </summary>
    private readonly CancellationTokenRegistration? _registration;

    /// <summary>
    /// Gets the task for the source cancellation token.
    /// </summary>
    public Task Task { get; }

    /// <summary>
    /// Creates a task for the specified cancellation token, registering with the token if necessary.
    /// </summary>
    /// <param name="cancellationToken">The cancellation token to observe.</param>
    public CancellationTokenTaskSource(CancellationToken cancellationToken)
    {
        if (cancellationToken.IsCancellationRequested)
        {
            Task = Task.FromCanceled(cancellationToken);
            return;
        }
        TaskCompletionSource tcs = new();
        _registration = cancellationToken.Register(() => tcs.TrySetCanceled(cancellationToken), useSynchronizationContext: false);
        Task = tcs.Task;
    }

    /// <summary>
    /// Disposes the cancellation token registration, if any. Note that this may cause <see cref="Task"/> to never complete.
    /// </summary>
    public void Dispose() => _registration?.Dispose();
}

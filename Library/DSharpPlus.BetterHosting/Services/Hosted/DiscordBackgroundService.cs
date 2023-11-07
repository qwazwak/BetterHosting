using System;
using System.Threading;
using System.Threading.Tasks;
using DSharpPlus.BetterHosting.Services.Interfaces;
using Microsoft.Extensions.Hosting;

namespace DSharpPlus.BetterHosting.Services.Hosted;

/// <summary>
/// Template class to ease simple <see cref="BackgroundService"/> implementations which will simply await a connected <see cref="DiscordShardedClient"/>
/// </summary>
public abstract class DiscordBackgroundServiceBase : BackgroundService
{
    private readonly IConnectedClientProvider clientProvider;

    /// <summary>
    /// Base constructor
    /// </summary>
    /// <param name="clientProvider">Required <see cref="IConnectedClientProvider"/> to await and get the <see cref="DiscordShardedClient"/></param>
    protected DiscordBackgroundServiceBase(IConnectedClientProvider clientProvider)
    {
        ArgumentNullException.ThrowIfNull(clientProvider);
        this.clientProvider = clientProvider;
    }

    /// <inheritdoc/>
    protected override sealed async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        try
        {
            DiscordShardedClient client = await clientProvider.GetClientAsync(stoppingToken).AsTask().WaitAsync(stoppingToken);
            await AfterConnected(client, stoppingToken);
        }
        catch (OperationCanceledException)
        {
            return;
        }
    }

    /// <summary>
    /// Called after the <paramref name="client"/> is connected
    /// </summary>
    /// <param name="client"></param>
    /// <param name="stoppingToken"></param>
    /// <returns>A task, completion of which represents that the background service should finish</returns>
    protected abstract Task AfterConnected(DiscordShardedClient client, CancellationToken stoppingToken);

    /// <summary>
    /// Helper method to asynchronously wait/block until the <paramref name="cancellationToken"/> is signaled
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <returns>A task which will complete once the <paramref name="cancellationToken"/> is signaled</returns>
    protected static Task WaitForTimeout(CancellationToken cancellationToken) => Task.Delay(Timeout.Infinite, cancellationToken);
}

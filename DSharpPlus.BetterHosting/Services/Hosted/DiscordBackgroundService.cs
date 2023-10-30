using System.Threading;
using System.Threading.Tasks;
using DSharpPlus.BetterHosting.Services.Interfaces;
using Microsoft.Extensions.Hosting;

namespace DSharpPlus.BetterHosting.Services.Hosted;

public abstract class DiscordBackgroundServiceBase : BackgroundService
{
    private readonly IConnectedClientProvider clientProvider;

    protected DiscordBackgroundServiceBase(IConnectedClientProvider clientProvider) => this.clientProvider = clientProvider;

    /// <inheritdoc/>
    protected override sealed async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        DiscordShardedClient client = await clientProvider.GetClientAsync(stoppingToken);
        if (stoppingToken.IsCancellationRequested)
            return;
        await AfterConnected(client, stoppingToken);
    }

    /// <summary>
    /// Called after the <paramref name="client"/> is connected
    /// </summary>
    /// <param name="client"></param>
    /// <param name="stoppingToken"></param>
    /// <returns>A task, completion of which represents that the background service should finish</returns>
    protected abstract Task AfterConnected(DiscordShardedClient client, CancellationToken stoppingToken);

    protected static Task WaitForTimeout(CancellationToken cancellationToken) => Task.Delay(Timeout.Infinite, cancellationToken);
}

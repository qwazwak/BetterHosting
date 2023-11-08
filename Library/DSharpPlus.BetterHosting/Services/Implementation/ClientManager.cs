using System;
using System.Threading;
using System.Threading.Tasks;
using DSharpPlus.BetterHosting.Services.Interfaces;
using Microsoft.Extensions.Logging;
using DSharpPlus.BetterHosting.Tools.AsyncEventBlock;

namespace DSharpPlus.BetterHosting.Services.Implementation;

internal sealed class ClientManager : IClientManager
{
    private readonly ILogger<ClientManager> logger;
    private readonly OneTimeAsyncEvent<DiscordShardedClient> manualEvent = new(true);

    public ClientManager(ILogger<ClientManager> logger) => this.logger = logger;

    private void ThrowIfDoubleConstructed()
    {
        if (manualEvent.IsCompleted)
        {
            logger.LogError("Client was constructed multiple times");
            throw new InvalidOperationException("Cannot reconstruct client");
        }
    }

    public ValueTask<DiscordShardedClient> GetClientAsync(CancellationToken cancellationToken) => manualEvent.WaitAsync(cancellationToken);

    public void SetConnected(DiscordShardedClient client)
    {
        ThrowIfDoubleConstructed();
        manualEvent.SetOpen(client);
    }
    public void SetFailed(Exception exception) => manualEvent.SetFailed(exception);
    public void SetCancelled(CancellationToken reason = default) => manualEvent.SetCancelled(reason);
}

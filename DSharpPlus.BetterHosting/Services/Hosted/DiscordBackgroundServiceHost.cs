using System.Threading;
using System.Threading.Tasks;
using DSharpPlus.BetterHosting.Services.Interfaces;

namespace DSharpPlus.BetterHosting.Services.Hosted;

internal sealed class DiscordBackgroundServiceHost<TService> : DiscordBackgroundServiceBase where TService : IDiscordBackgroundService
{
    private readonly TService service;

    public DiscordBackgroundServiceHost(IConnectedClientProvider clientProvider, TService service) : base(clientProvider) => this.service = service;

    protected override Task AfterConnected(DiscordShardedClient shardedClient, CancellationToken stoppingToken) => service.AfterConnected(shardedClient, stoppingToken);
}

using System.Threading;
using System.Threading.Tasks;
using BetterHosting.Services.Interfaces;
using DSharpPlus;

namespace BetterHosting.Services.Hosted;

internal sealed class DiscordBackgroundServiceHost<TService> : DiscordBackgroundServiceBase where TService : IDiscordBackgroundService
{
    private readonly TService service;

    public DiscordBackgroundServiceHost(IConnectedClientProvider clientProvider, TService service) : base(clientProvider) => this.service = service;

    protected override Task AfterConnected(DiscordShardedClient shardedClient, CancellationToken stoppingToken) => service.AfterConnected(shardedClient, stoppingToken);
}

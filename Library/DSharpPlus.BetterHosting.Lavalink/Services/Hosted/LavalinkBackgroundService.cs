using System.Threading;
using System.Threading.Tasks;
using DSharpPlus.BetterHosting.Services.Hosted;
using DSharpPlus.Lavalink;
using Microsoft.Extensions.Options;

namespace DSharpPlus.BetterHosting.Lavalink.Services.Hosted;

internal sealed class LavalinkBackgroundService : IDiscordBackgroundService
{
    private readonly LavalinkConfiguration options;

    public LavalinkBackgroundService(IOptions<LavalinkConfiguration> options) : this(options.Value) { }
    public LavalinkBackgroundService(LavalinkConfiguration options) => this.options = options;

    public async Task AfterConnected(DiscordShardedClient client, CancellationToken stoppingToken)
    {
        await client.InitializeShardsAsync();
        await Parallel.ForEachAsync(client.ShardClients.Values, async (c, _) =>
        {
            LavalinkExtension Extension = c.GetExtension<LavalinkExtension>();
            await Extension.ConnectAsync(options);
        });
    }
}
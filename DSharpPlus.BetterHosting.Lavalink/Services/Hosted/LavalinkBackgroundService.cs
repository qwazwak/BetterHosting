using System.Threading;
using System.Threading.Tasks;
using DSharpPlus.BetterHosting.Services.Hosted;
using DSharpPlus.Lavalink;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.Options;

namespace DSharpPlus.BetterHosting.Lavalink.Services.Hosted;

internal sealed class LavalinkBackgroundService : IDiscordBackgroundService
{
    private readonly LavalinkConfiguration options;

    public LavalinkBackgroundService(IOptions<LavalinkConfiguration> options) : this(options.Value) { }
    public LavalinkBackgroundService(LavalinkConfiguration options) => this.options = options;

    public async Task AfterConnected(DiscordShardedClient shardedClient, CancellationToken stoppingToken)
    {
        IReadOnlyDictionary<int, LavalinkExtension> extensions = await shardedClient.GetLavalinkAsync();
        if (stoppingToken.IsCancellationRequested)
            return;

        List<Task> shardConnectionTasks = new(extensions.Count);
        shardConnectionTasks.AddRange(extensions.Values.Select(l => l.ConnectAsync(options)));
        await Task.WhenAll(shardConnectionTasks);
        await Task.Delay(Timeout.Infinite, stoppingToken);
    }
}
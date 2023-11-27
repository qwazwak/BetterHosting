using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using BetterHosting.Services.Hosted;
using DSharpPlus;
using DSharpPlus.Lavalink;
using Microsoft.Extensions.Options;

namespace BetterHosting.Lavalink.Services.Hosted;

internal sealed class LavalinkBackgroundService : IDiscordBackgroundService
{
    private readonly IOptions<LavalinkConfiguration> options;

    public LavalinkBackgroundService(IOptions<LavalinkConfiguration> options) => this.options = options;

    [ExcludeFromCodeCoverage(Justification = CodeCoverageExclusionReasons.DSharpSealed)]
    public async Task AfterConnected(DiscordShardedClient client, CancellationToken stoppingToken)
    {
        await client.InitializeShardsAsync();
        if (stoppingToken.IsCancellationRequested)
            return;
        LavalinkConfiguration options = this.options.Value;
        await Task.WhenAll(client.ShardClients.Values.Select(c => c.GetExtension<LavalinkExtension>().ConnectAsync(options))).ConfigureAwait(false);
    }
}
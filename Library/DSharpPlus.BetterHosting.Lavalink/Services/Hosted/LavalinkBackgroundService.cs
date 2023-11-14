using System.Diagnostics.CodeAnalysis;
using System.Threading;
using System.Threading.Tasks;
using DSharpPlus.BetterHosting.Services.Hosted;
using DSharpPlus.Lavalink;
using Microsoft.Extensions.Options;

namespace DSharpPlus.BetterHosting.Lavalink.Services.Hosted;

internal sealed class LavalinkBackgroundService : IDiscordBackgroundService
{
    private readonly IOptions<LavalinkConfiguration> options;

    public LavalinkBackgroundService(IOptions<LavalinkConfiguration> options) => this.options = options;

    [ExcludeFromCodeCoverage(Justification = CoveCoverageExclusionReasons.DSharpSealed)]
    public async Task AfterConnected(DiscordShardedClient client, CancellationToken stoppingToken)
    {
        await client.InitializeShardsAsync().WaitAsync(stoppingToken);
        LavalinkConfiguration options = this.options.Value;
        await Parallel.ForEachAsync(client.ShardClients.Values, stoppingToken, [ExcludeFromCodeCoverage(Justification = CoveCoverageExclusionReasons.LambdaWrapper)] async (c, st) =>
        {
            LavalinkExtension extension = c.GetExtension<LavalinkExtension>();
            await extension.ConnectAsync(options).WaitAsync(st);
        });
    }
}
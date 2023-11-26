using System.Diagnostics.CodeAnalysis;
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

    [ExcludeFromCodeCoverage(Justification = CoveCoverageExclusionReasons.DSharpSealed)]
    public async Task AfterConnected(DiscordShardedClient client, CancellationToken stoppingToken)
    {
        await client.InitializeShardsAsync().WaitAsync(stoppingToken);
        LavalinkConfiguration options = this.options.Value;
        await Parallel.ForEachAsync(client.ShardClients.Values, stoppingToken, [ExcludeFromCodeCoverage(Justification = CoveCoverageExclusionReasons.LambdaWrapper)] (c, st) =>
        {
            LavalinkExtension extension = c.GetExtension<LavalinkExtension>();
            return new(extension.ConnectAsync(options).WaitAsync(st));
        });
    }
}
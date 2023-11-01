using System.Threading;
using System.Threading.Tasks;

namespace DSharpPlus.BetterHosting.Services.Hosted;

public interface IDiscordBackgroundService
{
    Task AfterConnected(DiscordShardedClient client, CancellationToken stoppingToken);
}
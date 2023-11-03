using System.Threading;
using System.Threading.Tasks;

namespace DSharpPlus.BetterHosting.EventsNext.Services;

internal interface IEventHandlerManager
{
    bool CanBeTriggered(DiscordShardedClient client);

    Task Run(DiscordShardedClient client, CancellationToken stoppingToken);
}

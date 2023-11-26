using DSharpPlus;

namespace BetterHosting.EventsNext.Services;

internal interface IEventHandlerManager
{
    bool CanBeTriggered();
    bool CanBeTriggered(DiscordShardedClient client);

    void Start(DiscordShardedClient client);
    void Stop();
}
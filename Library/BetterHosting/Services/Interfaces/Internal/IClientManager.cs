using DSharpPlus;

namespace BetterHosting.Services.Interfaces.Internal;

internal interface IClientManager : ISingletonManager<DiscordShardedClient> { }
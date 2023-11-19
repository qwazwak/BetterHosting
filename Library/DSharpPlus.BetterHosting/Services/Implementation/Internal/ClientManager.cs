using Microsoft.Extensions.Logging;
using DSharpPlus.BetterHosting.Services.Interfaces.Internal;

namespace DSharpPlus.BetterHosting.Services.Implementation.Internal;

internal sealed class ClientManager(ILogger<SingletonManager<DiscordShardedClient>> logger) : SingletonManager<DiscordShardedClient>(logger), IClientManager { }

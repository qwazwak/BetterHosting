using Microsoft.Extensions.Logging;
using BetterHosting.Services.Interfaces.Internal;
using DSharpPlus;

namespace BetterHosting.Services.Implementation.Internal;

internal sealed class ClientManager(ILogger<SingletonManager<DiscordShardedClient>> logger) : SingletonManager<DiscordShardedClient>(logger), IClientManager { }

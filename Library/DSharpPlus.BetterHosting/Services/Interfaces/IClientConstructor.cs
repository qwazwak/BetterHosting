using System.Threading.Tasks;

namespace DSharpPlus.BetterHosting.Services.Interfaces;

#if combine
internal interface IClientConstructor : IClientProvider
{
    DiscordShardedClient ConstructClient();
}
internal interface IClientConstructor : IClientConstructorOnly, IClientProvider
{
}

internal interface IClientConstructorOnly
{
    DiscordShardedClient ConstructClient();
}

#else
internal interface IClientConstructor
{
    Task<DiscordShardedClient> ConstructClient();
}
#endif
using System.Threading.Tasks;

namespace DSharpPlus.BetterHosting.Services.Interfaces.ExtensionConfigurators;

internal interface IMasterClientConfigurator
{
    public ValueTask Configure(DiscordShardedClient client);
}
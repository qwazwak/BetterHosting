using System.Threading.Tasks;
using DSharpPlus.BetterHosting.Services.Interfaces.Internal;
using Microsoft.Extensions.Options;

namespace DSharpPlus.BetterHosting.Services.Implementation.Internal;

internal sealed class ClientConstructor : IClientConstructor
{
    private readonly IOptions<DiscordConfiguration> config;
    private readonly IMasterClientConfigurator masterConfigurator;

    public ClientConstructor(IOptions<DiscordConfiguration> config, IMasterClientConfigurator masterConfigurator)
    {
        this.config = config;
        this.masterConfigurator = masterConfigurator;
    }

    public async Task<DiscordShardedClient> ConstructClient()
    {
        DiscordConfiguration config = this.config.Value;
        DiscordShardedClient client = new(config);
        await masterConfigurator.Configure(client);
        return client;
    }
}
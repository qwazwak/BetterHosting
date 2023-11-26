using System.Threading;
using System.Threading.Tasks;
using BetterHosting.Services.Interfaces.Internal;
using DSharpPlus;
using Microsoft.Extensions.Options;

namespace BetterHosting.Services.Implementation.Internal;

internal sealed class ClientConstructor : IClientConstructor
{
    private readonly IOptions<DiscordConfiguration> config;
    private readonly IMasterClientConfigurator masterConfigurator;

    public ClientConstructor(IOptions<DiscordConfiguration> config, IMasterClientConfigurator masterConfigurator)
    {
        this.config = config;
        this.masterConfigurator = masterConfigurator;
    }

    public async Task<DiscordShardedClient> ConstructClient(CancellationToken cancellationToken)
    {
        DiscordConfiguration config = this.config.Value;
        DiscordShardedClient client = new(config);
        await masterConfigurator.Configure(client, cancellationToken);
        return client;
    }
}
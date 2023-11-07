using System;
using System.Threading.Tasks;
using DSharpPlus.BetterHosting.Services.Interfaces;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace DSharpPlus.BetterHosting.Services.Implementation;

internal sealed class ClientConstructor : IClientConstructor
{
    private readonly ILogger<ClientConstructor> logger;
    private readonly DiscordConfiguration config;
    private readonly IMasterClientConfigurator masterConfigurator;

    public ClientConstructor(ILogger<ClientConstructor> logger, IOptions<DiscordConfiguration> config, IMasterClientConfigurator masterConfigurator)
    {
        this.logger = logger;
        this.config = config.Value;
        this.masterConfigurator = masterConfigurator;
    }

    public async Task<DiscordShardedClient> ConstructClient()
    {
        try
        {
            DiscordShardedClient client = new(config);
            await masterConfigurator.Configure(client);
            return client;
        }
        catch (Exception ex)
        {
            logger.LogError(ex, $"There was a problem building/configuring the {nameof(DiscordShardedClient)}");
            throw;
        }
    }
}
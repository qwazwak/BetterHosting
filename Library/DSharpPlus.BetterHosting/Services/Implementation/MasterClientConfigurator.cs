using System.Threading.Tasks;
using System.Collections.Generic;
using DSharpPlus.BetterHosting.Services.Interfaces.ExtensionConfigurators;
using System;
using Microsoft.Extensions.Logging;

namespace DSharpPlus.BetterHosting.Services.Implementation;

internal sealed class MasterClientConfigurator : IMasterClientConfigurator
{
    private readonly ILogger<MasterClientConfigurator> logger;
    private readonly List<IDiscordClientConfigurator> configurators;
    public MasterClientConfigurator(ILogger<MasterClientConfigurator> logger, IEnumerable<IDiscordClientConfigurator> configurators)
    {
        this.logger = logger;
        this.configurators = new(configurators);
    }

    public ValueTask Configure(DiscordShardedClient client)
    {
        if (configurators.Count == 0)
        {
            logger.LogInformation("No client configurators found, ending fast");
            return ValueTask.CompletedTask;
        }

        return new(ConfigureAsync(client));
    }

    private async Task ConfigureAsync(DiscordShardedClient client)
    {
        foreach (IDiscordClientConfigurator configurator in configurators)
        {
            try
            {
                await configurator.Configure(client);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "configurator of type {typeName} failed to run: {message}", configurator.GetType().Name, ex.Message);
                throw;
            }
        }
    }
}
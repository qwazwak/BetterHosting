using System.Threading.Tasks;
using System.Collections.Generic;
using DSharpPlus.BetterHosting.Services.Interfaces.ExtensionConfigurators;
using System;
using Microsoft.Extensions.Logging;
using DSharpPlus.BetterHosting.Services.Interfaces;

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

    public async Task Configure(DiscordShardedClient client)
    {
        List<Exception> exceptions = new(0);
        foreach (IDiscordClientConfigurator configurator in configurators)
        {
            try
            {
                await configurator.Configure(client);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "configurator of type {typeName} failed to run: {message}", configurator.GetType().Name, ex.Message);
                exceptions.Add(ex);
                throw;
            }
        }
        if (exceptions.Count > 0)
            throw new AggregateException("One or more exceptions occured while setting up DiscordShardedClient", exceptions);
    }
}
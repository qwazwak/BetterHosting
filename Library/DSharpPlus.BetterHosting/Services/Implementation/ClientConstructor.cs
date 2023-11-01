using System;
using System.Threading.Tasks;
using DSharpPlus.BetterHosting.Services.Interfaces;
using DSharpPlus.BetterHosting.Services.Interfaces.ExtensionConfigurators;
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

#if false
using System;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Threading;
using System.Threading.Tasks;
using DSharpPlus.BetterHosting.Services.Interfaces;
using DSharpPlus.BetterHosting.Services.Interfaces.ConfigurationProviders;
using DSharpPlus.BetterHosting.Services.Interfaces.ExtensionConfigurators;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using QLib.AsyncLocking;

namespace DSharpPlus.BetterHosting.Services.Implementation;

internal sealed class ClientProvider : IClientProvider, IClientConstructor
{
    private readonly ILogger<ClientProvider> logger;
    private readonly IBarrierManager barrierManager;
    private readonly Lazy<DiscordConfiguration> config;
    private readonly ShortScopeProvider<IDiscordClientConfiguratorRunner> masterConfigurator;

    public ClientProvider(ILogger<ClientProvider> logger, [FromKeyedServices(BarrierKeys.DiscordConnected)] IBarrierManager barrierManager, ShortScopeProvider<IDiscordConfigurationProvider> shortScope, ShortScopeProvider<IDiscordClientConfiguratorRunner> masterConfigurator)
    {
        this.logger = logger;
        this.barrierManager = barrierManager;
        config = new(() => shortScope.Get(c => c.GetConfiguration()));
        this.masterConfigurator = masterConfigurator;
    }
    private readonly AsyncManualResetEvent<DiscordShardedClient> clientLock = new();
    private readonly Mutex constructorLock = new();

    public bool TryGetClient([MaybeNullWhen(false), NotNullWhen(true)] out DiscordShardedClient? client) => clientLock.TryGetValueNow(out client);

    public ValueTask<DiscordShardedClient> GetClientAsync() => clientLock.WaitAsync();

    public async Task<DiscordShardedClient> ConstructClient()
    {
        constructorLock.WaitOne();
        try
        {
            if (clientLock.IsSet)
                return await GetClientAsync();

            DiscordShardedClient shardedClient = new(config.Value);
            await masterConfigurator.RunAsync(m => m.Configure(shardedClient));
            clientLock.Set(shardedClient);
            return shardedClient;
        }
        catch (Exception ex)
        {
            logger.LogError(ex, $"There was a problem building/configuring the {nameof(DiscordShardedClient)}");
            throw;
        }
        finally
        {
            constructorLock.ReleaseMutex();
        }
    }
}
#endif

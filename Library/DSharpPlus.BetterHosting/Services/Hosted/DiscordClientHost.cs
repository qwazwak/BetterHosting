using System;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using DSharpPlus.BetterHosting.Services.Interfaces.Internal;
using Microsoft.Extensions.Logging;

namespace DSharpPlus.BetterHosting.Services.Hosted;

internal class DiscordClientHost : BackgroundLifecycleService
{
    private readonly ILogger<DiscordClientHost> logger;
    private readonly IClientManager clientManager;
    private readonly IShortClientConstructor clientConstructor;

    private DiscordShardedClient? client;

    public DiscordClientHost(ILogger<DiscordClientHost> logger, IShortClientConstructor clientConstructor, IClientManager clientManager)
    {
        this.logger = logger;
        this.clientConstructor = clientConstructor;
        this.clientManager = clientManager;
    }

    private async Task<DiscordShardedClient> ConstructClient()
    {
        try
        {
            return await clientConstructor.ConstructClient();
        }
        catch (Exception ex) when (ex is not TaskCanceledException)
        {
            logger.LogError(ex, $"There was a problem building/configuring the {nameof(DiscordShardedClient)}. Unable to startup client due to unexpected exception {{type}}: {{message}}", ex.GetType(), ex.Message);
            throw;
        }
    }

    private async Task ConnectClient(DiscordShardedClient client)
    {
        try
        {
            await client.StartAsync();
        }
        catch (Exception ex) when (ex is not TaskCanceledException)
        {
            logger.LogError(ex, "Unable to connect because of {message}", ex.Message);
            throw;
        }
    }

    protected override Task ExecuteAsync(CancellationToken stoppingToken) => Task.CompletedTask;
    protected override async Task Start(CancellationToken stoppingToken)
    {
        if (client != null)
            return;

        try
        {
            client = await ConstructClient().WaitAsync(stoppingToken);
            logger.LogTrace("Connecting to discord...");
            await ConnectClient(client).WaitAsync(stoppingToken);
            logger.LogTrace("Discord connected");
        }
        catch (TaskCanceledException ex)
        {
            clientManager.SetCancelled(ex.CancellationToken);
            return;
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Unable to startup client because of {message}", ex.Message);
            clientManager.SetException(ex);
            throw;
        }

        Debug.Assert(client != null);
        if (stoppingToken.IsCancellationRequested)
            clientManager.SetCancelled(stoppingToken);
        else
            clientManager.Set(client);
    }

    protected override Task Stop(CancellationToken cancellationToken)
    {
        DiscordShardedClient? client = this.client;
        // Stop called without start
        if (client == null)
            return Task.CompletedTask;
        this.client = null;

        clientManager.SetCancelled(cancellationToken);
        return client.StopAsync();
    }
}
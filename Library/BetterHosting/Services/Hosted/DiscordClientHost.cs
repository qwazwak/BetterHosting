using System;
using System.Threading;
using System.Threading.Tasks;
using BetterHosting.Services.Interfaces.Internal;
using DSharpPlus;
using Microsoft.Extensions.Logging;

namespace BetterHosting.Services.Hosted;

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

    protected override Task ExecuteAsync(CancellationToken stoppingToken) => Task.CompletedTask;

    protected override async Task Start(CancellationToken stoppingToken)
    {
        if(client != null)
        {
            logger.LogWarning("Service restarted without shutdown, how??");
            return;
        }

        logger.LogInformation("Starting discord setup...");

        try
        {
            client = await clientConstructor.ConstructClient(stoppingToken).ConfigureAwait(false);
            stoppingToken.ThrowIfCancellationRequested();
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
        logger.LogDebug("Constructed discord client");

        try
        {
            await client.StartAsync().WaitAsync(stoppingToken).ConfigureAwait(false);
            await client.InitializeShardsAsync().WaitAsync(stoppingToken).ConfigureAwait(false);
        }
        catch (TaskCanceledException ex)
        {
            clientManager.SetCancelled(ex.CancellationToken);
            return;
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Unable to connect client because of {message}", ex.Message);
            clientManager.SetException(ex);
            throw;
        }

        logger.LogInformation("Discord connected");

        if (stoppingToken.IsCancellationRequested)
            clientManager.SetCancelled(stoppingToken);
        else
            clientManager.Set(client);
    }

    public override Task StoppingAsync(CancellationToken cancellationToken)
    {
        clientManager.SetCancelled(cancellationToken);
        return base.StoppingAsync(cancellationToken);
    }

    protected override async Task Stop(CancellationToken cancellationToken)
    {
        DiscordShardedClient? client = this.client;
        this.client = null;
        if (client == null)
            return;

        logger.LogInformation("Starting discord shutdown...");
        try
        {
            await client.StopAsync().WaitAsync(cancellationToken).ConfigureAwait(false);
        }
        catch (TaskCanceledException)
        {
            return;
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Unable to connect because of {message}", ex.Message);
            throw;
        }
    }
}
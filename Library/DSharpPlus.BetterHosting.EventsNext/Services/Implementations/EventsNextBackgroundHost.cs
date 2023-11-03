using System.Threading;
using System.Threading.Tasks;
using DSharpPlus.BetterHosting.Services.Interfaces;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace DSharpPlus.BetterHosting.EventsNext.Services.Implementations;

internal sealed class EventsNextBackgroundHost<TManager> : BackgroundService where TManager : IEventHandlerManager
{
    private readonly ILogger logger;
    private readonly TManager manager;
    private readonly IConnectedClientProvider clientProvider;

    public EventsNextBackgroundHost(ILogger logger, TManager manager, IConnectedClientProvider clientProvider)
    {
        this.logger = logger;
        this.manager = manager;
        this.clientProvider = clientProvider;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        DiscordShardedClient client;
        try
        {
            client = await clientProvider.GetClientAsync(stoppingToken).AsTask();
        }
        catch (System.OperationCanceledException)
        {
            return;
        }
        await AfterConnected(client, stoppingToken);
    }

    private Task AfterConnected(DiscordShardedClient client, CancellationToken stoppingToken)
    {
        if (!manager.CanBeTriggered(client))
        {
            logger.LogInformation("Events for handlers {HandlerType} were declared to not happen, so exiting quick", typeof(TManager).Name);
            return Task.CompletedTask;
        }
        else if (stoppingToken.IsCancellationRequested)
        {
            logger.LogInformation("Startup cancellation requested, not starting event manager {type}", typeof(TManager).Name);
            return Task.CompletedTask;
        }
        else
        {
            logger.LogDebug("Starting event manager {type}", typeof(TManager).Name);
            return manager.Run(client, stoppingToken);
        }
    }
}

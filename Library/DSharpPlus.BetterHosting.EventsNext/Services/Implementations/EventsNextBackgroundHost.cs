using System;
using System.Threading;
using System.Threading.Tasks;
using DSharpPlus.BetterHosting.Services.Hosted;
using DSharpPlus.BetterHosting.Services.Interfaces;
using Microsoft.Extensions.Logging;

namespace DSharpPlus.BetterHosting.EventsNext.Services.Implementations;

internal sealed class EventsNextBackgroundHost<TManager> : BackgroundLifecycleService where TManager : IEventHandlerManager
{
    private readonly ILogger<EventsNextBackgroundHost<TManager>> logger;
    private readonly TManager manager;
    private readonly IConnectedClientProvider clientProvider;

    public EventsNextBackgroundHost(ILogger<EventsNextBackgroundHost<TManager>> logger, TManager manager, IConnectedClientProvider clientProvider)
    {
        this.logger = logger;
        this.manager = manager;
        this.clientProvider = clientProvider;
    }

    /// <inheritdoc />
    public override Task StartingAsync(CancellationToken cancellationToken)
    {
        if (manager.CanBeTriggered())
            return base.StartingAsync(cancellationToken);

        logger.LogInformation("Startup cancellation requested, not starting event manager {type}", typeof(TManager).Name);
        return Task.CompletedTask;
    }

    protected override async Task Start(CancellationToken cancellationToken)
    {
        DiscordShardedClient client;
        try
        {
            client = await clientProvider.GetClientAsync(cancellationToken);
        }
        catch (OperationCanceledException)
        {
            logger.LogInformation("Startup cancellation requested, not starting event manager {type}", typeof(TManager).Name);
            return;
        }

        if (manager.CanBeTriggered(client))
            manager.Start(client);
        else
            logger.LogInformation("Events for handlers managed by {HandlerType} were declared to not happen, so exiting quick", typeof(TManager).Name);
    }

    protected override Task ExecuteAsync(CancellationToken stoppingToken) => Task.CompletedTask;

    protected override Task Stop(CancellationToken cancellationToken)
    {
        manager.Stop();
        return Task.CompletedTask;
    }
}
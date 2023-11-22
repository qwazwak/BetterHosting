using System;
using System.Threading;
using System.Threading.Tasks;
using DSharpPlus.BetterHosting.Services.Hosted;
using DSharpPlus.BetterHosting.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace DSharpPlus.BetterHosting.EventsNext.Services.Implementations;

internal class EventsNextBackgroundHostBase : BackgroundLifecycleService
{
    private readonly ILogger<EventsNextBackgroundHostBase> logger;
    private readonly IEventHandlerManager manager;
    private readonly IConnectedClientProvider clientProvider;

    public EventsNextBackgroundHostBase(ILogger<EventsNextBackgroundHostBase> logger, IEventHandlerManager manager, IConnectedClientProvider clientProvider)
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

        logger.LogTrace("Manager was not able to be trigged, ending fast");
        return Task.CompletedTask;
    }

    protected override async Task Start(CancellationToken cancellationToken)
    {
        DiscordShardedClient client;
        try
        {
            client = await clientProvider.GetClientAsync(cancellationToken).ConfigureAwait(false);
        }
        catch (OperationCanceledException)
        {
            logger.LogDebug("Startup cancellation requested, not starting event manager");
            return;
        }

        if (manager.CanBeTriggered(client))
            manager.Start(client);
        else
            logger.LogInformation("Events for this manager were declared to not happen, so exiting quick");
    }

    protected override Task ExecuteAsync(CancellationToken stoppingToken) => Task.CompletedTask;

    protected override Task Stop(CancellationToken cancellationToken)
    {
        manager.Stop();
        return Task.CompletedTask;
    }
}

internal class EventsNextBackgroundHost<TEventInterface> : EventsNextBackgroundHostBase
{
    [ActivatorUtilitiesConstructor]
    public EventsNextBackgroundHost(ILogger<EventsNextBackgroundHost<TEventInterface>> logger, IServiceProvider provider, IConnectedClientProvider clientProvider) : base(logger, provider.GetRequiredKeyedService<IEventHandlerManager>(typeof(TEventInterface)), clientProvider) { }
    public EventsNextBackgroundHost(ILogger<EventsNextBackgroundHost<TEventInterface>> logger, IEventHandlerManager manager, IConnectedClientProvider clientProvider) : base(logger, manager, clientProvider) { }
}
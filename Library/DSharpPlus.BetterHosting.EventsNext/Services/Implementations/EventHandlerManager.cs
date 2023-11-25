using System;
using System.Collections.Immutable;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using DSharpPlus.AsyncEvents;
using DSharpPlus.EventArgs;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace DSharpPlus.BetterHosting.EventsNext.Services.Implementations;

internal abstract class EventHandlerManager<TInterface, TArgument> : IEventHandlerManager
    where TInterface : IDiscordEventHandler<TArgument>
    where TArgument : DiscordEventArgs
{
    private readonly ILogger<EventHandlerManager<TInterface, TArgument>> logger;
    private readonly ImmutableArray<Guid> registrations;
    private readonly IKeyedServiceProvider provider;
    private readonly AsyncEventHandler<DiscordClient, TArgument> handlerMethod;
    private DiscordShardedClient client = null!;
    private bool started;

    protected EventHandlerManager(ILogger<EventHandlerManager<TInterface, TArgument>> logger, IKeyedServiceProvider provider, IHandlerRegistryKeyProvider<TInterface> registry)
    {
        this.logger = logger;
        this.provider = provider;
        handlerMethod = logger.IsEnabled(LogLevel.Debug) ? OnEventLoggingWrapper : OnEventCore;
        registrations = registry.GetKeys();
    }

    public virtual bool CanBeTriggered() => registrations.Length != 0;
    public virtual bool CanBeTriggered(DiscordShardedClient client) => true;

    public void Start(DiscordShardedClient client)
    {
        this.client = client;
        Stopwatch sw = new();
        try
        {
            logger.LogTrace("Setting up event handler");
            sw.Start();
            SetBindingState(true);
            started = true;
        }
        finally
        {
            sw.Stop();
            logger.LogInformation("Finished event handler setup in {time}", sw.Elapsed);
        }
    }

    public void Stop()
    {
        if (!started)
        {
            logger.LogTrace("No need to shutdown manager as it was not started");
            return;
        }
        started = false;

        Stopwatch sw = new();
        try
        {
            logger.LogTrace("Tearing down event handler");
            sw.Start();
            SetBindingState(false);
        }
        finally
        {
            sw.Stop();
            logger.LogInformation("Finished event handler teardown in {time}", sw.Elapsed);
        }
    }

    private bool _bindingState;
    private void SetBindingState(bool value)
    {
        Debug.Assert(_bindingState != value, "Binding state was set to the same value twice in a row!");
        if (_bindingState == value)
            throw new InvalidOperationException("Binding state was set to the same value twice in a row!");
        _bindingState = value;

        Stopwatch sw = new();
        logger.LogTrace("Changing event handler binding state to {state}", value ? "bound" : "unbound");
        sw.Start();

        if (value)
            BindHandler(client, handlerMethod);
        else
            UnbindHandler(client, handlerMethod);

        sw.Stop();
        logger.LogDebug("Finished binding change in {time}", sw.Elapsed);
    }

    private async Task OnEventLoggingWrapper(DiscordClient sender, TArgument args)
    {
        Stopwatch sw = new();
        logger.LogDebug("Meta-handler invocation started for interface {handlerName}", typeof(TInterface).Name);
        sw.Start();
        await OnEventCore(sender, args).ConfigureAwait(false);
        sw.Stop();
        logger.LogDebug("Finished calling of {count} handlers in {elapsed}", registrations.Length, sw.Elapsed);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private Task OnEventCore(DiscordClient sender, TArgument args)
    {
#if para
        return Parallel.ForEachAsync(registrations, (key, _) => new(OnEventSingle(sender, key, args)));
#else
        Task[] tasks = new Task[registrations.Length];
        Parallel.For(0, registrations.Length, i => tasks[i] = OnEventSingle(sender, registrations[i], args));
        return Task.WhenAll(tasks);
#endif
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private async Task OnEventSingle(DiscordClient sender, Guid key, TArgument args)
    {
        try
        {
            await using AsyncServiceScope scope = provider.CreateAsyncScope();
            TInterface handler = scope.ServiceProvider.GetRequiredKeyedService<TInterface>(key);
            await using DisposingWrapper wrapper = new(handler);
            await Invoke(handler, sender, args);
        }
        catch (Exception ex)
        {
            logger.LogWarning(ex, "A problem occured while handling event with {EventName} with handler ID {HandlerName}", typeof(TInterface).Name, key);
            throw;
        }
    }

    protected abstract void BindHandler(DiscordShardedClient client, AsyncEventHandler<DiscordClient, TArgument> handler);
    protected abstract void UnbindHandler(DiscordShardedClient client, AsyncEventHandler<DiscordClient, TArgument> handler);

    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    protected abstract ValueTask Invoke(TInterface handler, DiscordClient sender, TArgument args);
}
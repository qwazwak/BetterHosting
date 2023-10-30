﻿using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;
using DSharpPlus.AsyncEvents;
using DSharpPlus.EventArgs;
using DSharpPlus.EventsNext.Entities;
using DSharpPlus.EventsNext.Tools.Internal;
using DSharpPlus.EventsNext.BetterHosting.Options.Internal;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using DSharpPlus.BetterHosting.Services.Hosted;
using DSharpPlus.BetterHosting.Services;

namespace DSharpPlus.EventsNext.BetterHosting.Services.Hosted;

internal class EventHandlerManager<THandler, TArgument> : IDiscordBackgroundService
    where THandler : IDiscordEventHandler<TArgument>
    where TArgument : DiscordEventArgs
{
    private readonly ILogger<EventHandlerManager<THandler, TArgument>> logger;
    protected readonly DiscordConfiguration discordConfig;
    protected readonly HandlerRegistryOptions<THandler> registry;
    private readonly IServiceProvider provider;
    private DiscordShardedClient client = null!;

    public EventHandlerManager(ILogger<EventHandlerManager<THandler, TArgument>> logger, IOptions<DiscordConfiguration> discordConfig, HandlerRegistryOptions<THandler> registry, [FromKeyedServices(NamedServices.RootServiceProvider)] IServiceProvider provider)
    {
        this.logger = logger;
        this.discordConfig = discordConfig.Value;
        this.registry = registry;
        this.provider = provider;
    }

    public Task AfterConnected(DiscordShardedClient client, CancellationToken stoppingToken)
    {
        Debug.Assert(this.client == null);
        if (!CanBeTriggered(client))
        {
            logger.LogInformation("Events for handlers {HandlerType} were declared to not happen, so exiting quick", typeof(THandler).Name);
            return Task.CompletedTask;
        }
        else
        {
            this.client = client;
            return Run(stoppingToken);
        }
    }

    private async Task Run(CancellationToken stoppingToken)
    {
        Debug.Assert(client != null);
        try
        {
            Setup();
            await Task.Delay(Timeout.Infinite, stoppingToken);
        }
        finally
        {
            TearDown();
            SetBindingState(false);
        }
    }

    private void Setup()
    {
        Stopwatch sw = new();
        logger.LogTrace("Setting up event handler");
        sw.Start();
        SetBindingState(true);
        sw.Stop();
        logger.LogInformation("Finished event handler setup in {time}", sw.Elapsed);
    }

    private void TearDown()
    {
        Stopwatch sw = new();
        logger.LogTrace("Tearing down event handler");
        sw.Start();
        SetBindingState(false);
        sw.Stop();
        logger.LogInformation("Finished event handler teardown in {time}", sw.Elapsed);
    }

    protected virtual bool CanBeTriggered(DiscordShardedClient client) => registry.Registrations.Count != 0;

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
            BindHandler(client, HandlerMethod);
        else
            UnbindHandler(client, HandlerMethod);

        sw.Stop();
        logger.LogDebug("Finished binding change in {time}", sw.Elapsed);
    }

    private AsyncEventHandler<DiscordClient, TArgument> HandlerMethod => logger.IsEnabled(LogLevel.Debug) ? OnEventLoggingWrapper : OnEventCore;
    private async Task OnEventLoggingWrapper(DiscordClient sender, TArgument args)
    {
        Stopwatch sw = new();
        logger.LogDebug("Meta-handler invocation started for interface {handlerName}", typeof(THandler).Name);
        sw.Start();
        await OnEventCore(sender, args);
        sw.Stop();
        int count = registry.Registrations.Count;
        logger.LogDebug("Finished calling of {count} handlers in {elapsed}", count, sw.Elapsed);
    }
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private Task OnEventCore(DiscordClient sender, TArgument args)
    {
        return Parallel.ForEachAsync(registry.Registrations, async (handlerRegistration, cancellationToken) =>
        {
            using IServiceScope scope = this.provider.CreateScope();
            IServiceProvider provider = scope.ServiceProvider;
            {
                THandler handler = provider.GetRequiredKeyedService<THandler>(handlerRegistration.Key);
                if (cancellationToken.IsCancellationRequested)
                {
                    logger.LogDebug("Cancellation requested, skipping invocation of event handler");
                    return;
                }

                try
                {
                    await Invoke(handler, sender, args);
                }
                catch (Exception ex)
                {
                    logger.LogError(ex, "A problem occured while handling event with {EventName} with handler: {HandlerName}", typeof(THandler).Name, handler.GetType().Name);
                    throw;
                }
            }
        });
    }

    protected virtual void BindHandler(DiscordShardedClient client, AsyncEventHandler<DiscordClient, TArgument> handler)
        => EventHandlerReflector.BindEvent<THandler, TArgument>(client, HandlerMethod);
    protected virtual void UnbindHandler(DiscordShardedClient client, AsyncEventHandler<DiscordClient, TArgument> handler)
        => EventHandlerReflector.UnbindEvent<THandler, TArgument>(client, HandlerMethod);

    protected virtual ValueTask Invoke(THandler handler, DiscordClient sender, TArgument args)
        => EventHandlerReflector.AutoCallEventHandler<THandler, TArgument>(handler, sender, args);
}
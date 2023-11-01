using DSharpPlus.EventsNext.BetterHosting.Services;
using Microsoft.Extensions.DependencyInjection;
using DSharpPlus.BetterHosting;
using DSharpPlus.EventsNext.Entities;
using DSharpPlus.EventArgs;
using System;
using DSharpPlus.EventsNext.BetterHosting.Services.Hosted;
using DSharpPlus.EventsNext.BetterHosting.Services.Configuration;

namespace DSharpPlus.EventsNext.BetterHosting;

/// <summary>
/// The entry point to add <see cref="EventsNext"/>
/// </summary>
public static partial class EventsNextBetterHostExtensions
{
    private static partial void AddAllHostedHandlers(IServiceCollection services);

    private static void AddHostedHandler<THandler, TArgument, TImplementation>(this IServiceCollection services)
        where THandler : IDiscordEventHandler<TArgument>
        where TArgument : DiscordEventArgs
        where TImplementation : EventHandlerManager<THandler, TArgument>
    {
        if (typeof(TImplementation) == typeof(EventHandlerManager<THandler, TArgument>))
            throw new ArgumentException($"{nameof(TImplementation)} ({typeof(TImplementation).Name}) must be derived from {nameof(EventHandlerManager<THandler, TArgument>)} and not exactly equal");

        services.AddSimpleHostedDiscordService<TImplementation>();
    }
    /// <summary>
    /// Adds the EventsNext extension to the <see cref="IServiceCollection"/> with the default configuration path "EventsNextConfiguration"
    /// </summary>
    /// <param name="services"></param>
    /// <returns>The same <see cref="IServiceCollection"/> for chaining</returns>
    public static IServiceCollection AddEventsNext(this IServiceCollection services) => services.AddEventsNext(nameof(EventsNextConfiguration));

    private static IServiceCollection AddEventsNext(this IServiceCollection services, string EventsNextConfigKey)
    {
        services.AddConfigurator<EventsNextSetup>();
        services.AddOptions<EventsNextConfiguration>().BindConfiguration(EventsNextConfigKey);
        AddAllHostedHandlers(services);
        return services;
    }

    /// <summary>
    /// Adds a configuration provider to the <see cref="IServiceCollection"/>
    /// </summary>
    /// <typeparam name="TConfigurator">The <see cref="IEventsNextConfigurator"/> implementation</typeparam>
    /// <param name="services"></param>
    /// <returns>The same <see cref="IServiceCollection"/> for chaining</returns>
    public static IServiceCollection AddEventsNextConfigurator<TConfigurator>(this IServiceCollection services) where TConfigurator : class, IEventsNextConfigurator => services.AddTransient<IEventsNextConfigurator, TConfigurator>();
}

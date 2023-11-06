using Microsoft.Extensions.DependencyInjection;
using DSharpPlus.BetterHosting.EventsNext.Services;
using DSharpPlus.EventArgs;
using DSharpPlus.BetterHosting.EventsNext.Services.Implementations;

namespace DSharpPlus.BetterHosting.EventsNext;

/// <summary>
/// The entry point to add <see cref="EventsNext"/>
/// </summary>
public static partial class EventsNextBetterHostExtensions
{
    private static partial void AddAllHostedHandlers(IServiceCollection services);

    private static IServiceCollection AddHostedHandlerCore<TManager, TEventInterface, TArgument>(this IServiceCollection services)
        where TManager : EventHandlerManager<TEventInterface, TArgument>
        where TEventInterface : IDiscordEventHandler<TArgument>
        where TArgument : DiscordEventArgs
    {
        services.AddSingleton(new HandlerRegistryOptions<TEventInterface>());
        services.AddSingleton<TManager>();
        services.AddHostedService<EventsNextBackgroundHost<TManager>>();
        return services;
    }

    /// <summary>
    /// Adds the EventsNext extension to the <see cref="IServiceCollection"/> with the default configuration path "EventsNextConfiguration"
    /// </summary>
    /// <param name="services"></param>
    /// <returns>The same <see cref="IServiceCollection"/> for chaining</returns>
    public static IServiceCollection AddEventsNext(this IServiceCollection services)
    {
        AddAllHostedHandlers(services);
        return services;
    }
}

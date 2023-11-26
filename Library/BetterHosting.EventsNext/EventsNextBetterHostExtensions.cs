using System;
using BetterHosting.EventsNext.Services;
using BetterHosting.EventsNext.Services.Implementations;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace BetterHosting.EventsNext;

/// <summary>
/// The entry point to add <see cref="EventsNext"/>
/// </summary>
public static class EventsNextBetterHostExtensions
{
    /// <summary>
    /// Adds the EventsNext extension to the <see cref="IServiceCollection"/> with the default configuration path "EventsNextConfiguration"
    /// </summary>
    /// <param name="services"></param>
    /// <returns>The same <see cref="IServiceCollection"/> for chaining</returns>
    public static IServiceCollection AddEventsNext(this IServiceCollection services)
    {
        ArgumentNullException.ThrowIfNull(services);
        services.TryAddSingleton(typeof(IHandlerProvider<>), typeof(HandlerProvider<>));
        return services;
    }
}
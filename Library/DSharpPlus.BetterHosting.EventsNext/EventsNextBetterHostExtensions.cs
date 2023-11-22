using System;
using DSharpPlus.BetterHosting.EventsNext.Services;
using DSharpPlus.BetterHosting.EventsNext.Services.Implementations;
using DSharpPlus.BetterHosting.EventsNext.Tools;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace DSharpPlus.BetterHosting.EventsNext;

/// <summary>
/// The entry point to add <see cref="EventsNext"/>
/// </summary>
public static partial class EventsNextBetterHostExtensions
{
    /// <summary>
    /// Adds the EventsNext extension to the <see cref="IServiceCollection"/> with the default configuration path "EventsNextConfiguration"
    /// </summary>
    /// <param name="services"></param>
    /// <returns>The same <see cref="IServiceCollection"/> for chaining</returns>
    public static IServiceCollection AddEventsNext(this IServiceCollection services)
    {
        ArgumentNullException.ThrowIfNull(services);
        services.TryAddTransient(typeof(IHandlerRegistryKeyProvider<>), typeof(HandlerRegistryKeyProvider<>));
        EventReflection.AllDetails(out System.Collections.Generic.IEnumerable<EventReflection.DetailsRecord>? details);
        foreach (EventReflection.DetailsRecord detail in details)
        {
            services.TryAdd(ServiceDescriptor.Singleton(serviceType: typeof(IHandlerRegistry<>).MakeGenericType(detail.EventInterface), implementationInstance: Activator.CreateInstance(typeof(HandlerRegistry<>).MakeGenericType(detail.EventInterface))!));
            Helpers.AddEventManager(services, detail);
        }
        return services;
    }
}
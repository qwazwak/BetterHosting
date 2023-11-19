using Microsoft.Extensions.DependencyInjection;

namespace DSharpPlus.BetterHosting.EventsNext;

/// <summary>
/// The entry point to add <see cref="EventsNext"/>
/// </summary>
public static class EventsNextBetterHostExtensions
{
    /// <summary>
    /// Adds the EventsNext extension to the <see cref="IServiceCollection"/> with the default configuration path "EventsNextConfiguration"
    /// </summary>
    /// <remarks>
    /// Although currently a NOP, it is reccomended to call this as it may do more in the future</remarks>
    /// <param name="services"></param>
    /// <returns>The same <see cref="IServiceCollection"/> for chaining</returns>
    public static IServiceCollection AddEventsNext(this IServiceCollection services) => services;
}
using DSharpPlus.EventsNext.BetterHosting.Services;
using Microsoft.Extensions.DependencyInjection;
using DSharpPlus.BetterHosting;
using DSharpPlus.EventsNext.Entities;
using DSharpPlus.EventArgs;
using System;
using DSharpPlus.EventsNext.BetterHosting.Services.Hosted;
using DSharpPlus.EventsNext.BetterHosting.Services.Configuration;

namespace DSharpPlus.EventsNext.BetterHosting;

public static partial class EventsNextBetterHostExtensions
{
    private static partial void AddAllHostedHandlers(IServiceCollection services);
    private static void AddHostedHandler<THandler, TArgument, TImplementation>(this IServiceCollection services)
        where THandler : IDiscordEventHandler<TArgument>
        where TArgument : DiscordEventArgs
        where TImplementation : EventHandlerManager<THandler, TArgument>
    {
        if (typeof(TImplementation) == typeof(EventHandlerManager<THandler, TArgument>))
        {
            Console.Out.WriteLine($"{typeof(TImplementation).Name} is not a supported type, good luck!");
            //?????
        }
        services.AddHostedDiscordService<TImplementation>();
    }
    public static IServiceCollection AddEventsNext(this IServiceCollection services) => services.AddEventsNext(nameof(EventsNextConfiguration));
    public static IServiceCollection AddEventsNext(this IServiceCollection services, string EventsNextConfigKey)
    {
        services.AddConfigurator<EventsNextSetup>();
        services.AddOptions<EventsNextConfiguration>().BindConfiguration(EventsNextConfigKey);
        AddAllHostedHandlers(services);
        return services;
    }

    public static IServiceCollection AddEventsNextConfigurator<TConfigurator>(this IServiceCollection services) where TConfigurator : class, IEventsNextConfigurator => services.AddTransient<IEventsNextConfigurator, TConfigurator>();
}

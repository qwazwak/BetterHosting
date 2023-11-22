using DSharpPlus.BetterHosting.EventsNext.Tools;
using System;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using DSharpPlus.BetterHosting.EventsNext.Services.Implementations;
using Microsoft.Extensions.DependencyInjection.Extensions;
using DSharpPlus.BetterHosting.EventsNext.Services;

namespace DSharpPlus.BetterHosting.EventsNext;

public static partial class EventsNextBetterHostExtensions
{
    //Internal for testing
    internal static class Helpers
    {
        public static void AddEventManagers(IServiceCollection services)
        {
            foreach (EventReflection.DetailsRecord detail in EventReflection.AllDetails)
                AddEventManager(services, detail);
        }

        private static void AddEventManager(IServiceCollection services, EventReflection.DetailsRecord detail)
        {
            Type manager = CreateEventManager(detail);
            services.TryAddKeyedSingleton(service: typeof(IEventHandlerManager), serviceKey: detail.EventInterface, implementationType: manager);

            services.AddSingleton(typeof(IHostedService), typeof(EventsNextBackgroundHost<>).MakeGenericType(detail.EventInterface));
        }

        private static Type CreateEventManager(EventReflection.DetailsRecord detail) => typeof(AutoCallEventHandlerManager<,>).MakeGenericType(detail.EventInterface, detail.ArgumentType);
    }
}
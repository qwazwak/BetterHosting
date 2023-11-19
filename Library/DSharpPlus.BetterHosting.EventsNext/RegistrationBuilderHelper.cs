using DSharpPlus.BetterHosting.EventsNext.Services;
using Microsoft.Extensions.DependencyInjection;
using DSharpPlus.BetterHosting.EventsNext.Services.Implementations;
using DSharpPlus.BetterHosting.EventsNext.Tools;
using Microsoft.Extensions.Hosting;
using System;

namespace DSharpPlus.BetterHosting.EventsNext;

internal static class RegistrationBuilderHelper
{
    public static HandlerRegistry<TInterface> GetHandlerRegistration<TInterface>(IServiceCollection services) where TInterface : IDiscordEventHandler
    {
        if (services.TryGet(out HandlerRegistry<TInterface>? instance))
            return instance;

        HandlerRegistry<TInterface> registryInstance = new();
        Type managerType = EventReflection.Managers.For<TInterface>();
        services.AddSingleton(registryInstance);
        services.AddSingleton(managerType);
        services.AddSingleton(typeof(IHostedService), typeof(EventsNextBackgroundHost<>).MakeGenericType(managerType));
        return registryInstance;
    }
}
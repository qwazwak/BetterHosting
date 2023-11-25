using DSharpPlus.BetterHosting.EventsNext.Services.Implementations;
using DSharpPlus.BetterHosting.EventsNext.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using DSharpPlus.BetterHosting.EventsNext.Tools;
using System.Diagnostics;
using DSharpPlus.BetterHosting.EventsNext.Entities;

namespace DSharpPlus.BetterHosting.EventsNext;

internal static class RegistrationBuilderHelper
{
    public static void RegisterHandler(IServiceCollection services, Type eventInterface, HandlerDescriptor descriptor, bool supportKnownAdded = false)
    {
        Debug.Assert(services != null);
        Debug.Assert(eventInterface != null);
        Debug.Assert(descriptor != null);

        IHandlerRegistry registry;
        if (SingletonServiceCheater.TryGet(services, key: eventInterface, out IHandlerRegistry? existing))
        {
            registry = existing;
        }
        else
        {
            registry = new HandlerRegistry();
            services.AddKeyedSingleton(serviceKey: eventInterface, implementationInstance: registry);
            if (!supportKnownAdded)
                AddHandlerSupport(services, eventInterface);
        }

        registry.Add(descriptor);
    }

    //internal for testing - treat as private
    internal static void AddHandlerSupport(IServiceCollection services, Type eventInterface)
    {
        services.AddKeyedSingleton(serviceType: typeof(IEventHandlerManager), serviceKey: eventInterface, implementationType: EventReflection.ManagerType.For(eventInterface));
        
        services.AddSingleton(typeof(IHostedService), EventReflection.ManagerHostType.For(eventInterface));
    }
}
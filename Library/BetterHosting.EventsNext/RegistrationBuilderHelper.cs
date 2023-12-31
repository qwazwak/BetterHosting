﻿using BetterHosting.EventsNext.Services.Implementations;
using BetterHosting.EventsNext.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using BetterHosting.EventsNext.Tools;
using System.Diagnostics;
using BetterHosting.EventsNext.Entities;

namespace BetterHosting.EventsNext;

internal static class RegistrationBuilderHelper
{
    public static void RegisterHandler(IServiceCollection services, Type eventInterface, HandlerDescriptor descriptor)
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
            services.AddKeyedSingleton(serviceType: typeof(IEventHandlerManager), serviceKey: eventInterface, implementationType: EventReflection.ManagerType.For(eventInterface));
            services.AddSingleton(typeof(IHostedService), EventReflection.ManagerHostType.For(eventInterface));
        }

        registry.Add(descriptor);
    }
}
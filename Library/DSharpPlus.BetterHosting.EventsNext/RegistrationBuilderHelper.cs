using DSharpPlus.BetterHosting.EventsNext.Services.Implementations;
using DSharpPlus.BetterHosting.EventsNext.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using DSharpPlus.BetterHosting.EventsNext.Tools;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace DSharpPlus.BetterHosting.EventsNext;

internal static class RegistrationBuilderHelper
{
    public static bool CanAddService(IServiceCollection services, Type serviceType, object? serviceKey)
    {
        ArgumentNullException.ThrowIfNull(services);
        ArgumentNullException.ThrowIfNull(serviceType);

        int count = services.Count;
        for (int i = 0; i < count; i++)
        {
            ServiceDescriptor service = services[i];
            if (service.ServiceType == serviceType && service.ServiceKey == serviceKey)
            {
                // Already added
                return false;
            }
        }

        return true;
    }
    public static void TryAddHandlerSupport<TEventInterface>(IServiceCollection services)
    {
        Type managerType = typeof(AutoCallEventHandlerManager<,>).MakeGenericType(typeof(TEventInterface), EventReflection.ArgumentType.For(typeof(TEventInterface)));
        services.TryAddKeyedSingleton(service: typeof(IEventHandlerManager), serviceKey: typeof(TEventInterface), implementationType: managerType);
        services.AddSingleton(typeof(IHostedService), typeof(EventsNextBackgroundHost<TEventInterface>));
    }
}
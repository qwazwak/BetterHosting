using DSharpPlus.BetterHosting.EventsNext.Services;
using System;
using Microsoft.Extensions.DependencyInjection;
using DSharpPlus.BetterHosting.Tools.Extensions.Internal;
using DSharpPlus.BetterHosting.EventsNext.Services.Implementations;

namespace DSharpPlus.BetterHosting.EventsNext;

internal static class RegistrationBuilderHelper
{
    public static HandlerRegistryOptions<TInterface> GetHandlerRegistration<TInterface>(IServiceCollection serviceDescriptors) where TInterface : IDiscordEventHandler
    {
        ArgumentNullException.ThrowIfNull(serviceDescriptors);
        return serviceDescriptors.GetOrAddSingleton<HandlerRegistryOptions<TInterface>>();
    }

    public static HandlerRegistryOptions GetHandlerRegistration(IServiceCollection serviceDescriptors, Type interfaceType)
    {
        ArgumentNullException.ThrowIfNull(serviceDescriptors);
        Type registryType = typeof(HandlerRegistryOptions<>).MakeGenericType(interfaceType);
        return (HandlerRegistryOptions)serviceDescriptors.GetOrAddSingleton(registryType, () => Activator.CreateInstance(registryType)!);
    }
}
using DSharpPlus.BetterHosting.EventsNext.Services;
using System;
using Microsoft.Extensions.DependencyInjection;
using DSharpPlus.BetterHosting.Tools.Extensions.Internal;
using DSharpPlus.BetterHosting.EventsNext.Services.Implementations;

namespace DSharpPlus.BetterHosting.EventsNext;

internal static class RegistrationBuilderHelper
{
    public static HandlerRegistry<TInterface> GetHandlerRegistration<TInterface>(IServiceCollection serviceDescriptors) where TInterface : IDiscordEventHandler
    {
        ArgumentNullException.ThrowIfNull(serviceDescriptors);
        return serviceDescriptors.GetOrAddSingleton<HandlerRegistry<TInterface>>();
    }
}
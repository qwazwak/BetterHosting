using DSharpPlus.EventsNext.Entities;
using DSharpPlus.EventsNext.BetterHosting.Options.Internal;
using System;
using Microsoft.Extensions.DependencyInjection;
using DSharpPlus.BetterHosting.Tools.Extensions.Internal;

namespace DSharpPlus.EventsNext.BetterHosting;

internal static class RegistrationBuilderHelper
{
#if false
    public static HandlerRegistryOptions GetHandlerRegistration(IHostBuilder context, Type interfaceType)
    {
        Dictionary<Type, object> registrationDict = GetHandlerRegistrationDict(context.Properties);
        if (!registrationDict.TryGetValue(interfaceType, out object? obj))
        {
            HandlerRegistryOptions registry = HandlerRegistryOptions.CreateByType(interfaceType);
            registrationDict.Add(interfaceType, registry);
            return registry;
        }

        if (obj is not HandlerRegistryOptions cast)
            throw new InvalidOperationException("HandlerRegistryOptions<TInterface> was replaced with an invalid object!");
        return cast;
    }
    public static HandlerRegistryOptions<TInterface> GetHandlerRegistration<TInterface>(IDictionary<object, object> properties) where TInterface : IDiscordEventHandler
    {
        Dictionary<Type, object> registrationDict = GetHandlerRegistrationDict(properties);
        if (!registrationDict.TryGetValue(typeof(TInterface), out object? obj))
        {
            HandlerRegistryOptions<TInterface> registry = new();
            registrationDict.Add(typeof(TInterface), registry);
            return registry;
        }

        if (obj is not HandlerRegistryOptions<TInterface> cast)
            throw new InvalidOperationException("HandlerRegistryOptions<TInterface> was replaced with an invalid object!");
        return cast;
    }
    public static HandlerRegistryOptions<TInterface> GetHandlerRegistration<TInterface>(IDictionary<Type, object> registrationDict) where TInterface : IDiscordEventHandler
    {
        if (!registrationDict.TryGetValue(typeof(TInterface), out object? obj))
        {
            HandlerRegistryOptions<TInterface> registry = new();
            registrationDict.Add(typeof(TInterface), registry);
            return registry;
        }

        if (obj is not HandlerRegistryOptions<TInterface> cast)
            throw new InvalidOperationException("HandlerRegistryOptions<TInterface> was replaced with an invalid object!");
        return cast;
    }
    public static Dictionary<Type, object> GetHandlerRegistrationDict(IDictionary<object, object> properties)
    {
        const string DictionaryKey = "wefuohewfsvgfdvesyndfghdfgdfg";
        if (!properties.TryGetValue(DictionaryKey, out object? obj))
        {
            Dictionary<Type, object> dict = new();
            properties.Add(DictionaryKey, dict);
            return dict;
        }

        if (obj is not Dictionary<Type, object> cast)
            throw new InvalidOperationException("HandlerRegistrationDict was replaced with an invalid object!");
        return cast;
    }
#endif
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

#if false

internal sealed class HandlerRegistryContainer
{
    private Dictionary<Type, HandlerRegistryOptions> registrationsDict = new();

    public HandlerRegistryOptions GetHandlerRegistration(Type interfaceType) => GetHandlerRegistrationCore<HandlerRegistryOptions>(interfaceType, () => HandlerRegistryOptions.CreateByType(interfaceType));

    public HandlerRegistryOptions<TInterface> GetHandlerRegistration<TInterface>() where TInterface : IDiscordEventHandler => GetHandlerRegistrationCore<HandlerRegistryOptions<TInterface>>(typeof(TInterface), () => new());

    private TRegistry GetHandlerRegistrationCore<TRegistry>(Type interfaceType, Func<TRegistry> createNew) where TRegistry : HandlerRegistryOptions
    {
        if (registrationsDict.TryGetValue(interfaceType, out HandlerRegistryOptions? existing))
        {
            if (existing is not TRegistry cast)
                throw new InvalidOperationException("HandlerRegistryOptions<TInterface> was replaced with an invalid object!");
            return cast;
        }

        TRegistry registry = createNew();
        registrationsDict.Add(interfaceType, registry);
        return registry;
    }
}

#endif
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;

namespace DSharpPlus.BetterHosting.EventsNext.Tools;

internal static class SingletonServiceCheater
{
#if false
    public static T GetOrAddSingleton<T>(IServiceCollection services, object? key, Func<T> factory) where T : class
    {
        if (TryGet(services, key, out T? instance))
            return instance;

        T newInstance = factory.Invoke();
        if(key == null)
            services.AddSingleton(typeof(T), newInstance);
        else
            services.AddKeyedSingleton(typeof(T), key, newInstance);
        return newInstance;
    }
#endif

    public static bool TryGet<T>(IServiceCollection services, object? key, [NotNullWhen(true), MaybeNullWhen(false)] out T? instance) where T : class => TryGet(services, key, out instance, out Exception? _);

    private static bool TryGet<T>(IServiceCollection services, object? key, [NotNullWhen(true), MaybeNullWhen(false)] out T? instance, [NotNullWhen(false), MaybeNullWhen(true)] out Exception exception) where T : class
    {
        if (!TryGet(services, typeof(T), key, out object? objInstance, out exception))
        {
            instance = default!;
            return false;
        }

        if (objInstance is not T cast || cast is null)
        {
            instance = default!;
            exception = new InvalidOperationException("Existing descriptor could not be used");
            return false;
        }

        instance = cast;
        return true;
    }

    private static bool TryGet(IServiceCollection services, Type serviceType, object? key, [NotNullWhen(true), MaybeNullWhen(false)] out object? instance, [NotNullWhen(false), MaybeNullWhen(true)] out Exception exception)
    {
        int count = services.Count;
        ServiceDescriptor? descriptor = null;
        bool expectKey = key != null;
        for (int i = 0; i < count; i++)
        {
            ServiceDescriptor? d = services[i];
            if (d.ServiceType == serviceType && d.IsKeyedService == expectKey && (expectKey ? d.KeyedImplementationInstance : d.ImplementationInstance) != null)
            {
                descriptor = d;
                break;
            }
        }

        if (descriptor == null)
        {
            instance = null;
            exception = new InvalidOperationException($"Singleton for \"{serviceType.Name}\" was not in the service collection");
            return false;
        }

        instance = expectKey ? descriptor.KeyedImplementationInstance : descriptor.ImplementationInstance;
        Debug.Assert(instance is not null);
        exception = null;
        return true;
    }
}
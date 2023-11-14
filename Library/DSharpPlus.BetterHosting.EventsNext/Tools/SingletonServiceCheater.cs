using Microsoft.Extensions.DependencyInjection;
using System;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

namespace DSharpPlus.BetterHosting.EventsNext.Tools;

internal static class SingletonServiceCheater
{
    public static T GetSingleton<T>(this IServiceCollection services) where T : class
    {
        if (!TryGet<T>(services, out T? instance, out Exception? ex))
            throw ex;
        return instance;
    }
    public static bool TryGet<T>(this IServiceCollection services, [NotNullWhen(true), MaybeNullWhen(false)] out T instance) where T : class => TryGet(services, out instance, out Exception? _);

    public static T GetOrAddSingleton<T>(this IServiceCollection services, Func<T> factory) where T : class
    {
        if (TryGet<T>(services, out T? instance))
            return instance;

        T newInstance = factory.Invoke();
        services.AddSingleton(typeof(T), newInstance);
        return newInstance;
    }

    private static bool TryGet<T>(this IServiceCollection services, [NotNullWhen(true), MaybeNullWhen(false)] out T instance, [NotNullWhen(false), MaybeNullWhen(true)] out Exception exception) where T : class
    {
        ServiceDescriptor? descriptor = services.FirstOrDefault(Matches);
        static bool Matches(ServiceDescriptor descriptor) => descriptor.ServiceType == typeof(T) && !descriptor.IsKeyedService && descriptor.ImplementationInstance != null;

        if (descriptor == null)
        {
            instance = null;
            exception = new InvalidOperationException($"Singleton for \"{typeof(T).Name}\" was not in the service collection");
            return false;
        }

        if (descriptor.ImplementationInstance is not T cast || cast is null)
        {
            instance = null;
            exception = new InvalidOperationException("Existing descriptor could not be used");
            return false;
        }

        instance = cast;
        exception = null;
        return true;
    }
}
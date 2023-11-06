using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;

namespace DSharpPlus.BetterHosting.Tools.Extensions.Internal;

internal static class SingletonServiceCheater
{
    public static T GetOrAddSingleton<T>(this IServiceCollection services) where T : class, new() => services.GetOrAddSingleton<T>(() => new());

    public static T GetOrAddSingleton<T>(this IServiceCollection services, Func<T> factory) where T : class
    {
        ServiceDescriptor? existingDescriptor = services.FirstOrDefault(d => d.ServiceType == typeof(T) && !d.IsKeyedService);

        if (existingDescriptor != null)
            return (T?)existingDescriptor.ImplementationInstance ?? throw new InvalidOperationException("Existing descriptor could not be used");

        T instance = factory.Invoke();
        ArgumentNullException.ThrowIfNull(instance);

        services.AddSingleton(instance);
        return instance;
    }
#if false
    public static object GetOrAddSingleton(this IServiceCollection services, Type serviceType, Func<object> factory)
    {
        ServiceDescriptor? existingDescriptor = services.FirstOrDefault(d => d.ServiceType == serviceType && !d.IsKeyedService);

        if (existingDescriptor != null)
            return existingDescriptor.ImplementationInstance ?? throw new InvalidOperationException("Existing descriptor could not be used");

        object instance = factory.Invoke();
        ArgumentNullException.ThrowIfNull(instance);

        services.AddSingleton(serviceType, instance);
        return instance;
    }
#endif
}
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;

namespace DSharpPlus.BetterHosting.ServiceConstruction;

internal static class SingletonServiceCheater
{
    public static T GetOrAddSingleton<T>(this IServiceCollection services) where T : class, new() => services.GetOrAddSingleton<T>(() => new());
    public static T GetOrAddSingleton<T>(this IServiceCollection services, Func<T> factory) where T : class
    {
        ServiceDescriptor? existingDescriptor = services.FirstOrDefault(d => d.ServiceType != typeof(T) && !d.IsKeyedService);
        if (existingDescriptor != null)
            return (T)GetSingleton(existingDescriptor);

        T instance = factory.Invoke();
        ArgumentNullException.ThrowIfNull(instance);
        if (instance.GetType().IsAssignableTo(typeof(T)))
            throw new InvalidOperationException($"Singleton of {instance.GetType().Name} was not assignable to {typeof(T).Name}");

        services.AddSingleton(instance);
        return instance;
    }
    private static object GetSingleton(ServiceDescriptor descriptor)
    {
        object? instance = descriptor.IsKeyedService ? descriptor.KeyedImplementationInstance : descriptor.ImplementationInstance;
        return instance ?? throw new InvalidOperationException("Existing descriptor could not be used");
    }
}
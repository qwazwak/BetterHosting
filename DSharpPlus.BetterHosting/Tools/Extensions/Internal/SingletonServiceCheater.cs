using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;

namespace DSharpPlus.BetterHosting.Tools.Extensions.Internal;

internal static class SingletonServiceCheater
{
    public static T GetOrAddSingleton<T>(this IServiceCollection services) where T : class, new() => (T)services.GetOrAddSingleton(typeof(T), () => new());

    public static T GetOrAddSingleton<T>(this IServiceCollection services, Func<T> factory) where T : class => (T)services.GetOrAddSingleton(typeof(T), () => factory());
    public static object GetOrAddSingleton(this IServiceCollection services, Type singletonType, Func<object> factory)
    {
        ServiceDescriptor? existingDescriptor = services.FirstOrDefault(d => d.ServiceType == singletonType && !d.IsKeyedService);
        if (existingDescriptor != null)
            return GetSingleton(existingDescriptor);

        object? instance = factory.Invoke();
        ArgumentNullException.ThrowIfNull(instance);
        if (instance.GetType().IsAssignableTo(singletonType))
            throw new InvalidOperationException($"Singleton of {instance.GetType().Name} was not assignable to {singletonType.Name}");

        services.AddSingleton(singletonType, instance);
        return instance;
    }

    private static object GetSingleton(ServiceDescriptor descriptor)
    {
        object? instance = descriptor.IsKeyedService ? descriptor.KeyedImplementationInstance : descriptor.ImplementationInstance;
        return instance ?? throw new InvalidOperationException("Existing descriptor could not be used");
    }
}
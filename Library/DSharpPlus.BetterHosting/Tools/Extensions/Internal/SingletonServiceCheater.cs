using Microsoft.Extensions.DependencyInjection;
using System;
using System.Diagnostics.CodeAnalysis;

namespace DSharpPlus.BetterHosting.Tools.Extensions.Internal;

internal static class SingletonServiceCheater
{
    public static T GetOrAddSingleton<T>(this IServiceCollection services) where T : class, new() => services.GetOrAddSingleton<T>([ExcludeFromCodeCoverage] () => new());
    public static T GetOrAddSingleton<T>(this IServiceCollection services, Func<T> factory) where T : class => (T)services.GetOrAddSingleton(typeof(T), () => factory());

    private static bool TryFindDescriptor(IServiceCollection services, Type servicetype, [NotNullWhen(true), MaybeNullWhen(false)] out ServiceDescriptor existingDescriptor)
    {
        foreach (ServiceDescriptor descriptor in services)
        {
            if (descriptor.ServiceType == servicetype && !descriptor.IsKeyedService && descriptor.ImplementationInstance != null)
            {
                existingDescriptor = descriptor;
                return true;
            }
        }
        existingDescriptor = null;
        return false;
    }

    private static object GetOrAddSingleton(this IServiceCollection services, Type singletonType, Func<object> factory)
    {
        if (TryFindDescriptor(services, singletonType, out ServiceDescriptor? existingDescriptor))
            return existingDescriptor.ImplementationInstance ?? throw new InvalidOperationException("Existing descriptor could not be used");

        object instance = factory.Invoke();
        services.AddSingleton(singletonType, instance);
        return instance;
    }
}
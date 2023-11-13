using Microsoft.Extensions.DependencyInjection;
using System;
using System.Diagnostics.CodeAnalysis;

namespace DSharpPlus.BetterHosting.EventsNext.Tools;

internal static class SingletonServiceCheater
{
    public static T GetSingleton<T>(this IServiceCollection services) where T : class => (T)services.GetSingleton(typeof(T));

    private static bool TryFindDescriptor(IServiceCollection services, Type servicetype, [NotNullWhen(true), MaybeNullWhen(false)] out ServiceDescriptor existingDescriptor)
    {
        int count = services.Count;
        for (int i = 0; i < count; i++)
        {
            if (services[i].ServiceType == servicetype && !services[i].IsKeyedService && services[i].ImplementationInstance != null)
            {
                existingDescriptor = services[i];
                return true;
            }
        }
        existingDescriptor = null;
        return false;
    }

    private static object GetSingleton(this IServiceCollection services, Type singletonType)
    {
        if (!TryFindDescriptor(services, singletonType, out ServiceDescriptor? existingDescriptor))
            throw new InvalidOperationException($"Singleton for \"{singletonType.Name}\" was not in the service collection");

        return existingDescriptor.ImplementationInstance ?? throw new InvalidOperationException("Existing descriptor could not be used");
    }
}
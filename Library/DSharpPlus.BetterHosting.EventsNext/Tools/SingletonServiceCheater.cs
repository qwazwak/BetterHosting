using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;

namespace DSharpPlus.BetterHosting.EventsNext.Tools;

internal static class SingletonServiceCheater
{
    public static T GetSingleton<T>(this IServiceCollection services) where T : class
    {
        ServiceDescriptor descriptor = services.FirstOrDefault(Matches) ?? throw new InvalidOperationException($"Singleton for \"{typeof(T).Name}\" was not in the service collection");

        return descriptor.ImplementationInstance as T ?? throw new InvalidOperationException("Existing descriptor could not be used");

        static bool Matches(ServiceDescriptor descriptor) => descriptor.ServiceType == typeof(T) && !descriptor.IsKeyedService && descriptor.ImplementationInstance != null;
    }
}
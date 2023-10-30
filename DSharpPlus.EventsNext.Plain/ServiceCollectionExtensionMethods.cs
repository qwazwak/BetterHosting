using System;
using System.Collections.Generic;
using System.Reflection;
using DSharpPlus.EventsNext.Tools;
using Microsoft.Extensions.DependencyInjection;

namespace DSharpPlus.EventsNext.Plain;

public static class ServiceCollectionExtensionMethods
{
    public static void AddEventsNextHandlers(this IServiceCollection services, IEnumerable<Type> types)
    {
        ArgumentNullException.ThrowIfNull(types);
        foreach (Type type in types)
            services.AddEventsNextHandler(type);
    }
    public static void AddAllEventsNextHandlers(this IServiceCollection services) => services.AddEventsNextHandlers(Assembly.GetExecutingAssembly());
    public static void AddEventsNextHandlers(this IServiceCollection services, Assembly fromAssembly)
    {
        ArgumentNullException.ThrowIfNull(fromAssembly);
        services.AddEventsNextHandlers(HandlerExtractor.GetHandlerTypes(fromAssembly));
    }
    public static void AddEventsNextHandler(this IServiceCollection services, Type implementationType)
    {
        ArgumentNullException.ThrowIfNull(services);
        services.AddTransient(implementationType);
    }
}

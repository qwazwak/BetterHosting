using System;
using System.Linq;
using DSharpPlus.BetterHosting.EventsNext.Entities;
using DSharpPlus.BetterHosting.EventsNext.Services;
using DSharpPlus.BetterHosting.EventsNext.Tools;
using Microsoft.Extensions.DependencyInjection;

namespace DSharpPlus.BetterHosting.EventsNext;

/// <summary>
/// Extensions to <see cref="IServiceCollection"/> for registering <see cref="IDiscordEventHandler{TArgs}"/>
/// </summary>
public static partial class RegistrationExtensions
{
    /// <summary>
    /// Gets a builder that forwards handler addition calls for the same <typeparamref name="TInterface"/> to the underlying service collection.
    /// </summary>
    /// <typeparam name="TInterface">The <see cref="IDiscordEventHandler"/> type to be configured.</typeparam>
    /// <param name="services">The <see cref="IServiceCollection"/> to add the services to.</param>
    /// <returns>The <see cref="RegistrationBuilder{TInterface}"/> so that handler addition calls can be chained in it.</returns>
    public static RegistrationBuilder<TInterface> AddEventHandlers<TInterface>(this IServiceCollection services) where TInterface : class, IDiscordEventHandler => new(services);

    /// <summary>
    /// Registers the handler <typeparamref name="TImplementation"/> in the <see cref="IServiceCollection"/> to recieve events for all supported interfaces
    /// </summary>
    /// <typeparam name="TImplementation"></typeparam>
    /// <returns>The same <see cref="IServiceCollection"/> for chaining</returns>
#if SourceGenerated_AutoRegisterHandler
    public static partial IServiceCollection AutoRegisterHandler<TImplementation>(this IServiceCollection services) where TImplementation : class, IDiscordEventHandler;

#else
    public static IServiceCollection AutoRegisterHandler<TImplementation>(this IServiceCollection services) where TImplementation : class, IDiscordEventHandler
    {
        foreach (Type implementedExactInterface in typeof(TImplementation).GetInterfaces().Where(EventReflection.Validation.IsExactInterface))
            RegistrationBuilderHelper.RegisterHandler(services, implementedExactInterface, HandlerDescriptor.Describe(implementedExactInterface, typeof(TImplementation)), false);
        return services;
    }
#endif
}
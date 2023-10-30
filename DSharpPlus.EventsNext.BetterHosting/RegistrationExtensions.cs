using DSharpPlus.EventsNext.Entities;
using Microsoft.Extensions.DependencyInjection;

namespace DSharpPlus.EventsNext.BetterHosting;

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
}
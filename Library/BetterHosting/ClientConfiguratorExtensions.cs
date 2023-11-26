using Microsoft.Extensions.DependencyInjection;
using System;
using BetterHosting.Services.Interfaces;
using BetterHosting.Services.Implementation.Extensions;
using BetterHosting.Services.Interfaces.Extensions;
using DSharpPlus;

namespace BetterHosting;

/// <summary>
/// Extensions to add various functions through <see cref="IDiscordClientConfigurator"/>
/// </summary>
public static class ClientConfiguratorExtensions
{
    /// <summary>
    /// Registers <typeparamref name="TConfigurator"/> as a <see cref="IDiscordClientConfigurator"/> which will be run before the client connects
    /// </summary>
    /// <typeparam name="TConfigurator"></typeparam>
    /// <param name="services"></param>
    /// <returns>The same <paramref name="services"/> for chaining</returns>
    public static IServiceCollection AddConfigurator<TConfigurator>(this IServiceCollection services) where TConfigurator : class, IDiscordClientConfigurator => services.AddTransient<IDiscordClientConfigurator, TConfigurator>();

    /// <summary>
    /// Registers <typeparamref name="TConfigurator"/> as a <see cref=" IDiscordExtensionConfigurator{TExtension}"/> which will be run to configure the <typeparamref name="TExtension"/> before discord connects
    /// </summary>
    /// <typeparam name="TConfigurator"></typeparam>
    /// <typeparam name="TExtension"></typeparam>
    /// <param name="services"></param>
    /// <returns>The same <paramref name="services"/> for chaining</returns>
    public static IServiceCollection AddExtensionConfigurator<TConfigurator, TExtension>(this IServiceCollection services) where TConfigurator : class, IDiscordExtensionConfigurator<TExtension> where TExtension : BaseExtension => services.AddTransient<IDiscordExtensionConfigurator<TExtension>, TConfigurator>();

    /// <summary>
    /// Registers a service to configure the <typeparamref name="TExtension"/> with the <paramref name="configurationDelegate"/>
    /// </summary>
    /// <typeparam name="TExtension"></typeparam>
    /// <param name="services"></param>
    /// <param name="configurationDelegate"></param>
    /// <returns>The same <paramref name="services"/> for chaining</returns>
    public static IServiceCollection ConfigureExtension<TExtension>(this IServiceCollection services, Action<int, TExtension> configurationDelegate) where TExtension : BaseExtension
    {
        ArgumentNullException.ThrowIfNull(configurationDelegate);
        return services.AddSingleton<IDiscordExtensionConfigurator<TExtension>>(new ExtensionConfigureDelegate<TExtension>(configurationDelegate));
    }

    /// <summary>
    /// Registers A <see cref="DiscordExtensionConfiguratorAdapter{TSpecific, TExtension}"/> as a <see cref="IDiscordExtensionConfigurator{TExtension}"/> which provide all registered instances of <typeparamref name="TSpecific"/> as a <see cref=" IDiscordExtensionConfigurator{TExtension}"/>
    /// </summary>
    /// <typeparam name="TSpecific">The derived <see cref="IDiscordExtensionConfigurator{TExtension}"/> </typeparam>
    /// <typeparam name="TExtension"></typeparam>
    /// <param name="services"></param>
    /// <returns>The same <paramref name="services"/> for chaining</returns>
    public static IServiceCollection AddExtensionConfiguratorAdapter<TSpecific, TExtension>(this IServiceCollection services) where TSpecific : class, IDiscordExtensionConfigurator<TExtension> where TExtension : BaseExtension => services.AddExtensionConfigurator<DiscordExtensionConfiguratorAdapter<TSpecific, TExtension>, TExtension>();
}
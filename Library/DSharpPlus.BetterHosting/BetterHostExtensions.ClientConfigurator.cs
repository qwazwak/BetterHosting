using Microsoft.Extensions.DependencyInjection;
using System;
using DSharpPlus.BetterHosting.Services.Implementation.ExtensionConfigurators;
using System.Diagnostics.CodeAnalysis;
using DSharpPlus.BetterHosting.Services.Implementation;
using DSharpPlus.BetterHosting.Services.Interfaces.ExtensionConfigurators;

namespace DSharpPlus.BetterHosting;

public static partial class BetterHostExtensions
{
    /// <summary>
    /// Registers <typeparamref name="TService"/> as a <see cref="IDiscordClientConfigurator"/> which will be run before the client connects
    /// </summary>
    /// <typeparam name="TService"></typeparam>
    /// <param name="services"></param>
    /// <returns>The same <paramref name="services"/> for chaining</returns>
    public static IServiceCollection AddConfigurator<TService>(this IServiceCollection services) where TService : class, IDiscordClientConfigurator => services.AddTransient<IDiscordClientConfigurator, TService>();

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
    public static IServiceCollection ConfigureExtension<TExtension>(this IServiceCollection services, Action<TExtension> configurationDelegate) where TExtension : BaseExtension => services.AddTransient<IDiscordExtensionConfigurator<TExtension>>([ExcludeFromCodeCoverage(Justification = CoveCoverageExclusionReasons.LambdaWrapper)] (_) => new ExtensionConfigureDelegate<TExtension>(configurationDelegate));

    /// <summary>
    /// Registers A <see cref="DiscordExtensionConfiguratorAdapter{TSpecific, TExtension}"/> as a <see cref="IDiscordExtensionConfigurator{TExtension}"/> which provide all registered instances of <typeparamref name="TSpecific"/> as a <see cref=" IDiscordExtensionConfigurator{TExtension}"/>
    /// </summary>
    /// <typeparam name="TSpecific">The derived <see cref="IDiscordExtensionConfigurator{TExtension}"/> </typeparam>
    /// <typeparam name="TExtension"></typeparam>
    /// <param name="services"></param>
    /// <returns>The same <paramref name="services"/> for chaining</returns>
    public static IServiceCollection AddExtensionConfiguratorAdapter<TSpecific, TExtension>(this IServiceCollection services) where TSpecific : class, IDiscordExtensionConfigurator<TExtension> where TExtension : BaseExtension => services.AddExtensionConfigurator<DiscordExtensionConfiguratorAdapter<TSpecific, TExtension>, TExtension>();
}
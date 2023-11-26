using System;
using DSharpPlus.Lavalink;
using Microsoft.Extensions.DependencyInjection;
using BetterHosting.Lavalink.Services.Implementations;
using BetterHosting.Lavalink.Services.Hosted;
using Microsoft.Extensions.Options;
using Microsoft.Extensions.Configuration;
using BetterHosting.Lavalink.Services;
using System.Diagnostics.CodeAnalysis;
using BetterHosting.Services.Interfaces;

namespace BetterHosting.Lavalink;

/// <summary>
/// Extension methods and adding and configuring <see cref="DSharpPlus.Lavalink"/> to <see cref="BetterHosting"/>
/// </summary>
public static class BetterLavalinkHostExtensions
{
    /// <summary>
    /// Entry point to add <see cref="DSharpPlus.Lavalink"/> to <see cref="BetterHosting"/>
    /// </summary>
    /// <param name="services"></param>
    /// <returns>The same <see cref="IServiceCollection"/> for chaining</returns>
    public static IServiceCollection AddLavalink(this IServiceCollection services)
    {
        services.AddHostedDiscordService<LavalinkBackgroundService>();
        services.AddTransient<IDiscordClientConfigurator, LavalinkSetup>();
        services.AddExtensionConfiguratorAdapter<ILavalinkConfigurator, LavalinkExtension>();
        return services;
    }

    /// <summary>
    /// Registers a <see cref="IOptions{TOptions}"/> which will use the provided <paramref name="config"/>
    /// </summary>
    public static OptionsBuilder<LavalinkConfiguration> AddLavalinkConfig(this IServiceCollection services, LavalinkConfiguration config)
    {
        ArgumentNullException.ThrowIfNull(config);
        return services.AddSingleton(Microsoft.Extensions.Options.Options.Create(config)).AddOptions<LavalinkConfiguration>();
    }

    /// <summary>
    /// Registers the dependency injection container to bind <see cref="LavalinkConfiguration"/> against
    /// the <see cref="IConfiguration"/> obtained from the DI service provider.
    /// </summary>
    /// <param name="configSectionPath">The name of the configuration section to bind from.</param>
    /// <returns>The <see cref="OptionsBuilder{TOptions}"/> so that additional calls can be chained.</returns>
    /// <exception cref="ArgumentNullException">
    /// <paramref name="services"/> or <paramref name="configSectionPath" /> is <see langword="null"/>.
    /// </exception>
    /// <seealso cref="OptionsBuilderConfigurationExtensions.Bind{TOptions}(OptionsBuilder{TOptions}, IConfiguration, Action{BinderOptions})"/>
    [ExcludeFromCodeCoverage(Justification = CoveCoverageExclusionReasons.SimpleWrapperExtension)]
    public static OptionsBuilder<LavalinkConfiguration> AddLavalinkConfig(this IServiceCollection services, string configSectionPath) => services.AddOptions<LavalinkConfiguration>().BindConfiguration(configSectionPath, [ExcludeFromCodeCoverage(Justification = CoveCoverageExclusionReasons.LambdaWrapper)] (o) => o.BindNonPublicProperties = true);
}
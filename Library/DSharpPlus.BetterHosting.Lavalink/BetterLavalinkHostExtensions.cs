using System;
using DSharpPlus.BetterHosting.Services.Interfaces.ExtensionConfigurators;
using DSharpPlus.Lavalink;
using Microsoft.Extensions.DependencyInjection;
using DSharpPlus.BetterHosting.Lavalink.Services.Implementations;
using DSharpPlus.BetterHosting.Lavalink.Services.Hosted;
using Microsoft.Extensions.Options;
using Microsoft.Extensions.Configuration;
using DSharpPlus.BetterHosting.Services.Implementation;

namespace DSharpPlus.BetterHosting.Lavalink;

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
        return services
            .AddHostedDiscordService<LavalinkBackgroundService>()
            .AddTransient<IDiscordClientConfigurator, LavalinkSetup>();
    }

    /// <summary>
    /// Registers a <see cref="IOptions{TOptions}"/> which will use the provided <paramref name="config"/>
    /// </summary>
    public static OptionsBuilder<LavalinkConfiguration> AddLavalinkConfig(this IServiceCollection services, LavalinkConfiguration config) => services.AddSingleton(Microsoft.Extensions.Options.Options.Create(config)).AddOptions<LavalinkConfiguration>();

    /// <summary>
    /// Registers a <see cref="IOptions{TOptions}"/> which will be laziliy initialized with <see cref="ConfigurationProvider"/>
    /// </summary>
    public static OptionsBuilder<LavalinkConfiguration> AddLavalinkConfig(this IServiceCollection services, Func<LavalinkConfiguration> configProvider) => services.AddSingleton<IOptions<LavalinkConfiguration>>(new LazyOptionsWrapper<LavalinkConfiguration>(configProvider)).AddOptions<LavalinkConfiguration>();

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
    public static OptionsBuilder<LavalinkConfiguration> AddLavalinkConfig(this IServiceCollection services, string configSectionPath ) => services.AddOptions<LavalinkConfiguration>().BindConfiguration(configSectionPath, o => o.BindNonPublicProperties = true);
}
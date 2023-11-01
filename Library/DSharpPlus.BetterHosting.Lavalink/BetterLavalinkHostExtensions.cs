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

public static class BetterLavalinkHostExtensions
{
    public static OptionsBuilder<LavalinkConfiguration> AddLavalink(this IServiceCollection services, LavalinkConfiguration options) => services.AddLavalink().AddLavalinkConfig(options);
    public static OptionsBuilder<LavalinkConfiguration> AddLavalink(this IServiceCollection services, Func<LavalinkConfiguration> optionsFactory) => services.AddLavalink().AddLavalinkConfig(optionsFactory);
    // <param name="configSectionPath">The name of the configuration section to bind from.</param>
    public static OptionsBuilder<LavalinkConfiguration> AddLavalink(this IServiceCollection services, string configSectionPath = nameof(LavalinkConfiguration)) => services.AddLavalink().AddLavalinkConfig(configSectionPath);

    private static IServiceCollection AddLavalink(this IServiceCollection services)
    {
        return services
            .AddSimpleHostedDiscordService<LavalinkBackgroundService>()
            .AddTransient<IDiscordClientConfigurator, LavalinkSetup>();
    }

    private static OptionsBuilder<LavalinkConfiguration> AddLavalinkConfig(this IServiceCollection services, LavalinkConfiguration config) => services.AddSingleton(Microsoft.Extensions.Options.Options.Create(config)).AddOptions<LavalinkConfiguration>();
    private static OptionsBuilder<LavalinkConfiguration> AddLavalinkConfig(this IServiceCollection services, Func<LavalinkConfiguration> configProvider) => services.AddSingleton<IOptions<LavalinkConfiguration>>(new LazyOptionsWrapper<LavalinkConfiguration>(configProvider)).AddOptions<LavalinkConfiguration>();

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
    public static OptionsBuilder<LavalinkConfiguration> AddLavalinkConfig(this IServiceCollection services, string configSectionPath = nameof(LavalinkConfiguration)) => services.AddOptions<LavalinkConfiguration>().BindConfiguration(configSectionPath);
}
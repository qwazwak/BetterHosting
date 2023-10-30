using System;
using DSharpPlus.BetterHosting.Services.Interfaces.ExtensionConfigurators;
using DSharpPlus.Lavalink;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using DSharpPlus.BetterHosting.Lavalink.Services.Implementations;
using DSharpPlus.BetterHosting.Lavalink.Services.Hosted;
using Microsoft.Extensions.Options;
using DSharpPlus.BetterHosting.CommandsNext.Options;

namespace DSharpPlus.BetterHosting.Lavalink;

public static class BetterLavalinkHostExtensions
{
    public static IServiceCollection AddLavalink(this IServiceCollection services, LavalinkConfiguration options) => services.AddLavalink().AddLavalinkConfig(options);
    public static IServiceCollection AddLavalink(this IServiceCollection services, Func<LavalinkConfiguration> optionsFactory) => services.AddLavalink().AddLavalinkConfig(optionsFactory);
    public static IServiceCollection AddLavalink(this IServiceCollection services, string optionsKey = nameof(LavalinkConfiguration), Action<LavalinkConfiguration>? configureOptions = null) => services.AddLavalink().AddLavalinkConfig(optionsKey, configureOptions);

    private static IServiceCollection AddLavalink(this IServiceCollection services)
    {
        return services
            .AddHostedDiscordService<LavalinkBackgroundService>()
            .AddTransient<IDiscordClientConfigurator, LavalinkSetup>();
    }

    private static IServiceCollection AddLavalinkConfig(this IServiceCollection services, LavalinkConfiguration config)
    {
        services.RemoveLavalinkOptions();
        return services.AddSingleton(Microsoft.Extensions.Options.Options.Create(config));
    }

    private static IServiceCollection AddLavalinkConfig(this IServiceCollection services, string configurationKey, Action<LavalinkConfiguration>? configureOptions = null)
    {
        services.RemoveLavalinkOptions();

        OptionsBuilder<LavalinkConfiguration> options = services.AddOptions<LavalinkConfiguration>().BindWorkaround(configurationKey);
        if (configureOptions is not null)
            services.Configure(configureOptions);
        return services;
    }

    private static IServiceCollection AddLavalinkConfig(this IServiceCollection services, Func<LavalinkConfiguration> configProvider)
    {
        services.RemoveLavalinkOptions();
        return services.AddSingleton<IOptions<LavalinkConfiguration>>(new DelayedInvocationProvider(configProvider));
    }

    private static void RemoveLavalinkOptions(this IServiceCollection services)
    {
        services.RemoveAll<IOptions<LavalinkConfiguration>>();
        services.RemoveAll<IConfigureOptions<LavalinkConfiguration>>();
    }
}
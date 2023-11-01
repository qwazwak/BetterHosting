using DSharpPlus.BetterHosting.Services.Interfaces.ExtensionConfigurators;
using DSharpPlus.BetterHosting.VoiceNext.Services.Configuration;
using DSharpPlus.VoiceNext;
using Microsoft.Extensions.DependencyInjection;

namespace DSharpPlus.BetterHosting.VoiceNext;

/// <summary>
/// The entry point to add <see cref="VoiceNext"/>
/// </summary>
public static class BetterHostingVoiceNextExtensions
{
    /// <summary>
    /// Adds a <see cref="IDiscordClientConfigurator"/> which will add <see cref="VoiceNextExtension"/> to the Discord client
    /// </summary>
    /// <param name="services"></param>
    /// <returns>The same <see cref="IServiceCollection"/> for chaining</returns>
    public static IServiceCollection AddVoiceNext(this IServiceCollection services) => services.AddTransient<IDiscordClientConfigurator, VoiceNextSetup>();
}
/*
public static class BetterHostingVoiceNextExtensions
{
    public static IServiceCollection AddVoiceNext(this IServiceCollection services, VoiceNextConfiguration options)
    {
        ArgumentNullException.ThrowIfNull(services);
        ArgumentNullException.ThrowIfNull(options);
        services.AddVoiceNext().AddVoiceNextConfig(options);
        return services;
    }

    public static IServiceCollection AddVoiceNextWithOptions(this IServiceCollection services, string optionsKey = nameof(VoiceNextConfiguration))
    {
        services.AddVoiceNext().AddVoiceNextConfig(optionsKey);
        return services;
    }

    public static IServiceCollection AddVoiceNextWithOptions(this IServiceCollection services, string optionsKey, Action<VoiceNextConfiguration> configureOptions)
    {
        services.AddVoiceNext().AddVoiceNextConfig(optionsKey).Configure(configureOptions);
        return services;
    }
}*/
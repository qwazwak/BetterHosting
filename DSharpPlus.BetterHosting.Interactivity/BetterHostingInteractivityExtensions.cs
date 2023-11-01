using System;
using DSharpPlus.BetterHosting.Services.Interfaces.ExtensionConfigurators;
using DSharpPlus.BetterHosting.Interactivity.Services.Configuration;
using DSharpPlus.Interactivity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace DSharpPlus.BetterHosting.Interactivity;
public static class BetterHostingInteractivityExtensions
{
    /// <summary>
    /// Adds automatic setup of <see cref="InteractivityExtension"/>
    /// </summary>
    /// <param name="services"></param>
    /// <returns>The same <see cref="IServiceCollection"/> for chaining</returns>
    public static IServiceCollection AddInteractivity(this IServiceCollection services) => services.AddTransient<IDiscordClientConfigurator, InteractivitySetup>();

    public static OptionsBuilder<InteractivityConfiguration> AddInteractivityConfig(this IServiceCollection services, InteractivityConfiguration config)
    {
        ArgumentNullException.ThrowIfNull(config);
        return services.AddSingleton(Microsoft.Extensions.Options.Options.Create(config)).AddOptions<InteractivityConfiguration>();
    }

    public static OptionsBuilder<InteractivityConfiguration> AddInteractivityConfig(this IServiceCollection services, string configurationKey)
    {
        ArgumentNullException.ThrowIfNull(configurationKey);
        return services.AddOptions<InteractivityConfiguration>().Configure<IConfiguration>((o, c) => InteractivityConfigurationBinder.BindValues(o, c.GetRequiredSection(configurationKey)));
    }
}
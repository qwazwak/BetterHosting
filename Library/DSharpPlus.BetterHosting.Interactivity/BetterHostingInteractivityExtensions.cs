using System;
using DSharpPlus.BetterHosting.Services.Interfaces.ExtensionConfigurators;
using DSharpPlus.Interactivity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using DSharpPlus.BetterHosting.Interactivity.Services;

namespace DSharpPlus.BetterHosting.Interactivity;

/// <summary>
/// Extension methods to add <see cref="InteractivityExtension"/> and <see cref="IOptions{TOptions}"/> for <see cref="InteractivityConfiguration"/>
/// </summary>
public static class BetterHostingInteractivityExtensions
{
    /// <summary>
    /// Adds automatic setup of <see cref="InteractivityExtension"/>
    /// </summary>
    /// <param name="services"></param>
    /// <returns>The same <see cref="IServiceCollection"/> for chaining</returns>
    public static IServiceCollection AddInteractivity(this IServiceCollection services)
    {
        ArgumentNullException.ThrowIfNull(services);
        return services.AddTransient<IDiscordClientConfigurator, InteractivitySetup>();
    }

    /// <summary>
    /// Adds an <see cref="IOptions{TOptions}">IOptions{InteractivityConfiguration}</see> which provides the input <paramref name="configuration"/> to the <see cref="IServiceCollection"/>
    /// </summary>
    /// <param name="services">The collection to add <paramref name="configuration"/> to</param>
    /// <param name="configuration">The configuration to use</param>
    /// <returns>The <see cref="OptionsBuilder{TOptions}"/> so that configure calls can be chained in it.</returns>
    public static OptionsBuilder<InteractivityConfiguration> AddInteractivityConfig(this IServiceCollection services, InteractivityConfiguration configuration)
    {
        ArgumentNullException.ThrowIfNull(services);
        ArgumentNullException.ThrowIfNull(configuration);
        InteractivityConfiguration copy = new(configuration);
        return services.AddSingleton(Microsoft.Extensions.Options.Options.Create(copy)).AddOptions<InteractivityConfiguration>();
    }

    /// <summary>
    /// Adds an <see cref="IOptions{TOptions}">IOptions{InteractivityConfiguration}</see> which will read from the <see cref="IConfiguration"/>to the <see cref="IServiceCollection"/>
    /// </summary>
    /// <param name="services">The collection to add the configuration to</param>
    /// <param name="configSectionPath">The name of the configuration section to bind from.</param>
    /// <returns>The <see cref="OptionsBuilder{TOptions}"/> so that configure calls can be chained in it.</returns>
    public static OptionsBuilder<InteractivityConfiguration> AddInteractivityConfig(this IServiceCollection services, string configSectionPath)
    {
        ArgumentNullException.ThrowIfNull(services);
        ArgumentNullException.ThrowIfNull(configSectionPath);
        return services.AddOptions<InteractivityConfiguration>().BindConfiguration(configSectionPath, opt => opt.BindNonPublicProperties = true);
    }
}
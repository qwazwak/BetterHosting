using System;
using DSharpPlus.BetterHosting.CommandsNext.Services;
using DSharpPlus.BetterHosting.CommandsNext.Services.Configuration;
using DSharpPlus.BetterHosting.Services.Implementation;
using DSharpPlus.BetterHosting.Services.Implementation.ExtensionConfigurators;
using DSharpPlus.BetterHosting.Services.Interfaces.ExtensionConfigurators;
using DSharpPlus.CommandsNext;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Options;

namespace DSharpPlus.BetterHosting.SlashCommands;

/// <summary>
/// Extension methods to add and configure <see cref="DSharpPlus.CommandsNext"/>
/// </summary>
public static partial class BetterHostingCommandsNextExtensions
{
    /// <summary>
    /// Entry point to add and configure <see cref="DSharpPlus.CommandsNext"/>
    /// </summary>
    public static IServiceCollection AddCommandsNext(this IServiceCollection services)
    {
        ArgumentNullException.ThrowIfNull(services);
        services.AddTransient<IConfigureOptions<CommandsNextConfiguration>, CommandsNextOptionConfigure>();
        services.TryAddTransient<ICommandsNextConfigurator, HandlerAdder>();

        services.AddTransient<IDiscordClientConfigurator, CommandsNextSetup>();
        return services;
    }

    /// <summary>
    /// Registers the dependency injection container to bind <see cref="CommandsNextConfiguration"/> against
    /// the <see cref="IConfiguration"/> obtained from the DI service provider.
    /// </summary>
    /// <param name="configSectionPath">The name of the configuration section to bind from.</param>
    /// <returns>The <see cref="OptionsBuilder{TOptions}"/> so that additional calls can be chained.</returns>
    /// <exception cref="ArgumentNullException">
    /// <paramref name="services"/> or <paramref name="configSectionPath" /> is <see langword="null"/>.
    /// </exception>
    /// <seealso cref="OptionsBuilderConfigurationExtensions.Bind{TOptions}(OptionsBuilder{TOptions}, IConfiguration, Action{BinderOptions})"/>
    public static OptionsBuilder<CommandsNextConfiguration> AddCommandsNextConfiguration(this IServiceCollection services, string configSectionPath)
    {
        ArgumentNullException.ThrowIfNull(services);
        return services.AddOptions<CommandsNextConfiguration>().BindConfiguration(configSectionPath, o => o.BindNonPublicProperties = true);
    }
}
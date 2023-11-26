using BetterHosting.Services.Interfaces;
using BetterHosting.SlashCommands.Services;
using BetterHosting.SlashCommands.Services.Configuration;
using BetterHosting.SlashCommands.Services.Implementation;
using DSharpPlus.SlashCommands;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace BetterHosting.SlashCommands;

/// <summary>
/// Extension methods for working and adding SlashCommands to an IServiceCollection
/// </summary>
public static class BetterHostingSlashCommandsExtensions
{
    /// <summary>
    /// Adds <see cref="SlashCommandsExtension"/> to the discord client and a <see cref="IOptions{SlashCommandsConfiguration}"/> for <see cref="SlashCommandsConfiguration"/>
    /// </summary>
    /// <param name="services"></param>
    /// <returns>The same <see cref="IServiceCollection"/> for chaining</returns>
    public static IServiceCollection AddSlashCommands(this IServiceCollection services)
        => services.AddTransient<IDiscordClientConfigurator, SlashCommandsSetup>()
        .AddTransient<IConfigureOptions<SlashCommandsConfiguration>, SlashCommandsOptionsConfiguration>()
        .AddExtensionConfiguratorAdapter<ISlashCommandsExtensionConfigurator, SlashCommandsExtension>();
}
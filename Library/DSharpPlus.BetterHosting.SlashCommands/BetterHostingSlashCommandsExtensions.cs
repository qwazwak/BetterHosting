using System;
using System.Collections.Generic;
using System.Reflection;
using System.Runtime.CompilerServices;
using DSharpPlus.BetterHosting.Services.Interfaces.ExtensionConfigurators;
using DSharpPlus.BetterHosting.SlashCommands.Services;
using DSharpPlus.BetterHosting.SlashCommands.Services.Configuration;
using DSharpPlus.BetterHosting.SlashCommands.Services.Implementation;
using DSharpPlus.SlashCommands;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace DSharpPlus.BetterHosting.SlashCommands;

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
    {
        services.AddTransient<IDiscordClientConfigurator, SlashCommandsSetup>();
        services.AddTransient<IConfigureOptions<SlashCommandsConfiguration>, SlashCommandsOptionsConfiguration>();
        return services;
    }

    /// <summary>
    /// Registers a configurator to register the <typeparamref name="TCommand"/> with <see cref="SlashCommands"/>
    /// </summary>
    /// <typeparam name="TCommand"></typeparam>
    /// <param name="services"></param>
    public static void RegisterSlashCommand<TCommand>(this IServiceCollection services) where TCommand : ApplicationCommandModule => services.AddTransient<ISlashCommandsExtensionConfigurator, SlashCommandRegisterConfigurator<TCommand>>();

    /// <summary>
    /// Registers a configurator to register all derivations of <see cref="ApplicationCommandModule"/> with <see cref="SlashCommands"/> from the calling assembly
    /// </summary>
    /// <param name="services"></param>
    [MethodImpl(MethodImplOptions.NoInlining | MethodImplOptions.NoOptimization)]
    public static void RegisterSlashCommands(this IServiceCollection services)
    {
        ArgumentNullException.ThrowIfNull(services);
        Assembly callingAssembly = Assembly.GetCallingAssembly();
        services.RegisterSlashCommandsCore(callingAssembly);
    }

    /// <summary>
    /// Registers a configurator to register all derivations of <see cref="ApplicationCommandModule"/> with <see cref="SlashCommands"/> from the given assembly
    /// </summary>
    /// <param name="services"></param>
    public static void RegisterSlashCommands(this IServiceCollection services, Assembly assembly)
    {
        ArgumentNullException.ThrowIfNull(services);
        ArgumentNullException.ThrowIfNull(assembly);
        services.RegisterSlashCommandsCore(assembly);
    }

    private static void RegisterSlashCommandsCore(this IServiceCollection services, Assembly assembly) => services.AddSingleton<ISlashCommandsExtensionConfigurator>(new SlashCommandsAutoRegisterConfigurator(assembly));
#if false
    public static void AddSlashCommand(this IServiceCollection services, Type commandType)
    {
        Type constructed = typeof(SlashCommandRegisterConfigurator<>).MakeGenericType(commandType);
        services.AddTransient(typeof(ISlashCommandsExtensionConfigurator), constructed);
    }
#endif
}
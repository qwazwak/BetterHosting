using System;
using System.Diagnostics.CodeAnalysis;
using System.Reflection;
using System.Runtime.CompilerServices;
using DSharpPlus.BetterHosting.SlashCommands.Services;
using DSharpPlus.SlashCommands;
using Microsoft.Extensions.DependencyInjection;

namespace DSharpPlus.BetterHosting.SlashCommands;

/// <summary>
/// Extension methods to register SlashCommands with the <see cref="IServiceCollection"/>
/// </summary>
public static class SlashCommandsRegistrationExtensions
{
    /// <summary>
    /// Registers a configurator to register the <typeparamref name="TCommand"/> with <see cref="SlashCommands"/>
    /// </summary>
    /// <typeparam name="TCommand"></typeparam>
    /// <param name="services"></param>
    /// <returns>The same <see cref="IServiceCollection"/> for chaining</returns>
    public static IServiceCollection RegisterSlashCommand<TCommand>(this IServiceCollection services) where TCommand : ApplicationCommandModule => services.AddTransient<ISlashCommandsExtensionConfigurator, SlashCommandRegisterConfigurator<TCommand>>();

    /// <summary>
    /// Registers a configurator to register all derivations of <see cref="ApplicationCommandModule"/> with <see cref="SlashCommands"/> from the calling assembly
    /// </summary>
    /// <param name="services"></param>
    /// <returns>The same <see cref="IServiceCollection"/> for chaining</returns>
    [MethodImpl(MethodImplOptions.NoInlining | MethodImplOptions.NoOptimization)]
    public static IServiceCollection RegisterSlashCommands(this IServiceCollection services)
    {
        Assembly callingAssembly = Assembly.GetCallingAssembly();
        return services.RegisterSlashCommands(callingAssembly);
    }

    /// <summary>
    /// Registers a configurator to register all derivations of <see cref="ApplicationCommandModule"/> with <see cref="SlashCommands"/> from the given assembly
    /// </summary>
    /// <param name="services"></param>
    /// <returns>The same <see cref="IServiceCollection"/> for chaining</returns>
    public static IServiceCollection RegisterSlashCommands(this IServiceCollection services, Assembly assembly)
    {
        ArgumentNullException.ThrowIfNull(assembly);
        return services.AddSingleton<ISlashCommandsExtensionConfigurator, SlashCommandsAutoRegisterConfigurator>([ExcludeFromCodeCoverage] (_) => new(assembly));
    }
}
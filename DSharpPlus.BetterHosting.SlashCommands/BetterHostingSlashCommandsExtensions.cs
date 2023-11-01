using System;
using System.Reflection;
using System.Runtime.CompilerServices;
using DSharpPlus.BetterHosting.Services;
using DSharpPlus.BetterHosting.Services.Interfaces.ExtensionConfigurators;
using DSharpPlus.BetterHosting.SlashCommands.Services;
using DSharpPlus.BetterHosting.SlashCommands.Services.Configuration;
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
        services.AddOptions<SlashCommandsConfiguration>()
            .Configure<IServiceProvider>((option, sp) => option.Services = sp.GetRequiredKeyedService<IServiceProvider>(NamedServices.RootServiceProvider));
        return services;
    }

    public static void RegisterSlashCommand<TCommand>(this IServiceCollection services) where TCommand : ApplicationCommandModule => services.AddTransient<ISlashCommandsExtensionConfigurator, SlashCommandRegisterConfigurator<TCommand>>();

    [MethodImpl(MethodImplOptions.NoInlining | MethodImplOptions.NoOptimization)]
    public static void RegisterSlashCommands(this IServiceCollection services)
    {
        ArgumentNullException.ThrowIfNull(services);
        Assembly callingAssembly = Assembly.GetCallingAssembly();
        services.RegisterSlashCommandsCore(callingAssembly);
    }

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
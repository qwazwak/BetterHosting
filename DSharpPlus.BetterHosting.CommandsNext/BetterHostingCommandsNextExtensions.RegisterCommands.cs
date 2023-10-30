using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using DSharpPlus.BetterHosting.CommandsNext.Internal;
using DSharpPlus.BetterHosting.CommandsNext.Services;
using DSharpPlus.BetterHosting.CommandsNext.Services.Configuration;
using DSharpPlus.CommandsNext;
using Microsoft.Extensions.DependencyInjection;

namespace DSharpPlus.BetterHosting.SlashCommands;

public static partial class BetterHostingCommandsNextExtensions
{
    /// <inheritdoc cref="CommandsNextExtension.RegisterCommands(Assembly)"/>
    public static IServiceCollection RegisterCommands(this IServiceCollection services, Assembly assembly)
    {
        ArgumentNullException.ThrowIfNull(services);
        ArgumentNullException.ThrowIfNull(assembly);
#if false
        services.GetOrAddSingleton<CommandsNextSetupItems>().HandlerAssemblies.Add(assembly);
        return services;
#else
        return services.AddTransient<ICommandsNextConfigurator, AssemblyHandlerAdder>(_ => new(assembly));
#endif
    }
    /// <inheritdoc cref="CommandsNextExtension.RegisterCommands{T}()"/>
    public static IServiceCollection RegisterCommand<T>(this IServiceCollection services) where T : BaseCommandModule => services.RegisterCommand(typeof(T));
    /// <inheritdoc cref="CommandsNextExtension.RegisterCommands(Type)"/>
    public static IServiceCollection RegisterCommand(this IServiceCollection services, Type t)
    {
        ArgumentNullException.ThrowIfNull(services);
        ArgumentNullException.ThrowIfNull(t);
#if false
        services.GetOrAddSingleton<CommandsNextSetupItems>().Handlers.Add(t);
        return services;
#else
        return services.AddTransient<ICommandsNextConfigurator, TypeHandlerAdder>(_ => new(t));
#endif
    }
    /// <inheritdoc cref="CommandsNextExtension.RegisterCommands(Type)"/>
    public static IServiceCollection RegisterCommands(this IServiceCollection services, params Type[] types)
    {
        ArgumentNullException.ThrowIfNull(services);
        ArgumentNullException.ThrowIfNull(types);
        if (types.Length == 0)
            return services;
        return services.RegisterCommands((IEnumerable<Type>)types);
    }
    /// <inheritdoc cref="CommandsNextExtension.RegisterCommands(Type)"/>
    public static IServiceCollection RegisterCommands(this IServiceCollection services, IEnumerable<Type> types)
    {
        ArgumentNullException.ThrowIfNull(services);
        ArgumentNullException.ThrowIfNull(types);
        List<Type> typesList = types.Select(t =>
        {
            ArgumentNullException.ThrowIfNull(t);
            CommandsNextReflector.Utilities.ThrowIfNotCanidate(t);
            return t;
        }).ToList();
        if (typesList.Count == 0)
            return services;
#if false
        services.GetOrAddSingleton<CommandsNextSetupItems>().Handlers.AddRange(typesList);
        return services;
#else
        return services.AddTransient<ICommandsNextConfigurator, TypeHandlerAdder>(_ => new(types));
#endif
    }
}
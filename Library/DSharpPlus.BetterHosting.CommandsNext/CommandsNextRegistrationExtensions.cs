using System;
using System.Collections.Generic;
using System.Reflection;
using DSharpPlus.BetterHosting.CommandsNext.Internal;
using DSharpPlus.BetterHosting.CommandsNext.Services;
using DSharpPlus.BetterHosting.CommandsNext.Services.Configuration;
using DSharpPlus.CommandsNext;
using Microsoft.Extensions.DependencyInjection;

namespace DSharpPlus.BetterHosting.SlashCommands;

/// <summary>
/// Extension methods to register SlashCommands (deriving from <see cref="BaseCommandModule"/>)
/// </summary>
public static class CommandsNextRegistrationExtensions
{
    /// <inheritdoc cref="CommandsNextExtension.RegisterCommands(Assembly)"/>
    public static IServiceCollection RegisterCommands(this IServiceCollection services, Assembly assembly)
    {
        ArgumentNullException.ThrowIfNull(assembly);
        return services.AddTransient<ICommandsNextConfigurator, AssemblyHandlerAdder>(_ => new(assembly));
    }

    /// <inheritdoc cref="CommandsNextExtension.RegisterCommands{T}()"/>
    public static IServiceCollection RegisterCommand<T>(this IServiceCollection services) where T : BaseCommandModule => services.RegisterCommand(typeof(T));

    /// <inheritdoc cref="CommandsNextExtension.RegisterCommands(Type)"/>
    public static IServiceCollection RegisterCommand(this IServiceCollection services, Type t)
    {
        ArgumentNullException.ThrowIfNull(t);
        return services.AddTransient<ICommandsNextConfigurator, TypeHandlerAdder>(_ => new(t));
    }

    /// <inheritdoc cref="CommandsNextExtension.RegisterCommands(Type)"/>
    public static IServiceCollection RegisterCommands(this IServiceCollection services, params Type[] types)
    {
        ArgumentNullException.ThrowIfNull(types);
        if (types.Length != 0)
            services.RegisterCommands((IEnumerable<Type>)types);
        return services;
    }

    /// <inheritdoc cref="CommandsNextExtension.RegisterCommands(Type)"/>
    public static IServiceCollection RegisterCommands(this IServiceCollection services, IEnumerable<Type> types)
    {
        ArgumentNullException.ThrowIfNull(types);
        List<Type> typesList = new();

        foreach (Type t in types)
        {
            ArgumentNullException.ThrowIfNull(t);
            CommandsNextReflector.Utilities.ThrowIfNotCanidate(t);
            typesList.Add(t);

            services.AddTransient(t);
        }

        if (typesList.Count == 1)
            services.AddTransient<ICommandsNextConfigurator, TypeHandlerAdder>(_ => new(typesList[0]));
        else if (typesList.Count != 0)
            services.AddTransient<ICommandsNextConfigurator, TypeHandlerAdder>(_ => new(typesList));

        return services;
    }
}
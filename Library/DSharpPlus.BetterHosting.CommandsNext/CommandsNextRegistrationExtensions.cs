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
    /// <inheritdoc cref="CommandsNextExtension.RegisterCommands{T}()"/>
    public static IServiceCollection RegisterCommand<T>(this IServiceCollection services) where T : BaseCommandModule
        => services.AddTransient<T>().AddTransient<ICommandsNextConfigurator, TypeHandlerAdder<T>>();

    /// <inheritdoc cref="CommandsNextExtension.RegisterCommands(Type)"/>
    public static IServiceCollection RegisterCommand(this IServiceCollection services, Type t)
    {
        ArgumentNullException.ThrowIfNull(t);
        return services.AddTransient(t).AddTransient(typeof(ICommandsNextConfigurator), typeof(TypeHandlerAdder<>).MakeGenericType(t));
    }

    /// <inheritdoc cref="CommandsNextExtension.RegisterCommands(Assembly)"/>
    public static IServiceCollection RegisterCommands(this IServiceCollection services, Assembly assembly)
    {
        ArgumentNullException.ThrowIfNull(assembly);
        IEnumerable<Type> types = HandlerExtractor.GetCanidates(assembly);
        return services.RegisterCommands(types);
    }

    /// <inheritdoc cref="CommandsNextExtension.RegisterCommands(Type)"/>
    public static IServiceCollection RegisterCommands(this IServiceCollection services, IEnumerable<Type> types)
    {
        ArgumentNullException.ThrowIfNull(types);
        foreach (Type type in types)
            services.RegisterCommand(type);
        return services;
    }
}
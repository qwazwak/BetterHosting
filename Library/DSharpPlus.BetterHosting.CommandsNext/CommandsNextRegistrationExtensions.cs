using System;
using System.Collections.Generic;
using System.Reflection;
using DSharpPlus.BetterHosting.CommandsNext.Internal;
using DSharpPlus.BetterHosting.CommandsNext.Services;
using DSharpPlus.CommandsNext;
using Microsoft.Extensions.DependencyInjection;

namespace DSharpPlus.BetterHosting.SlashCommands;

/// <summary>
/// Extension methods to register SlashCommands (deriving from <see cref="BaseCommandModule"/>)
/// </summary>
public static class CommandsNextRegistrationExtensions
{
    /// <inheritdoc cref="CommandsNextExtension.RegisterCommands{T}()"/>
    public static IServiceCollection RegisterCommand<TCommand>(this IServiceCollection services) where TCommand : BaseCommandModule
    {
        HandlerExtractor.ThrowIfNotCanidate(typeof(TCommand));
        return services.AddTransient<TCommand>().AddTransient<ICommandsNextConfigurator, TypeHandlerAdder<TCommand>>();
    }

    /// <inheritdoc cref="CommandsNextExtension.RegisterCommands(Type)"/>
    public static IServiceCollection RegisterCommand(this IServiceCollection services, Type commandType)
    {
        ArgumentNullException.ThrowIfNull(commandType);
        HandlerExtractor.ThrowIfNotCanidate(commandType);
        return services.AddTransient(commandType).AddTransient(typeof(ICommandsNextConfigurator), typeof(TypeHandlerAdder<>).MakeGenericType(commandType));
    }

    /// <inheritdoc cref="CommandsNextExtension.RegisterCommands(Assembly)"/>
    public static IServiceCollection RegisterCommands(this IServiceCollection services, Assembly assembly)
    {
        ArgumentNullException.ThrowIfNull(assembly);
        IEnumerable<Type> types = HandlerExtractor.GetCanidates(assembly);
        return services.RegisterCommands(types);
    }

    /// <inheritdoc cref="CommandsNextExtension.RegisterCommands(Type)"/>
    public static IServiceCollection RegisterCommands(this IServiceCollection services, IEnumerable<Type> commandTypes)
    {
        ArgumentNullException.ThrowIfNull(commandTypes);
        foreach (Type type in commandTypes)
            services.RegisterCommand(type);
        return services;
    }
}
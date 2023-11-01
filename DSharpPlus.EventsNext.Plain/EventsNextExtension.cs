using System;
using System.Collections.Generic;
using System.Reflection;
using DSharpPlus.EventsNext.Entities;
using DSharpPlus.EventsNext.Tools;
using DSharpPlus.EventsNext.Plain.Tools;

namespace DSharpPlus.EventsNext.Plain;

/// <summary>
/// This is the class which handles command registration, management, and execution.
/// </summary>
public class EventsNextExtension : EventsNextExtensionBase
{
    protected readonly EventsNextConfiguration config;

    /// <summary>
    /// Gets the service provider this CommandsNext module was configured with.
    /// </summary>
    public IServiceProvider Provider => config.Services;

    private readonly HashSet<Type> eventHandlersToBind = new();

    internal EventsNextExtension(EventsNextConfiguration config) : base(config) { this.config = config; }

    #region DiscordClient Registration

    protected override void Setup(DiscordClient client)
    {
        base.Setup(client);
        EventBindingTools.BindAllHandlers(client, eventHandlersToBind);
    }

    #endregion

    #region Command Registration

    /// <summary>
    /// Binds all commands from a given assembly. The command classes need to be public to be considered for registration.
    /// </summary>
    /// <param name="assembly">Assembly to Bind commands from.</param>
    public void BindEventHandlers(Assembly assembly)
    {
        foreach (Type xt in HandlerExtractor.GetHandlerTypes(assembly))
            BindEventHandler(xt);
    }

    /// <summary>
    /// Binds all commands from a given command class.
    /// </summary>
    /// <typeparam name="T">Class which holds commands to Bind.</typeparam>
    public void BindEventHandler<T>() where T : class, IDiscordEventHandler => EventBindingTools.BindHandler<T>(Client);

    /// <summary>
    /// Binds all commands from a given command class.
    /// </summary>
    /// <param name="t">Type of the class which holds commands to Bind.</param>
    public void BindEventHandler(Type t) => EventBindingTools.BindHandler(Client, t);

    #endregion
}

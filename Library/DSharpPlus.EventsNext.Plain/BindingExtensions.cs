using System;
using System.Collections.Generic;
using System.Reflection;
using DSharpPlus.EventsNext.Entities;
using DSharpPlus.EventsNext.Tools;

namespace DSharpPlus.EventsNext.Plain;

public static class BindingExtensions
{
    //
    // Summary:
    //     Binds all commands from a given assembly. The command classes need to be
    //     public to be considered for registration.
    //
    // Parameters:
    //   extensions:
    //     Extensions to Bind commands on.
    //
    //   assembly:
    //     Assembly to Bind commands from.
    public static void BindHandlers(this IReadOnlyDictionary<int, EventsNextExtension> extensions, Assembly assembly)
    {
        foreach (EventsNextExtension value in extensions.Values)
            value.BindEventHandlers(assembly);
    }

    //
    // Summary:
    //     Binds all commands from a given command class.
    //
    // Parameters:
    //   extensions:
    //     Extensions to Bind commands on.
    //
    // Type parameters:
    //   T:
    //     Class which holds commands to Bind.
    public static void BindEventHandler<THandler>(this IReadOnlyDictionary<int, EventsNextExtension> extensions) where THandler : class, IDiscordEventHandler
    {
        HandlerVerification.VerifyValidHandlerCanidate(typeof(THandler));
        foreach (EventsNextExtension value in extensions.Values)
            value.BindEventHandler<THandler>();
    }

    //
    // Summary:
    //     Binds all commands from a given command class.
    //
    // Parameters:
    //   extensions:
    //     Extensions to Bind commands on.
    //
    //   t:
    //     Type of the class which holds commands to Bind.
    public static void BindEventHandler(this IReadOnlyDictionary<int, EventsNextExtension> extensions, Type t)
    {
        HandlerVerification.VerifyValidHandlerCanidate(t);
        foreach (EventsNextExtension value in extensions.Values)
            value.BindEventHandler(t);
    }
}

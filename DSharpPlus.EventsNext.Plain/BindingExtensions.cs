using System;
using System.Collections.Generic;
using System.Reflection;
using DSharpPlus.EventsNext.Entities;
using DSharpPlus.EventArgs;
using DSharpPlus.EventsNext.Tools;
using DSharpPlus.EventsNext;
using DSharpPlus.EventsNext.Plain;

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
    public static void BindEventHandler<T>(this IReadOnlyDictionary<int, EventsNextExtension> extensions) where T : class, IDiscordEventHandler
    {
        HandlerValidation.VerifyHandler(typeof(T));
        foreach (EventsNextExtension value in extensions.Values)
            value.BindEventHandler<T>();
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
        HandlerValidation.VerifyHandler(t);
        foreach (EventsNextExtension value in extensions.Values)
            value.BindEventHandler(t);
    }
}

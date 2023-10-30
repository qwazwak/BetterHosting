using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Linq;
using DSharpPlus.EventsNext.Entities;
using QLib.Extensions.Reflection;

namespace DSharpPlus.EventsNext.Tools;

public static partial class HandlerValidation
{
    private static partial HashSet<Type> InitHandlerInterfaces();
    public static readonly FrozenSet<Type> HandlerInterfaces = InitHandlerInterfaces().ToFrozenSet();

    public static void VerifyHandler(Type handler)
    {
        ArgumentNullException.ThrowIfNull(handler);
        if (!IsValidHandler(handler, out string reason))
            throw new ArgumentException(reason, nameof(handler));
    }

    public static bool IsValidHandler(Type handler) => IsValidHandler(handler, out string _);
    public static bool IsValidHandler(Type handler, out string reason)
    {
        ArgumentNullException.ThrowIfNull(handler);

        if (!handler.IsClass)
        {
            reason = $"Type {handler.Name} is not a class implementing {nameof(IDiscordEventHandler)}";
            return false;
        }

        if (handler.IsAbstract)
        {
            reason = $"Type {handler.Name} is abstract, which is not allowed";
            return false;
        }

        if (!handler.IsAssignableTo(typeof(IDiscordEventHandler)))
        {
            reason = $"Type {handler.Name} is not a {nameof(IDiscordEventHandler)}";
            return false;
        }

        if (!handler.GetInterfaces().Any(i => i.IsGenericType && i.GetGenericTypeDefinition() == typeof(IDiscordEventHandler<>)))
        {
            reason = $"Type {handler.Name}, although it implements {typeof(IDiscordEventHandler).FullName}, does not implement a specific event handler";
            return false;
        }

#if false
        if (handler.IsNested)
        {
            reason = $"Type {handler.Name} is nested, which is not allowed";
            return false;
        }
#endif

        if (!HandlerInterfaces.Contains(handler))
        {
            reason = "Handler is not one of the derived handler interfaces";
            return false;
        }

        reason = string.Empty;
        return true;
    }
}

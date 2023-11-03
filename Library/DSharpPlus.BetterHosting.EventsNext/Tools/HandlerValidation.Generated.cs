
using System;
using System.Diagnostics;
using DSharpPlus.BetterHosting.EventsNext.Services;

namespace DSharpPlus.BetterHosting.EventsNext.Tools;

internal static partial class HandlerValidation
{
    public static partial bool IsHandlerCanidate<THandler>(out string reason) where THandler : IDiscordEventHandler
    {
        if (!typeof(THandler).IsClass)
        {
            reason = $"Type {typeof(THandler).Name} is not a class implementing {nameof(IDiscordEventHandler)}";
            return false;
        }

        if (typeof(THandler).IsAbstract)
        {
            reason = $"Type {typeof(THandler).Name} is abstract, which is not allowed";
            return false;
        }

        if (!typeof(THandler).IsAssignableTo(typeof(IDiscordEventHandler)))
        {
            reason = $"Type {typeof(THandler).Name} is not a {nameof(IDiscordEventHandler)}";
            return false;
        }
        
        if (!EventInterfaceValidation.IsAssignableToAny<THandler>())
        {
            reason = $"Handler {typeof(THandler).Name} is not assignable to any of the handler interfaces";
            return false;
        }

        reason = string.Empty;
        return true;
    }

    public static partial bool IsHandlerCanidate(Type handlerType, out string reason)
    {
        Debug.Assert(handlerType != null);
        if (!handlerType.IsClass)
        {
            reason = $"Type {handlerType.Name} is not a class implementing {nameof(IDiscordEventHandler)}";
            return false;
        }

        if (handlerType.IsAbstract)
        {
            reason = $"Type {handlerType.Name} is abstract, which is not allowed";
            return false;
        }

        if (!handlerType.IsAssignableTo(typeof(IDiscordEventHandler)))
        {
            reason = $"Type {handlerType.Name} is not a {nameof(IDiscordEventHandler)}";
            return false;
        }
        
        if (!EventInterfaceValidation.IsAssignableToAny(handlerType))
        {
            reason = $"Handler {handlerType.Name} is not assignable to any of the handler interfaces";
            return false;
        }

        reason = string.Empty;
        return true;
    }
}


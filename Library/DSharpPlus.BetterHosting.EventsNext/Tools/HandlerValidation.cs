#if false
using System;
using DSharpPlus.EventArgs;
using DSharpPlus.BetterHosting.EventsNext.Services;

namespace DSharpPlus.BetterHosting.EventsNext.Tools;

internal static partial class HandlerValidation
{
    /// <inheritdoc cref="IsHandlerCanidate{THandler, TArgument}()"/>
    public static bool IsHandlerCanidate<THandler, TArgument>() where THandler : IDiscordEventHandler where TArgument : DiscordEventArgs => IsHandlerCanidate<THandler, TArgument>(out string _);

    /// <inheritdoc cref="IsHandlerCanidate{THandler}(out string)"/>
    public static bool IsHandlerCanidate<THandler, TArgument>(out string reason) where THandler : IDiscordEventHandler where TArgument : DiscordEventArgs => IsHandlerCanidate<THandler>(out reason);

    /// <inheritdoc cref="IsHandlerCanidate(Type, out string)"/>
    public static bool IsHandlerCanidate(Type handler) => IsHandlerCanidate(handler, out string _);

    /// <summary>
    /// Validates if <typeparamref name="THandler"/> is a valid candidate to be a <see cref="IDiscordEventHandler"/> or not
    /// </summary>
    /// <typeparam name="THandler">The type to check</typeparam>
    /// <param name="reason">If the type is not a valid canidate, the reason why</param>
    /// <returns><see langword="true"/> if <typeparamref name="THandler"/> is a valid <see cref="IDiscordEventHandler"/>, else <see langword="false"/></returns>
    public static bool IsHandlerCanidate<THandler>(out string reason) where THandler : IDiscordEventHandler
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
    
    /// <summary>
    /// Validates if a type is a valid candidate to be a <see cref="IDiscordEventHandler"/> or not
    /// </summary>
    /// <param name="handlerType">The type to check</param>
    /// <param name="reason">If the type is not a valid canidate, the reason why</param>
    /// <returns><see langword="true"/> if <paramref name="handlerType"/> is a valid <see cref="IDiscordEventHandler"/>, else <see langword="false"/></returns>
    public static bool IsHandlerCanidate(Type handlerType, out string reason)
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
#endif
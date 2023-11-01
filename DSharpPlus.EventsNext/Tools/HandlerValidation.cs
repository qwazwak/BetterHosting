using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using DSharpPlus.EventsNext.Entities;

namespace DSharpPlus.EventsNext.Tools;

internal static partial class HandlerValidation
{
    private static partial HashSet<Type> InitHandlerInterfaces();
    /// <summary>
    /// A set of all valid interfaces deriving from <see cref="IDiscordEventHandler{TArgs}"/>
    /// </summary>
    public static readonly FrozenSet<Type> HandlerInterfaces = InitHandlerInterfaces().ToFrozenSet();

#if false
    public static void VerifyHandler(Type handler)
    {
        ArgumentNullException.ThrowIfNull(handler);
        if (!IsValidHandlerCanidate(handler, out string reason))
            throw new ArgumentException(reason, nameof(handler));
    }
    public static void VerifyHandlerExact(Type handler)
    {
        ArgumentNullException.ThrowIfNull(handler);
        if (!IsValidHandlerCanidate(handler, out string reason))
            throw new ArgumentException(reason, nameof(handler));
    }
#endif
    /// <inheritdoc cref="IsValidHandlerCanidate(Type, out string)"/>
    public static bool IsValidHandler(Type handler) => IsValidHandlerCanidate(handler, out string _);

    /// <summary>
    /// Validates if a type is a valid candidate to be a <see cref="IDiscordEventHandler"/> or not
    /// </summary>
    /// <param name="handler">The type to check</param>
    /// <param name="reason">If the type is not a valid canidate, the reason why</param>
    /// <returns><see langword="true"/> if <paramref name="handler"/> is a valid <see cref="IDiscordEventHandler"/>, else <see langword="false"/></returns>
    public static bool IsValidHandlerCanidate(Type handler, out string reason)
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

        if (!HandlerInterfaces.Overlaps(handler.GetInterfaces()))
        {
            reason = $"Handler {handler.Name} does not implement any of the handler interfaces";
            return false;
        }

        reason = string.Empty;
        return true;
    }
#if false
    /// <summary>
    /// Validates if a type is a valid candidate to be a <see cref="IDiscordEventHandler"/> or not
    /// </summary>
    /// <param name="handler">The type to check</param>
    /// <param name="reason">If the type is not a valid canidate, the reason why</param>
    /// <returns><see langword="true"/> if <paramref name="handler"/> is a valid <see cref="IDiscordEventHandler"/>, else <see langword="false"/></returns>
    public static bool IsValidHandlerCanidate<THandler>(out string reason) where THandler : class, IDiscordEventHandler
    {
        if (!handler.IsClass)
        {
            reason = $"Type {typeof(THandler).Name} is not a class implementing {nameof(IDiscordEventHandler)}";
            return false;
        }

        if (typeof(THandler).IsAbstract)
        {
            reason = $"Type {typeof(THandler).Name} is abstract, which is not allowed";
            return false;
        }

        if (!AssignableToAny<THandler>(handler.GetInterfaces()))
        {
            reason = $"Handler {handler.Name} does not implement any of the handler interfaces";
            return false;
        }

        reason = string.Empty;
        return true;
    }
    private static partial bool AssignableToAny<THandler>() where THandler : IDiscordEventHandler;
    private static partial bool AssignableToAny(Type interfaceType);
#endif

    internal static void VerifyExactInterface(Type interfaceType)
    {
        ArgumentNullException.ThrowIfNull(interfaceType);
        if (!IsExactInterface(interfaceType))
            ThrowInvalidExactInterface(interfaceType);
    }
    internal static partial bool IsExactInterface(Type interfaceType);

    internal static void VerifyExactInterface<TInterface>() where TInterface : IDiscordEventHandler
    {
        if (!IsExactInterface<TInterface>())
            ThrowInvalidExactInterface(typeof(TInterface));
    }
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    internal static partial bool IsExactInterface<TInterface>() where TInterface : IDiscordEventHandler;

    [MethodImpl(MethodImplOptions.NoInlining)]
    private static void ThrowInvalidExactInterface(Type interfaceType) => throw new InvalidOperationException($"The type {interfaceType.Name} is not a one of the defined derivations of {typeof(IDiscordEventHandler).Name}");
}

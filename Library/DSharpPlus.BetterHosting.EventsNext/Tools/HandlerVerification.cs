using System;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;
using DSharpPlus.BetterHosting.EventsNext.Services;
using DSharpPlus.BetterHosting.EventsNext.Exceptions;

namespace DSharpPlus.BetterHosting.EventsNext.Tools;

internal static class HandlerVerification
{
    public static void VerifyExactInterface<TInterface>() where TInterface : IDiscordEventHandler
    {
        if (!EventInterfaceValidation.IsExactInterface<TInterface>())
            ThrowInvalidExactInterface(typeof(TInterface));
    }

    public static void VerifyValidHandlerCanidate(Type handler, [CallerArgumentExpression(nameof(handler))] string argumentName = default!)
    {
        Debug.Assert(handler != null);
        if (!HandlerValidation.IsHandlerCanidate(handler, out string message))
            ThrowNoHandlerInterfaces(argumentName, handler, message);
    }

    public static void VerifyValidHandlerCanidate<THandler>() where THandler : IDiscordEventHandler
    {
        if (!HandlerValidation.IsHandlerCanidate<THandler>(out string message))
            ThrowNoHandlerInterfaces(nameof(THandler), typeof(THandler), message);
    }

    public static void VerifyExactInterface(Type interfaceType)
    {
        ArgumentNullException.ThrowIfNull(interfaceType);
        if (!EventInterfaceValidation.IsExactInterface(interfaceType))
            ThrowInvalidExactInterface(interfaceType);
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    [DoesNotReturn]
    private static void ThrowInvalidExactInterface(Type interfaceType) => throw new InvalidHandlerInterfaceException(interfaceType);

    [MethodImpl(MethodImplOptions.NoInlining)]
    [DoesNotReturn]
    private static void ThrowNoHandlerInterfaces(string paramName, Type interfaceType, string message) => throw new NoEventHandlerCanidateException(message, paramName, interfaceType);
}
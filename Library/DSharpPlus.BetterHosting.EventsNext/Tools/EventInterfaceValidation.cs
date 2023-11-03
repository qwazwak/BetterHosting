using DSharpPlus.BetterHosting.EventsNext.Services;
using System.Runtime.CompilerServices;
using System;

namespace DSharpPlus.BetterHosting.EventsNext.Tools;

internal static partial class EventInterfaceValidation
{
    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static partial bool IsExactInterface<TInterface>() where TInterface : IDiscordEventHandler;

    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public static partial bool IsAssignableToAny<THandler>() where THandler : IDiscordEventHandler;

    public static partial bool IsExactInterface(Type interfaceType);
    public static partial bool IsAssignableToAny(Type handlerType);
}

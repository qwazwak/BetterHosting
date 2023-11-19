using System;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;
using DSharpPlus.BetterHosting.EventsNext.Services;
using DSharpPlus.BetterHosting.EventsNext.Exceptions;

namespace DSharpPlus.BetterHosting.EventsNext.Tools;

internal static partial class EventReflection
{
    public static class Verification
    {
        public static void VerifyExactInterface<TInterface>() where TInterface : IDiscordEventHandler => VerifyExactInterface(typeof(TInterface));
        public static void VerifyExactInterface(Type interfaceType)
        {
            ArgumentNullException.ThrowIfNull(interfaceType);
            if (!Validation.IsExactInterface(interfaceType))
                ThrowInvalidExactInterface(interfaceType);
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        [DoesNotReturn]
        private static void ThrowInvalidExactInterface(Type interfaceType) => throw new InvalidHandlerInterfaceException(interfaceType);
    }
}
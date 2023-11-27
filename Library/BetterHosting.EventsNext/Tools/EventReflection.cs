using System;
using DSharpPlus.EventArgs;
using BetterHosting.EventsNext.Services;
using System.Collections.Immutable;
using System.Diagnostics;
using BetterHosting.EventsNext.Services.Implementations;
using BetterHosting.EventsNext.Exceptions;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Runtime.CompilerServices;

namespace BetterHosting.EventsNext.Tools;

internal static partial class EventReflection
{
    //Internal for testing
    internal record DetailsRecord(Type EventInterface, Type ArgumentType);

    private static partial ImmutableDictionary<Type, DetailsRecord> GetDetails();
    private static readonly WeakReference<ImmutableDictionary<Type, DetailsRecord>> weakDetails = new(null!);
    private static void GetCachedDetails(out ImmutableDictionary<Type, DetailsRecord> details)
    {
        if (weakDetails.TryGetTarget(out ImmutableDictionary<Type, DetailsRecord>? cached) && cached != null)
        {
            details = cached;
            return;
        }
        ImmutableDictionary<Type, DetailsRecord> newDetails = GetDetails();
        weakDetails.SetTarget(newDetails);
        details = newDetails;
    }

    //Internal for testing
    internal static DetailsRecord DetailsFor(Type interfaceType)
    {
        Validation.VerifyExactInterface(interfaceType);
        GetCachedDetails(out ImmutableDictionary<Type, DetailsRecord> dict);
        return dict[interfaceType];
    }

    public static class ArgumentType
    {
        //Internal for testing
        internal static Type For(Type interfaceType) => DetailsFor(interfaceType).ArgumentType;
    }

    public static class ManagerType
    {
        public static Type For(Type eventInterface) => For(eventInterface, DetailsFor(eventInterface).ArgumentType);
        public static Type For(Type eventInterface, Type eventArgument)
        {
            Debug.Assert(Validation.IsExactInterface(eventInterface));
            Debug.Assert(eventArgument.IsAssignableTo(typeof(DiscordEventArgs)));
            return typeof(AutoCallEventHandlerManager<,>).MakeGenericType(eventInterface, eventArgument);
        }
    }

    public static class ManagerHostType
    {
        public static Type For(Type eventInterface) => typeof(EventsNextBackgroundHost<>).MakeGenericType(eventInterface);
    }

    public static class Validation
    {
        public static bool IsExactInterface(Type interfaceType)
        {
            if (!interfaceType.IsInterface || !typeof(IDiscordEventHandler).IsAssignableFrom(interfaceType))
                return false;
            GetCachedDetails(out ImmutableDictionary<Type, DetailsRecord> dict);
            return dict.ContainsKey(interfaceType);
        }

        public static bool IsAssignableToAny(Type handlerType)
        {
            GetCachedDetails(out ImmutableDictionary<Type, DetailsRecord> dict);
            return dict.Keys.Any(handlerType.IsEquivalentTo);
        }

        public static void VerifyExactInterface(Type interfaceType)
        {
            ArgumentNullException.ThrowIfNull(interfaceType);
            if (!IsExactInterface(interfaceType))
                ThrowInvalidExactInterface(interfaceType);
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        [DoesNotReturn]
        private static void ThrowInvalidExactInterface(Type interfaceType) => throw new InvalidHandlerInterfaceException(interfaceType);
    }
}
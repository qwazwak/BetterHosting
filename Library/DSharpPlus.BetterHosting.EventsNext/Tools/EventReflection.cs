using System;
using DSharpPlus.EventArgs;
using DSharpPlus.BetterHosting.EventsNext.Services;
using System.Collections.Immutable;
using System.Collections.Generic;
using System.Diagnostics;
using DSharpPlus.BetterHosting.EventsNext.Services.Implementations;
using DSharpPlus.BetterHosting.EventsNext.Exceptions;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Runtime.CompilerServices;

namespace DSharpPlus.BetterHosting.EventsNext.Tools;

internal static partial class EventReflection
{
    //Internal for testing
    internal record DetailsRecord(Type EventInterface, Type ArgumentType)
    {
        public static DetailsRecord Create<TEventInterface, TArgument>()
            where TEventInterface : IDiscordEventHandler<TArgument>
            where TArgument : DiscordEventArgs
            => new(typeof(TEventInterface), typeof(TArgument));
    }

    private static partial ImmutableDictionary<Type, DetailsRecord> GetDetails();
    private static readonly AutoWeakReference<ImmutableDictionary<Type, DetailsRecord>> weakDetails = new(GetDetails);

    // should be avoided.
    // See WeakReference.TryGetTarget
    internal static void AllDetails(out IEnumerable<DetailsRecord> details)
    {
        weakDetails.GetTarget(out ImmutableDictionary<Type, DetailsRecord>? target);
        details = target.Values;
    }

    //Internal for testing
    internal static DetailsRecord DetailsFor<TInterface>() where TInterface : IDiscordEventHandler => DetailsFor(typeof(TInterface));
    //Internal for testing
    internal static DetailsRecord DetailsFor(Type interfaceType)
    {
        Debug.Assert(interfaceType.IsAssignableTo(typeof(IDiscordEventHandler)), $"{interfaceType.Name} is not valid");
        weakDetails.GetTarget(out ImmutableDictionary<Type, DetailsRecord> dict);
        return dict[interfaceType];
    }

    public static class ArgumentType
    {
        public static Type For<TInterface>() where TInterface : IDiscordEventHandler => For(typeof(TInterface));
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
    public static class Validation
    {
        public static bool IsExactInterface<TInterface>() where TInterface : IDiscordEventHandler => IsExactInterface(typeof(TInterface));
        public static bool IsExactInterface(Type interfaceType)
        {
            if (!interfaceType.IsInterface || !typeof(IDiscordEventHandler).IsAssignableFrom(interfaceType))
                return false;
            weakDetails.GetTarget(out ImmutableDictionary<Type, DetailsRecord> dict);
            return dict.ContainsKey(interfaceType);
        }

        public static bool IsAssignableToAny<THandler>() where THandler : IDiscordEventHandler => IsAssignableToAny(typeof(THandler));
        public static bool IsAssignableToAny(Type handlerType)
        {
            weakDetails.GetTarget(out ImmutableDictionary<Type, DetailsRecord> dict);
            return dict.Keys.Any(t => t.IsAssignableFrom(handlerType));
        }
    }

    private readonly struct AutoWeakReference<T>(Func<T> factory) where T : class?
    {
        public AutoWeakReference() : this(Activator.CreateInstance<T>) { }

        private readonly Func<T> factory = factory;
        private readonly WeakReference<T> weakReference = new(null!);

        //
        // We are exposing TryGetTarget instead of a simple getter to avoid a common problem where people write incorrect code like:
        //
        //      WeakReference ref = ...;
        //      if (ref.Target != null)
        //          DoSomething(ref.Target)
        //
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public readonly void GetTarget(out T target)
        {
            if (weakReference.TryGetTarget(out T? cached) && cached != null)
            {
                target = cached;
            }
            else
            {
                T newValue = factory.Invoke();
                weakReference.SetTarget(newValue);
                target = newValue;
            }
        }

        public readonly void SetTarget(T target) => weakReference.SetTarget(target);

        public readonly void Clear() => weakReference.SetTarget(null!);
    }
}
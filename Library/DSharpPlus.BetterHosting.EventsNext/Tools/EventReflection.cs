using System;
using DSharpPlus.EventArgs;
using DSharpPlus.BetterHosting.EventsNext.Services;
using System.Collections.Immutable;
using System.Collections.Generic;
using System.Diagnostics;
using DSharpPlus.BetterHosting.EventsNext.Services.Implementations;

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
}
using System;
using DSharpPlus.EventArgs;
using DSharpPlus.BetterHosting.EventsNext.Services;
using System.Collections.Immutable;
using System.Collections.Generic;
using System.Diagnostics;

namespace DSharpPlus.BetterHosting.EventsNext.Tools;

internal static partial class EventReflection
{
    internal record DetailsRecord(Type EventInterface, Type ArgumentType)
    {
        public static DetailsRecord Create<TEventInterface, TArgument>()
            where TEventInterface : IDiscordEventHandler<TArgument>
            where TArgument : DiscordEventArgs
            => new(typeof(TEventInterface), typeof(TArgument));
    }

    private static partial ImmutableDictionary<Type, DetailsRecord> GetDetails();
    private static readonly AutoWeakReference<ImmutableDictionary<Type, DetailsRecord>> weakDetails = new(GetDetails);

    public static IEnumerable<DetailsRecord> AllDetails => weakDetails.Target().Values;

    //Internal for testing
    internal static DetailsRecord DetailsFor<TInterface>() where TInterface : IDiscordEventHandler => DetailsFor(typeof(TInterface));
    //Internal for testing
    internal static DetailsRecord DetailsFor(Type interfaceType)
    {
        Debug.Assert(interfaceType.IsAssignableTo(typeof(IDiscordEventHandler)));
        weakDetails.GetTarget(out ImmutableDictionary<Type, DetailsRecord> dict);
        if (!dict.TryGetValue(interfaceType, out DetailsRecord? details))
            Debug.Fail($"{interfaceType.Name} is not valid");

        return details;
    }
}
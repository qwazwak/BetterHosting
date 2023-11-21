using System;
using DSharpPlus.EventArgs;
using DSharpPlus.BetterHosting.EventsNext.Services;
using DSharpPlus.BetterHosting.EventsNext.Services.Implementations;
using System.Collections.Immutable;

namespace DSharpPlus.BetterHosting.EventsNext.Tools;

internal static partial class EventReflection
{
    private record class DetailsRecord(Type Manager, Type Arguments)
    {
        public static DetailsRecord Create<TManager, TEventInterface, TArgument>()
            where TManager : EventHandlerManager<TEventInterface, TArgument>
            where TEventInterface : IDiscordEventHandler<TArgument>
            where TArgument : DiscordEventArgs
            => new(typeof(TManager), typeof(TArgument));
    }

    private static partial ImmutableDictionary<Type, DetailsRecord> GetDeails();
    private static readonly AutoWeakReference<ImmutableDictionary<Type, DetailsRecord>> weakDetails = new(GetDeails);

    private static DetailsRecord DetailsFor<TInterface>() where TInterface : IDiscordEventHandler => DetailsFor(typeof(TInterface));
    private static DetailsRecord DetailsFor(Type interfaceType)
    {
        Debug.Assert(interfaceType.IsAssignableTo(typeof(IDiscordEventHandler)));
        weakDetails.GetTarget(out ImmutableDictionary<Type, DetailsRecord> dict);
        if (!dict.TryGetValue(interfaceType, out DetailsRecord? details))
            Debug.Fail($"{interfaceType.Name} is not valid");

        return details;
    }
}
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

    private static ImmutableHashSet<Type> GetExactInterfaces() => weakDetails.Target().Keys.ToImmutableHashSet();
    private static readonly AutoWeakReference<ImmutableHashSet<Type>> weakExactInterfaces = new(() => GetExactInterfaces());

    private static partial ImmutableDictionary<Type, DetailsRecord> GetDeails();
    private static readonly AutoWeakReference<ImmutableDictionary<Type, DetailsRecord>> weakDetails = new(GetDeails);
}
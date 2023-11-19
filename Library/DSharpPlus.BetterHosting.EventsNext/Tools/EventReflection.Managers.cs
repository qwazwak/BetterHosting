using System;
using DSharpPlus.BetterHosting.EventsNext.Services;
using System.Diagnostics;
using System.Collections.Immutable;

namespace DSharpPlus.BetterHosting.EventsNext.Tools;

internal static partial class EventReflection
{
    public static class Managers
    {
        public static Type For<TInterface>() where TInterface : IDiscordEventHandler
        {
            weakDetails.GetTarget(out ImmutableDictionary<Type, DetailsRecord> dict);
            if (!dict.TryGetValue(typeof(TInterface), out DetailsRecord? details))
                Debug.Fail($"{typeof(TInterface).Name} is not valid");
            return details.Manager;
        }
    }
}
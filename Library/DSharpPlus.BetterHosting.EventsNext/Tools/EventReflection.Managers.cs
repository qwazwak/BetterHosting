using System;
using DSharpPlus.BetterHosting.EventsNext.Services;
using System.Diagnostics;
using System.Collections.Immutable;

namespace DSharpPlus.BetterHosting.EventsNext.Tools;

internal static partial class EventReflection
{
    public static class Managers
    {
        public static Type For<TInterface>() where TInterface : IDiscordEventHandler => For(typeof(TInterface));
        private static Type For(Type interfaceType)
        {
            Debug.Assert(interfaceType.IsAssignableTo(typeof(IDiscordEventHandler)));
            weakDetails.GetTarget(out ImmutableDictionary<Type, DetailsRecord> dict);
            if (!dict.TryGetValue(interfaceType, out DetailsRecord? details))
                Debug.Fail($"{interfaceType.Name} is not valid");

            return details.Manager;
        }
    }
}
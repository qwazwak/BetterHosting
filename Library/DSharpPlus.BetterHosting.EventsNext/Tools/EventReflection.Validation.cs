using DSharpPlus.BetterHosting.EventsNext.Services;
using System;
using System.Linq;
using System.Collections.Immutable;

namespace DSharpPlus.BetterHosting.EventsNext.Tools;

internal static partial class EventReflection
{
    internal static class Validation
    {
        public static bool IsExactInterface<TInterface>() where TInterface : IDiscordEventHandler => IsExactInterface(typeof(TInterface));
        public static bool IsExactInterface(Type interfaceType)
        {
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
}
using System;
using DSharpPlus.BetterHosting.EventsNext.Services;
using DSharpPlus.EventArgs;

namespace UnitTests.DSharpPlus.BetterHosting.EventsNext;

public static class InvalidHandlerTypesTestData
{
    public static readonly Type[] InvalidGenericEventHandlerTypes = new[]
    {
        typeof(IDiscordEventHandler<DiscordEventArgs>)
    };
}

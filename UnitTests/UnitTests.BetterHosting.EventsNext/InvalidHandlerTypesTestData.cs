using System;
using BetterHosting.EventsNext.Services;
using DSharpPlus.EventArgs;

namespace UnitTests.BetterHosting.EventsNext;

public static class InvalidHandlerTypesTestData
{
    public static readonly Type[] InvalidGenericEventHandlerTypes = new[]
    {
        typeof(IDiscordEventHandler<DiscordEventArgs>)
    };
}

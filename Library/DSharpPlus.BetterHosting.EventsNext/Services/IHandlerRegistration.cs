using System;

namespace DSharpPlus.BetterHosting.EventsNext.Services;

internal interface IHandlerRegistration<TInterface> //where TInterface : IDiscordEventHandler
{
    Guid Key { get; }
}

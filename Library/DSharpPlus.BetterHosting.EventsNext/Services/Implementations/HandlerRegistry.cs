using System;
using System.Collections.Generic;

namespace DSharpPlus.BetterHosting.EventsNext.Services.Implementations;

internal sealed class HandlerRegistry<TInterface>() : HashSet<Guid>(0), IHandlerRegistry<TInterface> where TInterface : IDiscordEventHandler { }
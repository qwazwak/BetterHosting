using System.Collections.Generic;

namespace DSharpPlus.BetterHosting.EventsNext.Services;

internal interface IHandlerRegistry<TInterface> : IReadOnlyCollection<IHandlerRegistration<TInterface>> { }
using System.Collections.Generic;

namespace BetterHosting.EventsNext.Services;

internal interface IHandlerProvider<TInterface> : IReadOnlyList<IHandlerBuilder<TInterface>> { }

using System.Collections.Generic;

namespace DSharpPlus.BetterHosting.EventsNext.Services;

internal interface IHandlerProvider<TInterface> : IReadOnlyList<IHandlerBuilder<TInterface>>
{
}

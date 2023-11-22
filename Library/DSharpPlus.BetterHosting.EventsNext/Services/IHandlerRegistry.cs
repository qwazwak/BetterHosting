using System;
using System.Collections.Generic;

namespace DSharpPlus.BetterHosting.EventsNext.Services;

internal interface IHandlerRegistry<TInterface> : ISet<Guid> { }
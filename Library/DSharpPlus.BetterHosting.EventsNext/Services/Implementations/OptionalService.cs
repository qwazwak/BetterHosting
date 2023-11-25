using System;
using Microsoft.Extensions.DependencyInjection;

namespace DSharpPlus.BetterHosting.EventsNext.Services.Implementations;

internal class OptionalService<TService>(IServiceProvider provider) : IOptionalService<TService>
{
    public TService? Service { get; } = provider.GetService<TService>();
}

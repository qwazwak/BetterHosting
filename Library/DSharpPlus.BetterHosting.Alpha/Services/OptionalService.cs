using System;
using DSharpPlus.BetterHosting.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace DSharpPlus.BetterHosting.Services.Implementation;

internal sealed class OptionalService<TService> : IOptionalService<TService>, IDisposable
{
    public OptionalService(IServiceProvider provider) => Service = provider.GetService<TService>();

    public TService? Service { get; }

    public void Dispose() => (Service as IDisposable)?.Dispose();
}

using System;
using System.Collections.Immutable;
using System.Linq;
using Microsoft.Extensions.DependencyInjection;

namespace DSharpPlus.BetterHosting.EventsNext.Services.Implementations;

internal class HandlerRegistryKeyProvider<TInterface>(IServiceProvider provider) : IHandlerRegistryKeyProvider<TInterface>
{
    private readonly IServiceProvider provider = provider;

    public ImmutableArray<Guid> GetKeys()
    {
        using IServiceScope scope = provider.CreateScope();
        IHandlerRegistry<TInterface> reg = scope.ServiceProvider.GetRequiredService<IHandlerRegistry<TInterface>>();
        return ImmutableArray.CreateRange(reg.Select(i => i.Key));
    }
}

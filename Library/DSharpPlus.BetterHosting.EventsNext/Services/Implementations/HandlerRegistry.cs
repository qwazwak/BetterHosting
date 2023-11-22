using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;

namespace DSharpPlus.BetterHosting.EventsNext.Services.Implementations;

internal sealed class HandlerRegistry<TInterface> : IHandlerRegistry<TInterface>, IDisposable
    where TInterface : IDiscordEventHandler
{
    private List<IHandlerRegistration<TInterface>>? registrations;
    private bool isDisposed;

    public HandlerRegistry(IEnumerable<IHandlerRegistration<TInterface>> registrations) => this.registrations = new(registrations);

    public int Count => registrations!.Count;

    public IEnumerator<IHandlerRegistration<TInterface>> GetEnumerator() => registrations!.GetEnumerator();
    IEnumerator IEnumerable.GetEnumerator() => ((IEnumerable)registrations!).GetEnumerator();

    public void Dispose()
    {
        if (!isDisposed)
        {
            Debug.Assert(registrations != null);
            registrations.Clear();
            registrations.TrimExcess();
            registrations.Capacity = 0;
            registrations = null;
            isDisposed = true;
        }
        GC.SuppressFinalize(this);
    }
}
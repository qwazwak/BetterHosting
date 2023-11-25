using System;
using System.Threading.Tasks;

namespace DSharpPlus.BetterHosting.EventsNext.Tools;

internal readonly struct DisposingWrapper(object obj) : IAsyncDisposable
{
    private readonly object obj = obj;

    public ValueTask DisposeAsync()
    {
        if (obj is IAsyncDisposable asyncDisposable)
            return asyncDisposable.DisposeAsync();

        if (obj is IDisposable disposable)
            disposable.Dispose();
        return ValueTask.CompletedTask;
    }
}
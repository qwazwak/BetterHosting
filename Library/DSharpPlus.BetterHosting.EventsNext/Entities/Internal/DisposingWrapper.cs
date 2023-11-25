using System;
using System.Threading.Tasks;

namespace DSharpPlus.BetterHosting.EventsNext.Entities.Internal;

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
internal readonly struct DisposingWrapper<T>(T instance) : IAsyncDisposable
{
    public readonly T Instance = instance;

    public ValueTask DisposeAsync()
    {
        if (Instance is IAsyncDisposable asyncDisposable)
            return asyncDisposable.DisposeAsync();

        if (Instance is IDisposable disposable)
            disposable.Dispose();
        return ValueTask.CompletedTask;
    }
}
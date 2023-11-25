using System;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace DSharpPlus.BetterHosting.EventsNext.Entities.Internal;

internal readonly struct DisposingWrapper<T>(T instance) : IAsyncDisposable
{
    public readonly T Instance = instance;
    private readonly bool dispose;

    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public DisposingWrapper(T instance, bool dispose) : this(instance) => this.dispose = dispose;

    [MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
    public ValueTask DisposeAsync()
    {
        if (dispose)
        {
            if (Instance is IAsyncDisposable asyncDisposable)
                return asyncDisposable.DisposeAsync();

            if (Instance is IDisposable disposable)
                disposable.Dispose();
        }
        return ValueTask.CompletedTask;
    }
}
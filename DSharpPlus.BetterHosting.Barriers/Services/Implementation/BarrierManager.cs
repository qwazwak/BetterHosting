using System;
using System.Threading;
using System.Threading.Tasks;
using DSharpPlus.BetterHosting.Services.Interfaces;
using Microsoft.Extensions.Logging;
using QLib.AsyncEventBlock;
using InternalLib.AsyncEventBlock;
using System.Runtime.CompilerServices;

namespace DSharpPlus.BetterHosting.Services.Implementation;

public interface IDiscordConnectedBarrier
{
    ValueTask<DiscordShardedClient> WaitForConnected();
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Reliability", "CA2012:Use ValueTasks correctly", Justification = "<Pending>")]
    ValueTaskAwaiter<DiscordShardedClient> GetAwaiter() => WaitForConnected().GetAwaiter();
}

internal abstract class BarrierManager<TBarrier> : IBarrierManager<TBarrier>, IBarrierProvider<TBarrier> where TBarrier : IBarrier
{
    private readonly ILogger logger;
    private readonly OneTimeAsyncEvent slim = new();

    protected BarrierManager(ILogger logger) => this.logger = logger;
    protected abstract TBarrier GetBarrier(OneTimeAsyncEvent slim);

    public TBarrier GetBarrier() => GetBarrier(slim);

    public void SetOpen()
    {
        logger.LogInformation("Opening barrier");
        slim.SetOpen();
    }

    public void SetFailed(Exception ex)
    {
        logger.LogInformation("Marking barrier as errored");
        slim.SetFailed(ex);
    }

    public void SetCancelled(CancellationToken reason) => slim.SetCancelled(reason);
}

internal abstract class BarrierManager<TBarrier, TValue> : IBarrierManager<TBarrier, TValue>, IBarrierProvider<TBarrier, TValue> where TBarrier : IBarrier<TValue>
{
    private readonly ILogger logger;
    private readonly OneTimeAsyncEvent<TValue> slim = new();

    protected BarrierManager(ILogger logger) => this.logger = logger;
    protected abstract TBarrier OpenBarrier(TValue value);
    protected abstract TBarrier DefaultBarrier(OneTimeAsyncEvent<TValue> slim);
    public TBarrier GetBarrier()
    {
        if (slim.TryGetNow(out TValue value))
            return OpenBarrier(value);
        else
            return DefaultBarrier(slim);
    }

    public void SetOpen(TValue value)
    {
        logger.LogInformation("Opening barrier");
        slim.SetOpen(value);
    }

    public void SetFailed(Exception ex)
    {
        logger.LogInformation("Marking barrier as errored");
        slim.SetFailed(ex);
    }

    public void SetCancelled(CancellationToken cancellationToken = default) => slim.SetCancelled(CancellationToken.None);
}
internal sealed class DefaultBarrierManager(ILogger logger) : BarrierManager<IBarrier>(logger)
{
    protected override IBarrier GetBarrier(OneTimeAsyncEvent slim) => new DefaultBarrier(slim);

    private readonly struct DefaultBarrier(OneTimeAsyncEvent slim) : IBarrier
    {
        private readonly OneTimeAsyncEvent slim = slim;
        public readonly ValueTask WaitForBarrier() => slim.WaitAsync();
    }
}
internal sealed class DefaultBarrierManager<TValue>(ILogger logger) : BarrierManager<IBarrier<TValue>, TValue>(logger)
{
    protected override IBarrier<TValue> OpenBarrier(TValue value) => new OpenBarrierImpl(value);
    protected override IBarrier<TValue> DefaultBarrier(OneTimeAsyncEvent<TValue> slim) => new DefaultBarrierImpl(slim);

    private readonly struct OpenBarrierImpl(TValue value) : IBarrier<TValue>
    {
        private readonly TValue value = value;
        public readonly ValueTask<TValue> WaitForBarrier() => ValueTask.FromResult(value);
    }
    private readonly struct DefaultBarrierImpl(OneTimeAsyncEvent<TValue> slim) : IBarrier<TValue>
    {
        private readonly OneTimeAsyncEvent<TValue> slim = slim;
        public readonly ValueTask<TValue> WaitForBarrier() => slim.WaitAsync();
    }
}
#if false

internal class BarrierManager2<TBarrier, TValue> : IBarrierManager<TBarrier, TValue>, IBarrierProvider<TBarrier, TValue> where TBarrier : IBarrier<TValue> 
{
    private readonly ILogger<BarrierManager2<T>> logger;
    private readonly OneTimeAsyncEvent<T> slim = new();

    public BarrierManager2(ILogger<BarrierManager2<T>> logger) => this.logger = logger;
    protected abstract TBarrier OpenBarrier(TValue value);
    public TBarrier GetBarrier()
    {
        if (slim.TryGetNow(out T value))
            return new OpenBarrier(value);
        else
            return new DefaultBarrier(slim);
    }

    public void SetOpen(T value)
    {
        logger.LogInformation("Opening barrier");
        slim.SetOpen(value);
    }

    public void SetFailed(Exception ex)
    {
        logger.LogInformation("Marking barrier as errored");
        slim.SetFailed(ex);
    }

    public void SetCancelled(CancellationToken cancellationToken = default) => slim.SetCancelled(CancellationToken.None);

    protected  struct DefaultBarrier(OneTimeAsyncEvent<T> slim) : IBarrier<T>
    {
        private readonly OneTimeAsyncEvent<T> slim = slim;
        public readonly ValueTask<T> WaitForBarrier() => slim.WaitAsync();
    }
    private readonly struct OpenBarrier(T value) : IBarrier<T>
    {
        private readonly T value = value;
        public readonly ValueTask<T> WaitForBarrier() => ValueTask.FromResult(value);
    }
}
#endif
using System;
using System.Threading;
using System.Threading.Tasks;
using DSharpPlus.BetterHosting.Services.Implementation.temp;
using DSharpPlus.BetterHosting.Services.Interfaces;
using Microsoft.Extensions.Logging;

namespace DSharpPlus.BetterHosting.Services.Implementation;

internal sealed class BarrierManager : IBarrierManager, IBarrierProvider
{
    private readonly ILogger<BarrierManager> logger;
    private readonly AsyncManualResetEvent slim = new();

    public BarrierManager(ILogger<BarrierManager> logger) => this.logger = logger;

    public IBarrier GetBarrier()
    {
        if (slim.IsCompletedSuccessfully)
            return new DefaultBarrier();
        else
            return new DefaultBarrier(this);
    }

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

    public void SetCancelled(CancellationToken cancellationToken = default) => slim.SetCancelled(CancellationToken.None);

    private readonly struct DefaultBarrier(BarrierManager parent) : IBarrier
    {
        private readonly BarrierManager parent = parent;

        public readonly ValueTask WaitForBarrier() => parent.slim.IsCompletedSuccessfully ? ValueTask.CompletedTask : parent.slim.WaitAsync();
    }
}
internal sealed class BarrierManager<T> : IBarrierManager<T>, IBarrierProvider<T>
{
    private readonly ILogger<BarrierManager<T>> logger;
    private readonly AsyncManualResetEvent<T> slim = new();

    public BarrierManager(ILogger<BarrierManager<T>> logger) => this.logger = logger;

    public IBarrier<T> GetBarrier()
    {
        if (slim.TryGetNow(out T value))
            return new OpenBarrier(value);
        else
            return new DefaultBarrier(this);
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

    private readonly struct DefaultBarrier(BarrierManager<T> parent) : IBarrier<T>
    {
        private readonly BarrierManager<T> parent = parent;

        public readonly ValueTask<T> WaitForBarrier() => parent.slim.WaitAsync();
    }
    private readonly struct OpenBarrier(T value) : IBarrier<T>
    {
        private readonly T value = value;

        public readonly ValueTask<T> WaitForBarrier() => ValueTask.FromResult(value);
    }
}
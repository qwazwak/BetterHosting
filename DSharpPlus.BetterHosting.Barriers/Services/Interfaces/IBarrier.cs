using System;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;

namespace DSharpPlus.BetterHosting.Services.Interfaces;

public interface IBarrier
{
    //BarrierState State { get; }
    //public bool HasBeenSet { get; }
    ValueTask WaitForBarrier();
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Reliability", "CA2012:Use ValueTasks correctly", Justification = "<Pending>")]
    ValueTaskAwaiter GetAwaiter() => WaitForBarrier().GetAwaiter();
}

public interface IBarrierProvider<TBarrier> where TBarrier : IBarrier
{
    public TBarrier GetBarrier();
}
public interface IBarrierManager<TBarrier> : IBarrierProvider<TBarrier> where TBarrier : IBarrier
{
    public void SetOpen();
    public void SetFailed(Exception ex);
    public void SetCancelled(CancellationToken cancellationToken = default);
}
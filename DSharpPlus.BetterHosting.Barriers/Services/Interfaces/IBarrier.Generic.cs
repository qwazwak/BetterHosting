using System;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;

namespace DSharpPlus.BetterHosting.Services.Interfaces;

public interface IBarrier<T>
{
    //BarrierState State { get; }
    //public bool HasBeenSet { get; }
    ValueTask<T> WaitForBarrier();
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Reliability", "CA2012:Use ValueTasks correctly", Justification = "<Pending>")]
    ValueTaskAwaiter<T> GetAwaiter() => WaitForBarrier().GetAwaiter();
}

public interface IBarrierProvider<TBarrier, TValue> where TBarrier:  IBarrier<TValue>
{
    TBarrier GetBarrier();
}
public interface IBarrierManager<TBarrier, TValue> : IBarrierProvider<TBarrier, TValue> where TBarrier : IBarrier<TValue>
{
    public void SetOpen(TValue value);
    public void SetFailed(Exception ex);
    public void SetCancelled(CancellationToken cancellationToken = default);
}
using System;
using System.Threading.Tasks;

namespace DSharpPlus.BetterHosting.Services.Interfaces;

internal interface IShortScopeProvider<T>
{
    Task RunAsync(Func<T, Task> factory);
    void Run(Action<T> factory);
    Task<R> GetAsync<R>(Func<T, Task<R>> factory);
    R Get<R>(Func<T, R> factory);
}

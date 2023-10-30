using System;
using System.Threading.Tasks;
using DSharpPlus.BetterHosting.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace DSharpPlus.BetterHosting.Services.Implementation;

internal sealed class ShortScopeProvider<T>  : IShortScopeProvider<T> where T : notnull
{
    private readonly IServiceScopeFactory provider;
    public ShortScopeProvider(IServiceScopeFactory provider) => this.provider = provider;

    public async Task RunAsync(Func<T, Task> factory)
    {
        await using AsyncServiceScope scope = provider.CreateAsyncScope();
        T service = scope.ServiceProvider.GetRequiredService<T>();
        await factory.Invoke(service);
    }

    public void Run(Action<T> factory)
    {
        using IServiceScope scope = provider.CreateScope();
        T service = scope.ServiceProvider.GetRequiredService<T>();
        factory.Invoke(service);
    }

    public async Task<R> GetAsync<R>(Func<T, Task<R>> factory)
    {
        await using AsyncServiceScope scope = provider.CreateAsyncScope();
        T service = scope.ServiceProvider.GetRequiredService<T>();
        return await factory.Invoke(service);
    }

    public R Get<R>(Func<T, R> factory)
    {
        using IServiceScope scope = provider.CreateScope();
        T service = scope.ServiceProvider.GetRequiredService<T>();
        return factory.Invoke(service);
    }
}

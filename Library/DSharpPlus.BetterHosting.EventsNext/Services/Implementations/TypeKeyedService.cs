using Microsoft.Extensions.DependencyInjection;
using System;

namespace DSharpPlus.BetterHosting.EventsNext.Services.Implementations;

/// <summary>
/// Simple and minimal implementation of <see cref="ITypeKeyedService{TKey, TService}"/>
/// </summary>
/// <typeparam name="TKey"></typeparam>
/// <typeparam name="TService"></typeparam>
/// <param name="provider">The <see cref="IServiceProvider"/> to get the <typeparamref name="TService"/> from, must implement <see cref="IKeyedServiceProvider"/></param>
public class TypeKeyedService<TKey, TService>(IServiceProvider provider) : ITypeKeyedService<TKey, TService> where TService : class
{
    /// <inheritdoc />
    public TService Service { get; } = provider.GetRequiredKeyedService<TService>(typeof(TKey));
}

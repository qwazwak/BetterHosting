using System.Threading.Tasks;
using System.Threading;
using System.Diagnostics.CodeAnalysis;
using DSharpPlus.BetterHosting.Services.Interfaces;

namespace DSharpPlus.BetterHosting.Services.Implementation;

/// <summary>
/// A basic implementation of <see cref="ISingletonProvider{T}"/> simply depending upon and abstracting the <see cref="ISingletonManager{T}"/>
/// </summary>
/// <typeparam name="T"></typeparam>
public class SingletonProvider<T> : ISingletonProvider<T>
{
    private readonly ISingletonManager<T> manager;

    /// <summary>
    /// Constructs a new instance yielding the singleton of <paramref name="manager"/>
    /// </summary>
    /// <param name="manager"></param>
    public SingletonProvider(ISingletonManager<T> manager) => this.manager = manager;

    /// <inheritdoc />
    public ValueTask<T> WaitAsync(CancellationToken cancellationToken) => manager.WaitAsync(cancellationToken);

    /// <inheritdoc />
    public bool TryGetNow([MaybeNullWhen(false), NotNullWhen(true)] out T value) => manager.TryGetNow(out value);
}

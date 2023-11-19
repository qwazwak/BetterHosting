using System.Threading.Tasks;
using System.Threading;
using System;
using System.Diagnostics.CodeAnalysis;

namespace DSharpPlus.BetterHosting.Services.Interfaces;

/// <summary>
/// Controller of a singleton
/// </summary>
/// <remarks>Should rarly be depended upon, and usually the singleton should be accessed through a <see cref="ISingletonProvider{T}"/></remarks>
/// <typeparam name="T"></typeparam>
public interface ISingletonManager<T>
{
    /// <inheritdoc cref="ISingletonProvider{T}.WaitAsync(CancellationToken)"/>
    ValueTask<T> WaitAsync(CancellationToken cancellationToken);

    /// <inheritdoc cref="ISingletonProvider{T}.TryGetNow(out T)"/>
    public bool TryGetNow([NotNullWhen(true), MaybeNullWhen(false)] out T value);

    /// <summary>
    /// Sets this event to unblock callers of <see cref="WaitAsync(CancellationToken)"/> while giving thgem <paramref name="value"/>.
    /// </summary>
    void Set(T value);
    /// <summary>
    /// Sets this event to unblock callers of <see cref="WaitAsync(CancellationToken)"/> while throwing (for them) the <paramref name="exception"/>.
    /// </summary>
    void SetException(Exception exception);
    /// <summary>
    /// Sets this event to unblock callers of <see cref="WaitAsync(CancellationToken)"/> by cancelling them.
    /// </summary>
    void SetCancelled(CancellationToken reason = default);
}

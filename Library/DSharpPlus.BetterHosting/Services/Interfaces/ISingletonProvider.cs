using System.Threading.Tasks;
using System.Threading;
using System.Diagnostics.CodeAnalysis;

namespace DSharpPlus.BetterHosting.Services.Interfaces;

/// <summary>
/// Allows accessing of an asynchronously available singleton
/// </summary>
/// <typeparam name="T"></typeparam>
public interface ISingletonProvider<T>
{
    /// <summary>
    /// Returns a task that will be completed when this event is set.
    /// </summary>
    /// <param name="cancellationToken">A cancellation token.</param>
    /// <returns>A task that completes when the event is set, or cancels with the <paramref name="cancellationToken"/>.</returns>
    ValueTask<T> WaitAsync(CancellationToken cancellationToken = default);

    /// <summary>
    /// Without the weight of asynchronous blocking, quickly checks if the singleton is available.
    /// </summary>
    /// <param name="value"></param>
    bool TryGetNow([NotNullWhen(true), MaybeNullWhen(false)] out T value);
}

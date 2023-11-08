using System;
using System.Threading;
using System.Threading.Tasks;
using DSharpPlus.BetterHosting.Services.Interfaces;

namespace DSharpPlus.BetterHosting.Services.Extensions;

/// <summary>
/// Extension methods which derive functionality from the base methods of <see cref="IConnectedClientProvider"/>
/// </summary>
public static class IConnectedClientProviderExtensions
{
    /// <summary>
    /// Wrapper to wait for <see cref="IConnectedClientProvider.GetClientAsync(CancellationToken)"/> synchronously
    /// </summary>
    /// <param name="provider"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public static DiscordShardedClient GetClient(this IConnectedClientProvider provider, CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(provider);
        ValueTask<DiscordShardedClient> vt = provider.GetClientAsync(cancellationToken);
        if (vt.IsCompletedSuccessfully)
            return vt.GetAwaiter().GetResult();

        Task<DiscordShardedClient> task = vt.AsTask();
        Task<DiscordShardedClient> waitingTask = task.WaitAsync(cancellationToken);
        return waitingTask.GetAwaiter().GetResult();
    }
}
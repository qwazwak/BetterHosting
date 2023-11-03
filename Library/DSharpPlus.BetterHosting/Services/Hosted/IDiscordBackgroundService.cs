using System.Threading;
using System.Threading.Tasks;

namespace DSharpPlus.BetterHosting.Services.Hosted;

/// <summary>
/// Interface to flag a type to be run under a <see cref="Microsoft.Extensions.Hosting.BackgroundService"/>
/// </summary>
public interface IDiscordBackgroundService
{
    /// <summary>
    /// Called once after the <paramref name="client"/> has been connected
    /// </summary>
    /// <param name="client"></param>
    /// <param name="stoppingToken"></param>
    /// <returns>A task, completion of which will end the service and dispose the instance</returns>
    Task AfterConnected(DiscordShardedClient client, CancellationToken stoppingToken);
}
using System.Threading;
using System.Threading.Tasks;
using DSharpPlus.Entities;

namespace DSharpPlus.BetterHosting.Services.Interfaces;

/// <summary>
/// Interface for proving the default activity with which DSharpPlus will connect with
/// </summary>
public interface IDiscordDefaultActivityProvider
{
    /// <summary>
    /// Called once to get the initial <see cref="DiscordActivity"/>
    /// </summary>
    /// <param name="cancellationToken"></param>
    public ValueTask<DiscordActivity> DefaultActivity(CancellationToken cancellationToken);
}

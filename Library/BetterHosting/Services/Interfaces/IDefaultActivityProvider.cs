using DSharpPlus.Entities;

namespace BetterHosting.Services.Interfaces;

/// <summary>
/// Interface for proving the default activity with which DSharpPlus will connect with
/// </summary>
public interface IDefaultActivityProvider
{
    /// <summary>
    /// Called once to get the initial <see cref="DiscordActivity"/>
    /// </summary>
    public DiscordActivity DefaultActivity { get; }
}

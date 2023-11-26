using BetterHosting.Services.Interfaces;
using DSharpPlus.Entities;

namespace BetterHosting.Services.Implementation;

/// <summary>
/// The most basic implementation of <see cref="IDefaultActivityProvider"/>
/// </summary>
internal class InstanceActivityProvider : IDefaultActivityProvider
{
    public InstanceActivityProvider(DiscordActivity defaultActivity) => DefaultActivity = defaultActivity;

    /// <inheritdoc/>
    public DiscordActivity DefaultActivity { get; }
}
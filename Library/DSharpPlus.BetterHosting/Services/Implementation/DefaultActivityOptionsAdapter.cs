using DSharpPlus.BetterHosting.Services.Interfaces;
using DSharpPlus.Entities;
using Microsoft.Extensions.Options;

namespace DSharpPlus.BetterHosting.Services.Implementation;

/// <summary>
/// Simple implementation of <see cref="IDefaultActivityProvider"/> which exposed the default <see cref="IOptions{TOptions}"/> of <see cref="DiscordActivity"/> as the <see cref="IDefaultActivityProvider.DefaultActivity"/>
/// </summary>
public sealed class DefaultActivityOptionsAdapter : IDefaultActivityProvider
{
    private readonly IOptions<DiscordActivity> activity;

    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="activity"></param>
    public DefaultActivityOptionsAdapter(IOptions<DiscordActivity> activity) => this.activity = activity;

    /// <inheritdoc/>
    public DiscordActivity DefaultActivity => activity.Value;
}
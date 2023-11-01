using System;
using System.Threading;
using System.Threading.Tasks;
using DSharpPlus.BetterHosting.Services.Interfaces;
using DSharpPlus.Entities;
using Microsoft.Extensions.Logging;

namespace DSharpPlus.BetterHosting.Services.Hosted;

internal class DiscordActivityStateController : IDiscordBackgroundService
{
    private readonly ILogger<DiscordActivityStateController> logger;
    private readonly IDiscordDefaultActivityProvider activityProvider;

    public DiscordActivityStateController(ILogger<DiscordActivityStateController> logger, IDiscordDefaultActivityProvider activityProvider)
    {
        this.logger = logger;
        this.activityProvider = activityProvider;
    }

    /// <inheritdoc/>
    public async Task AfterConnected(DiscordShardedClient client, CancellationToken stoppingToken)
    {
        try
        {
            ValueTask<DiscordActivity> status = activityProvider.DefaultActivity(stoppingToken);
            await client.UpdateStatusAsync(await status, UserStatus.Online);
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Unable to startup client due to unexpected exception {type}: {message}", ex.GetType(), ex.Message);
            throw;
        }
    }
}
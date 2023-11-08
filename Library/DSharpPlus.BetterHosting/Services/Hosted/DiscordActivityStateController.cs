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
    private readonly IDefaultActivityProvider activityProvider;

    public DiscordActivityStateController(ILogger<DiscordActivityStateController> logger, IDefaultActivityProvider activityProvider)
    {
        this.logger = logger;
        this.activityProvider = activityProvider;
    }

    /// <inheritdoc/>
    public async Task AfterConnected(DiscordShardedClient client, CancellationToken stoppingToken)
    {
        try
        {
            DiscordActivity status = activityProvider.DefaultActivity;
            logger.LogDebug("Attempting to set initial activity to {activity}", status);
            await client.UpdateStatusAsync(status, UserStatus.Online);
            logger.LogInformation("Initial activity set successfully");
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Unable to startup client due to unexpected exception {type}: {message}", ex.GetType(), ex.Message);
            throw;
        }
    }
}
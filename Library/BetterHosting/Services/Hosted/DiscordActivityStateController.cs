using System.Threading;
using System.Threading.Tasks;
using BetterHosting.Services.Interfaces;
using DSharpPlus;
using DSharpPlus.Entities;
using Microsoft.Extensions.Logging;

namespace BetterHosting.Services.Hosted;

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
        DiscordActivity status = activityProvider.DefaultActivity;
        logger.LogDebug("Attempting to set initial activity to {activity}", status);
        await client.UpdateStatusAsync(status, UserStatus.Online);
        logger.LogInformation("Initial activity set successfully");
    }
}
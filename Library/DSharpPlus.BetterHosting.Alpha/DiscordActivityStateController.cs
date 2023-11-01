using System.Diagnostics;
using System;
using System.Threading;
using System.Threading.Tasks;
using DSharpPlus.BetterHosting.Services.Interfaces;
using DSharpPlus.Entities;
using Microsoft.Extensions.Logging;

namespace DSharpPlus.BetterHosting.Services.Hosted;

public class DiscordActivityStateController : IDiscordBackgroundService
{
    private readonly ILogger<DiscordActivityStateController> logger;
    private readonly IDiscordDefaultActivityProvider activityProvider;
#if ActivityChanged
    private readonly IDiscordActivityChangedProvider? activityChangedProvider;
#endif
    private DiscordShardedClient client = default!;

    public DiscordActivityStateController(ILogger<DiscordActivityStateController> logger, IDiscordDefaultActivityProvider activityProvider)
#if ActivityChanged
    public DiscordActivityStateController(ILogger<DiscordActivityStateController> logger, IDiscordDefaultActivityProvider activityProvider, IOptionalService<IDiscordActivityChangedProvider> activityChangedProvider)
#endif
    {
        this.logger = logger;
        this.activityProvider = activityProvider;
#if ActivityChanged
        this.activityChangedProvider = activityChangedProvider.Service;
#endif
    }

    /// <inheritdoc/>
    public async Task AfterConnected(DiscordShardedClient client, CancellationToken stoppingToken)
    {
        Debug.Assert(this.client == null);
        this.client = client;
        Task setInitialActivity = SetInitialActivity(stoppingToken);
        Task handleEvents;

#if ActivityChanged
        if (activityChangedProvider is not null)
            handleEvents = HandleEvents(stoppingToken);
        else
#endif
            handleEvents = Task.CompletedTask;

        await Task.WhenAll(setInitialActivity, handleEvents);
        //No need for below: if we have a changed handler, it will keep the task running. if we don't: exiting early is good
        //await Task.Delay(Timeout.Infinite, stoppingToken);
    }
    private async Task SetInitialActivity(CancellationToken stoppingToken)
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

#if ActivityChanged
    private async Task HandleEvents(CancellationToken stoppingToken)
    {
        Debug.Assert(activityChangedProvider is not null);
        List<IAsyncDisposable> tokenRegistrations = new();
        try
        {
            tokenRegistrations.Add(stoppingToken.Register(DisconnectHandler));

            activityChangedProvider.ActivityChanged += ActivityChanged;
            await Task.Delay(Timeout.Infinite, stoppingToken);
        }
        finally
        {
            List<Task> disposals = new(tokenRegistrations.Count);
            foreach (IAsyncDisposable d in tokenRegistrations)
            {
                ValueTask vt = d.DisposeAsync();
                if (vt.IsCompletedSuccessfully)
                    vt.GetAwaiter().GetResult();
                else
                    disposals.Add(vt.AsTask());
            }
            await Task.WhenAll(disposals);
        }
    }
    private void DisconnectHandler()
    {
        if (activityChangedProvider is not null)
            activityChangedProvider.ActivityChanged -= ActivityChanged;
    }

    async Task ActivityChanged(IDiscordActivityChangedProvider sender, DiscordActivityChangedArgs args)
    {
        try
        {
            Debug.Assert(client != null);
            await client.UpdateStatusAsync(args.Activity!, args.UserStatus, args.IdleSince);
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Failed to update activity when changed");
            throw;
        }
    }
#endif
}
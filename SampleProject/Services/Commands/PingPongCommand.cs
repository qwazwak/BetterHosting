using DSharpPlus.Entities;
using DSharpPlus.SlashCommands;
using DSharpPlus;
using System.Threading.Tasks;
using System;
using Microsoft.Extensions.Logging;

namespace SampleProject.Services.Commands;

public class PingPongCommand : ApplicationCommandModule
{
    private readonly ILogger<PingPongCommand> logger;

    public PingPongCommand(ILogger<PingPongCommand> logger) => this.logger = logger;

    [SlashCommand("ping", "A slash command made to showcase the DSharpPlus.BetterHosting extension!")]
    public async Task PingPong(InteractionContext ctx)
    {
        await ctx.CreateResponseAsync(InteractionResponseType.DeferredChannelMessageWithSource);

        TimeSpan latency = TimeSpan.FromMilliseconds(ctx.Client.Ping);
        await ctx.EditResponseAsync(new DiscordWebhookBuilder().WithContent($"Pong, gateway latency: {latency}"));

        logger.LogDebug("User {name} checked latency and got {duration}.", ctx.Member.Username, latency);
    }
}

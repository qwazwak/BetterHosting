using DSharpPlus.Entities;
using DSharpPlus.SlashCommands;
using DSharpPlus;
using System.Threading.Tasks;
using System;

namespace SampleProject.Services.Commands;

public class PingPongCommand : ApplicationCommandModule
{
    [SlashCommand("ping", "A slash command made to showcase the DSharpPlus.BetterHosting extension!")]
    public async Task PingPong(InteractionContext ctx)
    {
        await ctx.CreateResponseAsync(InteractionResponseType.DeferredChannelMessageWithSource);
        TimeSpan latency = TimeSpan.FromMilliseconds(ctx.Client.Ping);
        //Some time consuming task like a database call or a complex operation
        await ctx.EditResponseAsync(new DiscordWebhookBuilder().WithContent($"Pong, gateway latency: {latency}"));
    }
}

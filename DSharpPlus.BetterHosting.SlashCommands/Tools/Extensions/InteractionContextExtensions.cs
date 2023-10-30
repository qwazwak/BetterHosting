using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DSharpPlus.Entities;
using DSharpPlus.SlashCommands;

namespace DSharpPlus.BetterHosting.SlashCommands.Tools.Extensions;

public static class InteractionContextExtensions
{
    public static Task EditResponseAsync(this InteractionContext ctx, string message, IEnumerable<DiscordAttachment>? attachments = null)
    {
        ArgumentNullException.ThrowIfNull(ctx);
        ArgumentNullException.ThrowIfNull(message);
        DiscordWebhookBuilder builder = new DiscordWebhookBuilder().WithContent(message);
        return ctx.EditResponseAsync(builder, attachments!);
    }
}

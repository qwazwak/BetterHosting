using DSharpPlus.CommandsNext;
using System.Threading.Tasks;
using DSharpPlus.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace FreddyBot.Commands;

public abstract class ReactToCommandBase : BaseCommandModule
{
    protected abstract IEnumerable<string> ReactionStrings { get; }
    protected virtual IEnumerable<DiscordEmoji> ReactionEmoji => ReactionStrings.Select(DiscordEmoji.FromUnicode);
    private static DiscordEmoji[] reactionEmoji = null!;
    protected ReactToCommandBase()
    {
        if (reactionEmoji == null)
            Interlocked.CompareExchange(ref reactionEmoji, ReactionEmoji.ToArray(), null);
    }

    protected virtual string NotFoundMessage(ulong messageid) => $"huh? i cannot find a message with ID {messageid}";

    protected async Task ReactTo(CommandContext context, ulong messageid)
    {
        DiscordMessage relatedMessage;
        try
        {
            relatedMessage = await context.Channel.GetMessageAsync(messageid);
        }
        catch (DSharpPlus.Exceptions.NotFoundException)
        {
            await context.RespondAsync(NotFoundMessage(messageid));
            return;
        }

        await context.TriggerTypingAsync();
        //await interaction.deferReply({ ephemeral: true});
        foreach (DiscordEmoji emote in reactionEmoji)
            await relatedMessage.CreateReactionAsync(emote);
    }
}
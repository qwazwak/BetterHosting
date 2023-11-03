using DSharpPlus.CommandsNext;
using System.Threading.Tasks;
using DSharpPlus.CommandsNext.Attributes;
using System.ComponentModel.DataAnnotations;

namespace FreddyBot.Commands;

public sealed class BasedCommand : ReactToCommandBase
{
    private static readonly string[] BasedString = new string[]
    {
        "🅱",
        "🇦",
        "🇸",
        "🇪",
        "🇩"
    };

    protected override string[] ReactionStrings => BasedString;
    protected override string NotFoundMessage(ulong messageid) => $"what is based? no really, i cannot find a message with ID {messageid}";

    [Command("based")]
    [Description("React to a message with based")]
    public Task BasedAsync(CommandContext context, [Description("The message ID you wish to BASED"), Required] ulong messageid)
            => ReactTo(context, messageid);
}

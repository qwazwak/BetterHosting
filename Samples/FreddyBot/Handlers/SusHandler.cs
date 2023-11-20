using System.Threading.Tasks;
using DSharpPlus;
using DSharpPlus.EventArgs;
using DSharpPlus.BetterHosting.EventsNext.Services;
using System.Text.RegularExpressions;
using DSharpPlus.Entities;

namespace FreddyBot.Handlers;

public sealed partial class SusHandler : IMessageCreatedEventHandler
{
    const string ImageURL = "https://i.kym-cdn.com/photos/images/original/001/956/029/c8d.png";
    private readonly SusHelper helper;

    public SusHandler(SusHelper helper) => this.helper = helper;

    [GeneratedRegex(@"\bsus\b", RegexOptions.IgnoreCase)]
    private static partial Regex BuildSusRegex();
    private static readonly Regex regex = BuildSusRegex();

    public ValueTask OnMessageCreated(DiscordClient client, MessageCreateEventArgs args)
    {
        if (args.Message.Author.IsBot || client.CurrentUser.Equals(args.Author))
            return ValueTask.CompletedTask;
        string message = args.Message.Content;
        if (!regex.IsMatch(message))
            return ValueTask.CompletedTask;

        DiscordMessageBuilder builder = ResponseBuilder();
        return new(args.Message.RespondAsync(builder));
    }

    private DiscordMessageBuilder ResponseBuilder() => new()
    {
        Content = helper.BuildStupidString(),
        Embed = new DiscordEmbedBuilder()
        {
            Description = helper.BuildStupidString(),
            Title = helper.BuildStupidString(),
            ImageUrl = ImageURL
        }.Build()
    };
}

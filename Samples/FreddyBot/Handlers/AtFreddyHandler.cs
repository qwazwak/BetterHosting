using System.Threading.Tasks;
using DSharpPlus;
using DSharpPlus.EventArgs;
using FreddyBot.Services;
using System.Linq;
using DSharpPlus.Entities;
using DSharpPlus.BetterHosting.EventsNext.Services;

namespace FreddyBot.Handlers;

public sealed class AtFreddyHandler : IMessageCreatedEventHandler
{
    private readonly ISentimentAnalyzer sentimentAnalyzer;

    public AtFreddyHandler(ISentimentAnalyzer sentimentAnalyzer)
    {
        this.sentimentAnalyzer = sentimentAnalyzer;
    }

    public ValueTask OnMessageCreated(DiscordClient client, MessageCreateEventArgs args)
    {
        if (args.Message.MentionedUsers.Contains(client.CurrentUser))
            return new(OnAtMe(client, args));
        else if (args.Message.Content.Equals($"@<{client.CurrentUser}> bitch", System.StringComparison.InvariantCultureIgnoreCase))
            return new(args.Message.RespondAsync("im here"));
        else
            return ValueTask.CompletedTask;
    }

    private Task OnAtMe(DiscordClient client, MessageCreateEventArgs args)
    {
        string AtMe = FormatAtUser(client.CurrentUser);

        if (args.Message.Content.Equals(AtMe, System.StringComparison.InvariantCultureIgnoreCase))
            return args.Message.RespondAsync("what do you want?");
        return Analyze(client, args);
    }

    readonly double SentimateRangeOuter = 0.45;
    readonly double SentimateRangeInner = 0.10;
    private async Task Analyze(DiscordClient client, MessageCreateEventArgs args)
    {
        await args.Channel.TriggerTypingAsync();
        string rest = args.Message.Content.Replace(FormatAtUser(client.CurrentUser), string.Empty);
        double sentiment = await sentimentAnalyzer.AnalyzeSentiment(rest);
        if (sentiment > SentimateRangeInner)
        {
            if(sentiment > SentimateRangeOuter)
                await args.Message.RespondAsync("aww thanks <3");
            else
                await args.Message.RespondAsync("thanks");
        }
        else if (sentiment < -SentimateRangeInner)
        {
            if (sentiment < -SentimateRangeOuter)
                await args.Message.RespondAsync("fuck you too!");
            else
                await args.Message.RespondAsync("cmon");
        }
        else
        {
            await args.Message.RespondAsync("alright i guess");
        }
    }

    private static string FormatAtUser(DiscordUser user)
    {
        string userId = user.Id.ToString();
        return $"<@{userId}>";
    }
}

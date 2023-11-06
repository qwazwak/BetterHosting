using System.Threading.Tasks;
using DSharpPlus;
using DSharpPlus.EventArgs;
using System;
using FuzzySharp;
using FreddyBot.Services;
using DSharpPlus.BetterHosting.EventsNext.Services;

namespace FreddyBot.Handlers;

public sealed class PHPHandler : IMessageCreatedEventHandler
{
    private readonly ISentimentAnalyzer sentimentAnalyzer;
    public double percentChance;
    public double fractionalChance;

    public double PercentChance { get => percentChance; set => (percentChance, fractionalChance) = (value, value / 100.0); }
    public double FractionalChance { get => fractionalChance; set => (percentChance, fractionalChance) = (value * 100.0, value); }

    private PHPHandler(ISentimentAnalyzer sentimentAnalyzer, double percentChance)
    {
        this.sentimentAnalyzer = sentimentAnalyzer;
        PercentChance = percentChance;
    }

    public PHPHandler(ISentimentAnalyzer sentimentAnalyzer) : this(sentimentAnalyzer, 0.01) { }

    ValueTask IMessageCreatedEventHandler.OnMessageCreated(DiscordClient client, MessageCreateEventArgs args) => OnMessageCreated(args);
    public ValueTask OnMessageCreated(MessageCreateEventArgs args)
    {
        if (!args.Message.Content.Contains("php", StringComparison.InvariantCultureIgnoreCase))
            return ValueTask.CompletedTask;
        return new(OnMessageCreatedAsync(args));
    }

    private async Task OnMessageCreatedAsync(MessageCreateEventArgs args)
    {
        string messageContent = args.Message.Content;
        Task<double> sentimentTask = sentimentAnalyzer.AnalyzeSentiment(messageContent);
        await args.Channel.TriggerTypingAsync();

        int ratio = Fuzz.Ratio(messageContent, "php is a good programming language", FuzzySharp.PreProcess.PreprocessMode.Full);

        if (ratio >= 85)
        {
            await args.Message.RespondAsync("False");
        }
        else
        {
            double sentiment = await sentimentTask;
            if(sentiment > 0.5)
                await args.Message.RespondAsync("False.");
            if(sentiment < -0.4)
                await args.Message.RespondAsync("true that!");
        }
    }
}

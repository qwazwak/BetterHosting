using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using DSharpPlus;
using DSharpPlus.EventArgs;
using System;
using DSharpPlus.BetterHosting.EventsNext.Services;

namespace FreddyBot.Handlers;

public sealed class CreepyHandler : IMessageCreatedEventHandler
{
    private readonly ILogger<SwearJarHandler> logger;
    private readonly Random rng;

    public double percentChance;
    public double fractionalChance;

    public double PercentChance { get => percentChance; set => (percentChance, fractionalChance) = (value, value / 100.0); }
    public double FractionalChance { get => fractionalChance; set => (percentChance, fractionalChance) = (value * 100.0, value); }

    public CreepyHandler(ILogger<SwearJarHandler> logger, Random rng)
    {
        PercentChance = 0.01;
        this.logger = logger;
        this.rng = rng;
    }

    public ValueTask OnMessageCreated(DiscordClient client, MessageCreateEventArgs args)
    {
        if (client.CurrentUser.Equals(args.Author))
        {
            logger.LogTrace("Ignoring message {message} because it was posted by me", args.Message);
            return ValueTask.CompletedTask;
        }

        double value = rng.NextDouble();
        if (value > FractionalChance)
            return ValueTask.CompletedTask;
        logger.LogInformation("Chance of {PercentChance} for creepy hit with value of {value}", PercentChance, value);
        return new(args.Channel.SendMessageAsync("I see all 👀"));
    }
}
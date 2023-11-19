using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using DSharpPlus;
using DSharpPlus.EventArgs;
using FreddyBot.Services;
using DSharpPlus.BetterHosting.EventsNext.Services;

namespace FreddyBot.Handlers;

public sealed class SwearJarHandler : IMessageCreatedEventHandler
{
    private readonly ILogger<SwearJarHandler> logger;
    private readonly ISwearJar swearJar;
    private readonly IProfanityDetector profanityDetector;

    public SwearJarHandler(ILogger<SwearJarHandler> logger, ISwearJar swearJar, IProfanityDetector profanityDetector)
    {
        this.logger = logger;
        this.swearJar = swearJar;
        this.profanityDetector = profanityDetector;
    }

    public ValueTask OnMessageCreated(DiscordClient client, MessageCreateEventArgs args)
    {
        if (args.Message.Author.IsBot || client.CurrentUser.Equals(args.Author))
            return ValueTask.CompletedTask;
        return new(OnMessageCreatedNoBots(args));
    }

    public async Task OnMessageCreatedNoBots(MessageCreateEventArgs args)
    {
        string message = args.Message.Content;
        if (await profanityDetector.ContainsProfanity(message))
        {
            logger.LogInformation("User \"{author}\" said a bad word in message {message}! The swear jar will be updated.", args.Author.Username, message);
            await swearJar.IncrementJar(args.Channel.Guild.Id);
        }
    }
}

using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using DSharpPlus;
using DSharpPlus.EventArgs;
using DSharpPlus.BetterHosting.EventsNext.Services;
using DSharpPlus.Entities;
using System.Linq;
using System.Threading;
using FreddyBot.Services.Implementation;
using System;

namespace FreddyBot.Handlers;

public sealed partial class SusImageHandler : IMessageCreatedEventHandler
{
    private readonly ILogger<SusImageHandler> logger;
    private readonly SusPredictor predictor;
    private readonly SusHelper helper;

    public SusImageHandler(ILogger<SusImageHandler> logger, SusPredictor predictor, SusHelper helper)
    {
        this.logger = logger;
        this.predictor = predictor;
        this.helper = helper;
    }

    public ValueTask OnMessageCreated(DiscordClient client, MessageCreateEventArgs args)
    {
        if (args.Message.Author.IsBot || client.CurrentUser.Equals(args.Author))
            return ValueTask.CompletedTask;
        if (args.Message.Attachments.Count == 0)
            return ValueTask.CompletedTask;

        return new(OnMessageCreatedAsync(args));
    }

    public async Task OnMessageCreatedAsync(MessageCreateEventArgs args)
    {
        CancellationTokenSource cts = new();
        Task<bool> containedSusTask = Task.WhenAny(args.Message.Attachments.Select(a => CheckAttachment(a, cts.Token))).Unwrap();

        bool containedSus = await containedSusTask;
        cts.Cancel();

        if (containedSus)
            await args.Message.RespondAsync(helper.BuildStupidString());

        async Task<bool> CheckAttachment(DiscordAttachment attachment, CancellationToken cancellationToken)
        {
            float[] res;
            try
            {
                res = await predictor.Predict(attachment, cancellationToken);
            }
            catch (OperationCanceledException)
            {
                return false;
            }

            if (res.Length == 0)
            {
                logger.LogDebug("attachment {name} was had no elements labeled sus.", attachment.FileName);
                return false;
            }

            logger.LogDebug("attachment {name} was {amount}% sus.", attachment.FileName, res.Max());
            return res.Any(f => f >= 0.4f);
        }
    }
}

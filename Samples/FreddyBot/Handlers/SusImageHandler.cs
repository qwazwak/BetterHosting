using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using DSharpPlus;
using DSharpPlus.EventArgs;
using BetterHosting.EventsNext.Services;
using DSharpPlus.Entities;
using System.Linq;
using System.Threading;
using FreddyBot.Services.Implementation;
using System;
using System.Collections.Generic;

namespace FreddyBot.Handlers;

public sealed class SusImageHandler : IMessageCreatedEventHandler
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
        IReadOnlyList<DiscordAttachment> attachments = args.Message.Attachments;
        Task<bool>[] tasks = new Task<bool>[args.Message.Attachments.Count];
        CancellationTokenSource cts = new();
        Parallel.For(0, args.Message.Attachments.Count, i => tasks[i] = CheckAttachment(attachments[i], cts.Token));

        bool[] susChecks = await Task.WhenAll(tasks).ConfigureAwait(false);
        bool containedSus = susChecks.Any(i => i);

        if (containedSus)
            await args.Message.RespondAsync(helper.BuildStupidString());

        async Task<bool> CheckAttachment(DiscordAttachment attachment, CancellationToken cancellationToken)
        {
            float[] res;
            try
            {
                res = await predictor.Predict(attachment, cancellationToken).ConfigureAwait(false);
            }
            catch (OperationCanceledException)
            {
                return false;
            }

            if (res.Length == 0)
            {
                logger.LogDebug("attachment {name} had no elements labeled sus.", attachment.FileName);
                return false;
            }

            logger.LogDebug("attachment {name} was {amount}% sus.", attachment.FileName, res.Max() * 100f);
            if(res.Any(f => f >= 0.4f))
            {
                cts.Cancel();
                return true;
            }
            return false;
        }
    }
}

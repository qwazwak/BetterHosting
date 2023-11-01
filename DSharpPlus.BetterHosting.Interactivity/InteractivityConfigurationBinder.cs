using System;
using DSharpPlus.Interactivity;
using Microsoft.Extensions.Configuration;
using DSharpPlus.Entities;
using System.Diagnostics;
using DSharpPlus.Interactivity.Enums;

namespace DSharpPlus.BetterHosting.Interactivity;

internal static class InteractivityConfigurationBinder
{
    internal static void BindValues(InteractivityConfiguration options, IConfiguration section)
    {
        BindBasicValues(options, section);
        BindComplexValues(options, section);
    }

    private static void BindBasicValues(InteractivityConfiguration options, IConfiguration section)
    {
        if (section.GetSection(nameof(InteractivityConfiguration.Timeout)).Value != null)
            options.Timeout = section.GetValue<TimeSpan>(nameof(InteractivityConfiguration.Timeout));

        if (section.GetSection(nameof(InteractivityConfiguration.PollBehaviour)).Value != null)
            options.PollBehaviour = section.GetValue<PollBehaviour>(nameof(InteractivityConfiguration.PollBehaviour));

        if (section.GetSection(nameof(InteractivityConfiguration.ButtonBehavior)).Value != null)
            options.ButtonBehavior = section.GetValue<ButtonPaginationBehavior>(nameof(InteractivityConfiguration.ButtonBehavior));

        if (section.GetSection(nameof(InteractivityConfiguration.PaginationBehaviour)).Value != null)
            options.PaginationBehaviour = section.GetValue<PaginationBehaviour>(nameof(InteractivityConfiguration.PaginationBehaviour));

        if (section.GetSection(nameof(InteractivityConfiguration.PaginationDeletion)).Value != null)
            options.PaginationDeletion = section.GetValue<PaginationDeletion>(nameof(InteractivityConfiguration.PaginationDeletion));

        if (section.GetSection(nameof(InteractivityConfiguration.ResponseBehavior)).Value != null)
            options.ResponseBehavior = section.GetValue<InteractionResponseBehavior>(nameof(InteractivityConfiguration.ResponseBehavior));

        if (section.GetSection(nameof(InteractivityConfiguration.ResponseMessage)).Value != null)
            options.ResponseMessage = section.GetValue<string>(nameof(InteractivityConfiguration.ResponseMessage))!;
    }

    private static void BindComplexValues(InteractivityConfiguration options, IConfiguration section) => BindPaginationEmoji(options, section);

    private static void BindPaginationEmoji(InteractivityConfiguration options, IConfiguration section)
    {
        IConfigurationSection emojiSection = section.GetSection("PaginationEmojis");
        if (!emojiSection.Exists())
            return;
        PaginationEmojis value = new();
        value.SkipLeft = ParseOrDefault(nameof(PaginationEmojis.SkipLeft), value.SkipLeft);
        value.SkipRight = ParseOrDefault(nameof(PaginationEmojis.SkipRight), value.SkipRight);
        value.Left = ParseOrDefault(nameof(PaginationEmojis.Left), value.Left);
        value.Right = ParseOrDefault(nameof(PaginationEmojis.Right), value.Right);
        value.Stop = ParseOrDefault(nameof(PaginationEmojis.Stop), value.Stop);

        options.PaginationEmojis = value;

        DiscordEmoji ParseOrDefault(string name, DiscordEmoji defaultValue)
        {
            Debug.Assert(defaultValue != null!);
            string? result = emojiSection.GetValue<string?>(name, null);
            if (result == null)
                return defaultValue;

            try
            {
                return DiscordEmoji.FromUnicode(result);
            }
            catch (Exception)
            {
                return defaultValue;
            }
        }
    }
}

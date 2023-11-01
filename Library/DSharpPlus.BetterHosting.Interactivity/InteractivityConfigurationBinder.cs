using System;
using DSharpPlus.Interactivity;
using Microsoft.Extensions.Configuration;
using DSharpPlus.Entities;
using System.Diagnostics;
using DSharpPlus.Interactivity.Enums;

namespace DSharpPlus.BetterHosting.Interactivity;
internal static class InteractivityConfigurationBinder
{
    public static void Configure(InteractivityConfiguration options, IConfiguration section, ConfigureInteractivityPaginationEmojiHelper helper)
    {
        ConfigureSimple(options, section);
        if (helper.TryGetPaginationEmoji(section, out PaginationEmojis? newEmoji))
            options.PaginationEmojis = newEmoji;
    }

    internal static void ConfigureSimple(InteractivityConfiguration options, IConfiguration section)
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
}

internal class ConfigureInteractivityPaginationEmojiHelper
{
    public virtual bool TryGetPaginationEmoji(IConfiguration baseConfiguration, out PaginationEmojis value)
    {
        IConfigurationSection emojiSection = baseConfiguration.GetSection("PaginationEmojis");
        if (!emojiSection.Exists())
        {
            value = default!;
            return false;
        }
        value = new();
        GetPaginationEmoji(value, emojiSection);
        return true;
    }
    internal virtual void GetPaginationEmoji(PaginationEmojis value, IConfiguration section)
    {
        value.SkipLeft = ParseOrDefault(section, nameof(PaginationEmojis.SkipLeft), value.SkipLeft);
        value.SkipRight = ParseOrDefault(section, nameof(PaginationEmojis.SkipRight), value.SkipRight);
        value.Left = ParseOrDefault(section, nameof(PaginationEmojis.Left), value.Left);
        value.Right = ParseOrDefault(section, nameof(PaginationEmojis.Right), value.Right);
        value.Stop = ParseOrDefault(section, nameof(PaginationEmojis.Stop), value.Stop);
    }

    internal virtual DiscordEmoji ParseOrDefault(IConfiguration emojiSection, string name, DiscordEmoji defaultValue)
    {
        Debug.Assert(defaultValue != null!);
        if (!emojiSection.GetSection(name).Exists())
            return defaultValue;

        string? result = emojiSection.GetValue<string?>(name, null);
        if (result == null)
            return defaultValue; //TODO: clearly invalid state here

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

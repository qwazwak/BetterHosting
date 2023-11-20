using System.Threading.Tasks;
using FreddyBot.Services;
using DSharpPlus.SlashCommands;
using DSharpPlus.Entities;

namespace FreddyBot.Commands;

public sealed class PasswordCommand : ApplicationCommandModule
{
    private readonly IPasswordGenerator generator;

    public PasswordCommand(IPasswordGenerator generator) => this.generator = generator;

    [SlashCommand("GeneratePassword", "Passwords the bot and returns the gateway latency.")]
    public async Task PasswordAsync(InteractionContext ctx, [Option(nameof(length), "")] long length = 8, [Option(nameof(includeNumbers), "")] bool includeNumbers = true, [Option(nameof(includeSpecialChars), "")] bool includeSpecialChars = true)
    {
        await ctx.DeferAsync(ephemeral: true);

        Task TypingTask =  ctx.Channel.TriggerTypingAsync();
        ValueTask<string> passwordTask = generator.GeneratePassword((int)length, includeNumbers, includeSpecialChars);
        await TypingTask;
        string password = await passwordTask;
        await ctx.EditResponseAsync(new DiscordWebhookBuilder().WithContent($"Heres a password you can use, be sure to keep it secret! `{password}`"));
    }
}
using DSharpPlus.BetterHosting.Services.Interfaces.ExtensionConfigurators;
using DSharpPlus.SlashCommands;

namespace DSharpPlus.BetterHosting.SlashCommands.Services;

public interface ISlashCommandsExtensionConfigurator : IDiscordExtensionConfigurator<SlashCommandsExtension>
{
}
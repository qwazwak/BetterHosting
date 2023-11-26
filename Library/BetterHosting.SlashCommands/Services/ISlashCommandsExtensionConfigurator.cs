using BetterHosting.Services.Interfaces.Extensions;
using DSharpPlus.SlashCommands;

namespace BetterHosting.SlashCommands.Services;

/// <inheritdoc/>
public interface ISlashCommandsExtensionConfigurator : IDiscordExtensionConfigurator<SlashCommandsExtension>
{
}
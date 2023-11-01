﻿using DSharpPlus.BetterHosting.Services.Interfaces.ExtensionConfigurators;
using DSharpPlus.SlashCommands;

namespace DSharpPlus.BetterHosting.SlashCommands.Services;

/// <inheritdoc/>
public interface ISlashCommandsExtensionConfigurator : IDiscordExtensionConfigurator<SlashCommandsExtension>
{
}
﻿using System.Threading.Tasks;

namespace DSharpPlus.BetterHosting.Services.Interfaces;

internal interface IClientConstructor
{
    Task<DiscordShardedClient> ConstructClient();
}
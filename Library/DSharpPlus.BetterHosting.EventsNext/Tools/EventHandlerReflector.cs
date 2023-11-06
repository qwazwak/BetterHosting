﻿#if false
using DSharpPlus.AsyncEvents;
using DSharpPlus.EventArgs;
using DSharpPlus.BetterHosting.EventsNext.Services;

namespace DSharpPlus.BetterHosting.EventsNext.Tools;

internal static partial class EventHandlerReflector
{
    public static partial void BindEvent<THandlerInterface, TArgument>(DiscordShardedClient client, AsyncEventHandler<DiscordClient, TArgument> handler) where THandlerInterface : IDiscordEventHandler<TArgument> where TArgument : DiscordEventArgs;
    public static partial void UnbindEvent<THandlerInterface, TArgument>(DiscordShardedClient client, AsyncEventHandler<DiscordClient, TArgument> handler) where THandlerInterface : IDiscordEventHandler<TArgument> where TArgument : DiscordEventArgs;

    public static partial ValueTask AutoCallEventHandler<TInterface>(IDiscordEventHandler handler, DiscordClient sender, DiscordEventArgs args) where TInterface : IDiscordEventHandler;
    public static partial ValueTask AutoCallEventHandler<TInterface, TArgument>(IDiscordEventHandler<TArgument> handler, DiscordClient sender, TArgument args) where TInterface : IDiscordEventHandler<TArgument> where TArgument : DiscordEventArgs;
}
#endif

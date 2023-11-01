using System.Collections.Generic;
using System;
using System.Threading.Tasks;
using DSharpPlus.AsyncEvents;
using DSharpPlus.EventArgs;
using DSharpPlus.EventsNext.Entities;

namespace DSharpPlus.EventsNext.Tools.Internal;

internal static partial class EventHandlerReflector
{
    public static partial IEnumerable<Type> GetInterfaces<THandlerImplementation>() where THandlerImplementation : IDiscordEventHandler;

    public static partial void BindEvent<THandlerInterface, TArgument>(DiscordShardedClient client, AsyncEventHandler<DiscordClient, TArgument> handler) where THandlerInterface : IDiscordEventHandler<TArgument> where TArgument : DiscordEventArgs;
    public static partial void UnbindEvent<THandlerInterface, TArgument>(DiscordShardedClient client, AsyncEventHandler<DiscordClient, TArgument> handler) where THandlerInterface : IDiscordEventHandler<TArgument> where TArgument : DiscordEventArgs;

    public static partial ValueTask AutoCallEventHandler<THandler, TArgument>(IDiscordEventHandler<TArgument> handler, DiscordClient sender, TArgument args) where THandler : IDiscordEventHandler<TArgument> where TArgument : DiscordEventArgs;
}

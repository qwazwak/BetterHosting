﻿using DSharpPlus.EventArgs;

namespace BetterHosting.EventsNext.Services;

/// <summary>
/// Base of all discord event handlers, does not actually result in functionality
/// </summary>
public interface IDiscordEventHandler { }

/// <typeparam name="TArgs">The argument type when the event is fired</typeparam>
/// <inheritdoc />
public interface IDiscordEventHandler<TArgs> : IDiscordEventHandler where TArgs : DiscordEventArgs { }
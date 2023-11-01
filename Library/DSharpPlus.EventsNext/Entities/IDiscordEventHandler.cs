using DSharpPlus.EventArgs;

namespace DSharpPlus.EventsNext.Entities;

/// <summary>
/// Base of all discord event handlers, does not actually result in functionallity
/// </summary>
public interface IDiscordEventHandler
{
    //Task OnEvent(DiscordClient client, DiscordEventArgs args);
}

/// <typeparam name="TArgs">The argument type when the event is fired</typeparam>
/// <inheritdoc />
public interface IDiscordEventHandler<TArgs> : IDiscordEventHandler where TArgs : DiscordEventArgs
{
#if GenericEventHandler
    System.Threading.Tasks.ValueTask OnEvent(DiscordClient client, TArgs args);
#endif
}
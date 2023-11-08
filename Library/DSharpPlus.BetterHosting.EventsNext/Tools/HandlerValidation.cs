using System;
using DSharpPlus.EventArgs;
using DSharpPlus.BetterHosting.EventsNext.Services;

namespace DSharpPlus.BetterHosting.EventsNext.Tools;
internal static partial class HandlerValidation
{
    /// <inheritdoc cref="IsHandlerCanidate{THandler, TArgument}()"/>
    public static bool IsHandlerCanidate<THandler, TArgument>() where THandler : IDiscordEventHandler where TArgument : DiscordEventArgs => IsHandlerCanidate<THandler, TArgument>(out string _);

    /// <inheritdoc cref="IsHandlerCanidate{THandler}(out string)"/>
    public static bool IsHandlerCanidate<THandler, TArgument>(out string reason) where THandler : IDiscordEventHandler where TArgument : DiscordEventArgs => IsHandlerCanidate<THandler>(out reason);

    /// <summary>
    /// Validates if <typeparamref name="THandler"/> is a valid candidate to be a <see cref="IDiscordEventHandler"/> or not
    /// </summary>
    /// <typeparam name="THandler">The type to check</typeparam>
    /// <param name="reason">If the type is not a valid canidate, the reason why</param>
    /// <returns><see langword="true"/> if <typeparamref name="THandler"/> is a valid <see cref="IDiscordEventHandler"/>, else <see langword="false"/></returns>
    public static partial bool IsHandlerCanidate<THandler>(out string reason) where THandler : IDiscordEventHandler;

    /// <inheritdoc cref="IsHandlerCanidate(Type, out string)"/>
    public static bool IsHandlerCanidate(Type handler) => IsHandlerCanidate(handler, out string _);

    /// <summary>
    /// Validates if a type is a valid candidate to be a <see cref="IDiscordEventHandler"/> or not
    /// </summary>
    /// <param name="handlerType">The type to check</param>
    /// <param name="reason">If the type is not a valid canidate, the reason why</param>
    /// <returns><see langword="true"/> if <paramref name="handlerType"/> is a valid <see cref="IDiscordEventHandler"/>, else <see langword="false"/></returns>
    public static partial bool IsHandlerCanidate(Type handlerType, out string reason);
}

using System;
using DSharpPlus.BetterHosting.EventsNext.Services;

namespace DSharpPlus.BetterHosting.EventsNext.Exceptions;

/// <summary>
/// An exception thrown when the given handler type does not implement any handler interfaces <see cref="IDiscordEventHandler{TArgs}"/>
/// </summary>
[System.Diagnostics.CodeAnalysis.SuppressMessage("Roslynator", "RCS1194:Implement exception constructors.", Justification = "<Pending>")]
public class NoEventHandlerCanidateException : ArgumentException
{
    /// <summary>
    /// The type which was not a valid event handler
    /// </summary>
    public Type InvalidHandlerType { get; }

    /// <summary>
    /// Constructs a new instance of the <see cref="NoEventHandlerCanidateException"/>
    /// </summary>
    /// <param name="paramName">The argument which caused this exception</param>
    /// <param name="invalidHandlerInterface">The type which was not a valid handler</param>
    public NoEventHandlerCanidateException(string? paramName, Type invalidHandlerInterface) : this($"The type {invalidHandlerInterface.Name} was did not implement/was not assignable to any {nameof(EventsNext)} interfaces", paramName, invalidHandlerInterface) { }

    /// <summary>
    /// Constructs a new instance of the <see cref="NoEventHandlerCanidateException"/>
    /// </summary>
    /// <param name="paramName">The argument which caused this exception</param>
    /// <param name="invalidHandlerType">The type which was not a valid handler</param>
    public NoEventHandlerCanidateException(string? message, string? paramName, Type invalidHandlerType) : base(message, paramName) => InvalidHandlerType = invalidHandlerType;

    /// <summary>
    /// Constructs a new instance of the <see cref="NoEventHandlerCanidateException"/>
    /// </summary>
    /// <param name="paramName">The argument which caused this exception</param>
    /// <param name="invalidHandlerType">The type which was not a valid handler</param>
    public NoEventHandlerCanidateException(string? message, string? paramName, Type invalidHandlerType, Exception? innerException) : base(message, paramName, innerException) => InvalidHandlerType = invalidHandlerType;
}

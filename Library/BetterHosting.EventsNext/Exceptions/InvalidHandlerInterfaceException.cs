using System;
using System.Diagnostics.CodeAnalysis;

namespace BetterHosting.EventsNext.Exceptions;

/// <summary>
/// An exception thrown when a method requires the type of one of the exact supported event handler interfaces, but that was not provided
/// </summary>
[SuppressMessage("Roslynator", "RCS1194:Implement exception constructors.", Justification = "Require setting of InvalidHandlerInterface")]
[SuppressMessage("CodeQuality", "IDE0079:Remove unnecessary suppression", Justification = "Suppression is required")]
public class InvalidHandlerInterfaceException : InvalidOperationException
{
    /// <summary>
    /// The interface type which is not valid
    /// </summary>
    public Type InvalidHandlerInterface { get; }

    /// <summary>
    /// Constructs a new instance of the <see cref="InvalidHandlerInterfaceException"/>
    /// </summary>
    /// <param name="invalidHandlerInterface">The type which was not a valid handler interface</param>
    public InvalidHandlerInterfaceException(Type invalidHandlerInterface) : this($"The type {invalidHandlerInterface.Name} was not a valid {nameof(EventsNext)} interface", invalidHandlerInterface) { }

    /// <summary>
    /// Constructs a new instance of the <see cref="InvalidHandlerInterfaceException"/>
    /// </summary>
    /// <param name="invalidHandlerInterface">The type which was not a valid handler interface</param>
    public InvalidHandlerInterfaceException(string? message, Type invalidHandlerInterface) : base(message) => InvalidHandlerInterface = invalidHandlerInterface;

    /// <summary>
    /// Constructs a new instance of the <see cref="InvalidHandlerInterfaceException"/>
    /// </summary>
    /// <param name="invalidHandlerInterface">The type which was not a valid handler interface</param>
    public InvalidHandlerInterfaceException(string? message, Type invalidHandlerInterface, Exception? innerException) : base(message, innerException) => InvalidHandlerInterface = invalidHandlerInterface;
}

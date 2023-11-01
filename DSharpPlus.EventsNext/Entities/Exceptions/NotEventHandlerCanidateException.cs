using System;

namespace DSharpPlus.EventsNext.Entities.Exceptions;

public class NotEventHandlerCanidateException : ArgumentException
{
    public Type InvalidHandlerType { get; }

    public NotEventHandlerCanidateException(string? paramName, Type invalidHandlerInterface) : this($"The type {invalidHandlerInterface.Name} was did not implement/was not assignable to any {nameof(DSharpPlus.EventsNext)} interfaces", paramName, invalidHandlerInterface) { }

    public NotEventHandlerCanidateException(string? message, string? paramName, Type invalidHandlerInterface) : base(message, paramName) => InvalidHandlerType = invalidHandlerInterface;

    public NotEventHandlerCanidateException(string? message, string? paramName, Type invalidHandlerInterface, Exception? innerException) : base(message, paramName, innerException) => InvalidHandlerType = invalidHandlerInterface;
}

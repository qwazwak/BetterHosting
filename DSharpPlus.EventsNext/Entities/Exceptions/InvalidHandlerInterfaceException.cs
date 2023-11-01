using System;
namespace DSharpPlus.EventsNext.Entities.Exceptions;

public class EventsNextTypeException : Exception
{
    public EventsNextTypeException()
    {
    }

    public EventsNextTypeException(string? message) : base(message)
    {
    }

    public EventsNextTypeException(string? message, Exception? innerException) : base(message, innerException)
    {
    }
}

public class InvalidHandlerInterfaceException : InvalidOperationException
{
    public Type InvalidHandlerInterface { get; }

    public InvalidHandlerInterfaceException(Type invalidHandlerInterface) : this($"The type {invalidHandlerInterface.Name} was not a valid {nameof(DSharpPlus.EventsNext)} interface", invalidHandlerInterface) { }

    public InvalidHandlerInterfaceException(string? message, Type invalidHandlerInterface) : base(message) => InvalidHandlerInterface = invalidHandlerInterface;

    public InvalidHandlerInterfaceException(string? message, Type invalidHandlerInterface, Exception? innerException) : base(message, innerException) => InvalidHandlerInterface = invalidHandlerInterface;
}

public class UnsupportedHandlerTypeException : EventsNextTypeException
{
    public Type UnsupportedHandlerType { get; }

    public UnsupportedHandlerTypeException(Type unsupportedHandlerType) => UnsupportedHandlerType = unsupportedHandlerType;

    public UnsupportedHandlerTypeException(string? message, Type unsupportedHandlerType) : base(message) => UnsupportedHandlerType = unsupportedHandlerType;

    public UnsupportedHandlerTypeException(string? message, Type unsupportedHandlerType, Exception? innerException) : base(message, innerException)
    {
        UnsupportedHandlerType = unsupportedHandlerType;
    }
}
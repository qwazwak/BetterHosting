#if false
using System;

namespace DSharpPlus.EventsNext.Entities.Exceptions;

public class UnsupportedHandlerTypeException : InvalidOperationException
{
    public Type UnsupportedHandlerType { get; }

    public UnsupportedHandlerTypeException(Type unsupportedHandlerType) => UnsupportedHandlerType = unsupportedHandlerType;

    public UnsupportedHandlerTypeException(string? message, Type unsupportedHandlerType) : base(message) => UnsupportedHandlerType = unsupportedHandlerType;

    public UnsupportedHandlerTypeException(string? message, Type unsupportedHandlerType, Exception? innerException) : base(message, innerException)
    {
        UnsupportedHandlerType = unsupportedHandlerType;
    }
}
#endif
using System;
using System.Collections.Generic;
using System.Linq;
using BetterHosting.EventsNext.Exceptions;
using DSharpPlus.EventArgs;

namespace UnitTests.BetterHosting.EventsNext.Exceptions;

[TestFixture(TestOf = typeof(InvalidHandlerInterfaceException))]
[TestFixtureSource(typeof(TestData), nameof(TestData.Types))]
public class InvalidHandlerInterfaceExceptionTests
{
    private readonly Type type;

    public InvalidHandlerInterfaceExceptionTests(Type type) => this.type = type;

    [Test]
    public void MinimalConstructor()
    {
        InvalidHandlerInterfaceException ex = new(type);

        Assert.That(ex.InvalidHandlerInterface, Is.SameAs(type));
    }

    [Test]
    [TestCaseSource(typeof(TestData), nameof(TestData.Messages))]
    public void ConstructorWithMessage(string message)
    {
        InvalidHandlerInterfaceException ex = new(message, type);
        Assert.Multiple(() =>
        {
            Assert.That(ex.InvalidHandlerInterface, Is.SameAs(type));
            Assert.That(ex.Message, Is.EqualTo(message));
        });
    }

    [Test]
    [TestCaseSource(typeof(TestData), nameof(TestData.MessagesAndInnerExceptions))]
    public void ConstructorWithMessageAndInner(string message, Exception innerException)
    {
        InvalidHandlerInterfaceException ex = new(message, type, innerException);
        Assert.Multiple(() =>
        {
            Assert.That(ex.InvalidHandlerInterface, Is.SameAs(type));
            Assert.That(ex.Message, Is.EqualTo(message));
            Assert.That(ex.InnerException, Is.SameAs(innerException));
        });
    }
}

file static class TestData
{
    public static readonly Type[] Types = new[]
    {
        typeof(global::BetterHosting.EventsNext.Services.IDiscordEventHandler),
        typeof(global::BetterHosting.EventsNext.Services.IDiscordEventHandler<DiscordEventArgs>),
        typeof(object),
        typeof(int)
    };

    public static readonly string[] Messages = new[]
    {
        "message here"
    };

    public static readonly Exception?[] InnerExceptions = new[]
    {
        new Exception(),
        null,
    };

    public static IEnumerable<object?[]> MessagesAndInnerExceptions =>
        from message in Messages
        from innerException in InnerExceptions
        select new object?[] { message, innerException };
}
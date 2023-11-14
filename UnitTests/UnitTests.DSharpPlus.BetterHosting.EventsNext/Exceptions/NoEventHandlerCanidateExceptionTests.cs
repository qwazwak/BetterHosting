using System;
using System.Collections.Generic;
using System.Linq;
using DSharpPlus.EventArgs;
using DSharpPlus.BetterHosting.EventsNext.Exceptions;

namespace UnitTests.DSharpPlus.BetterHosting.EventsNext.Exceptions;

[TestFixtureSource(typeof(TestData), nameof(TestData.Types))]
[TestFixture(TestOf = typeof(NoEventHandlerCanidateException))]
[System.Diagnostics.CodeAnalysis.SuppressMessage("Usage", "CA2208:Instantiate argument exceptions correctly", Justification = "Fixed for testing")]
public class NoEventHandlerCanidateExceptionTests
{
    const string ParamName = "sdifujgbfvid";

    private readonly Type type;

    public NoEventHandlerCanidateExceptionTests(Type type) => this.type = type;

    [Test]
    public void MinimalConstructor()
    {
        NoEventHandlerCanidateException ex = new(ParamName, type);

        Assert.That(ex.InvalidHandlerType, Is.SameAs(type));
    }

    [Test]
    [TestCaseSource(typeof(TestData), nameof(TestData.Messages))]
    public void ConstructorWithMessage(string message)
    {
        NoEventHandlerCanidateException ex = new(message, ParamName, type);
        Assert.Multiple(() =>
        {
            Assert.That(ex.InvalidHandlerType, Is.SameAs(type));
            Assert.That(ex.Message, Is.EqualTo($"{message} (Parameter '{ParamName}')"));
        });
    }

    [Test]
    [TestCaseSource(typeof(TestData), nameof(TestData.MessagesAndInnerExceptions))]
    public void ConstructorWithMessageAndInner(string message, Exception innerException)
    {
        NoEventHandlerCanidateException ex = new(message, ParamName, type, innerException);
        Assert.Multiple(() =>
        {
            Assert.That(ex.InvalidHandlerType, Is.SameAs(type));
            Assert.That(ex.InvalidHandlerType, Is.SameAs(type));
            Assert.That(ex.Message, Is.EqualTo($"{message} (Parameter '{ParamName}')"));
            Assert.That(ex.InnerException, Is.SameAs(innerException));
        });
    }
}

file static class TestData
{
    public static readonly Type[] Types = new[]
    {
        typeof(global::DSharpPlus.BetterHosting.EventsNext.Services.IDiscordEventHandler),
        typeof(global::DSharpPlus.BetterHosting.EventsNext.Services.IDiscordEventHandler<DiscordEventArgs>),
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
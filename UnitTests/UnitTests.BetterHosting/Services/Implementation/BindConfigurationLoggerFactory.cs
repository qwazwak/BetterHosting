using BetterHosting.Services.Implementation;
using System.Runtime.CompilerServices;
using Microsoft.Extensions.Logging;
using DSharpPlus;

namespace UnitTests.BetterHosting.Services.Implementation;

[TestFixture]
public class BindConfigurationLoggerFactoryTests
{
    [Test]
    public void ConstructorDoesNothing()
    {
        Mock<ILoggerFactory> mockFactory = new(MockBehavior.Strict);

        BindConfigurationLoggerFactory sut = new(mockFactory.Object);
        Assert.That(sut, Is.Not.Null);
        mockFactory.Verify();
    }

    [Test]
    public void TestConstruction()
    {
        ILoggerFactory mockFactory = Mock.Of<ILoggerFactory>(MockBehavior.Strict);

        BindConfigurationLoggerFactory sut = new(mockFactory);

        DiscordConfiguration config = new();
        sut.Configure(config);

        Assert.That(config.GetLoggerFactory(), Is.SameAs(mockFactory));
    }
}

file static class Reflection
{
    [UnsafeAccessor(UnsafeAccessorKind.Method, Name = "get_LoggerFactory")]
    public extern static ILoggerFactory GetLoggerFactory(this DiscordConfiguration @this);
}
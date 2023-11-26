using BetterHosting.Lavalink.Services.Hosted;
using DSharpPlus.Lavalink;
using Microsoft.Extensions.Options;

namespace UnitTests.BetterHosting.Lavalink.Services.Hosted;

[TestFixture(TestOf = typeof(LavalinkBackgroundService))]
public class LavalinkBackgroundServiceTests
{
    private MockRepository repository;

    [SetUp]
    public void SetUp() => repository = new(MockBehavior.Strict);
    [TearDown]
    public void TearDown() => repository.Verify();

    [Test]
    public void ConstructorDoesNothing()
    {
        Mock<IOptions<LavalinkConfiguration>> mockOptions = repository.Create<IOptions<LavalinkConfiguration>>();
        LavalinkBackgroundService sut = new(mockOptions.Object);
        Assert.That(sut, Is.Not.Null);
    }
}
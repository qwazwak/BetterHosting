using System;
using System.Threading.Tasks;
using DSharpPlus;
using DSharpPlus.BetterHosting.Services.Implementation.Internal;
using DSharpPlus.BetterHosting.Services.Interfaces.Internal;
using Microsoft.Extensions.DependencyInjection;

namespace UnitTests.DSharpPlus.BetterHosting.Services.Implementation;

[TestFixture(TestOf = typeof(ShortClientConstructor))]
public class ShortClientConstructorTests
{
    MockRepository repository;
    ShortClientConstructor shortConstructor;

    Mock<IClientConstructor> mockConstructor;
    Mock<IServiceProvider> mockProvider;
    Mock<IServiceScope> mockScope;
    Mock<IServiceScopeFactory> mockFactory;

    [SetUp]
    public void SetUp()
    {
        repository = new(MockBehavior.Strict);

        mockConstructor = repository.Create<IClientConstructor>();

        mockProvider = repository.Create<IServiceProvider>();

        mockScope = repository.Create<IServiceScope>();
        mockScope.Setup(s => s.Dispose()).Verifiable(Times.Once);
        mockScope.Setup(s => s.ServiceProvider).Returns(mockProvider.Object).Verifiable(Times.Once);

        mockFactory = repository.Create<IServiceScopeFactory>();
        mockFactory.Setup(f => f.CreateScope()).Returns(mockScope.Object).Verifiable(Times.Once);
        shortConstructor = new(mockFactory.Object);
    }

    private void ReturnsMock(out DiscordShardedClient expectedClient)
    {
        expectedClient = new(new());
        mockConstructor.Setup(s => s.ConstructClient()).ReturnsAsync(expectedClient).Verifiable(Times.Once);

        mockProvider.Setup(s => s.GetService(typeof(IClientConstructor))).Returns(mockConstructor.Object).Verifiable(Times.Once);
    }

    private void NoMock() => mockProvider.Setup(s => s.GetService(typeof(IClientConstructor))).Returns(() => null).Verifiable(Times.Once);

    [Test]
    public async Task TestConstructClient()
    {
        ReturnsMock(out DiscordShardedClient? expectedClient);

        DiscordShardedClient returnedClient = await shortConstructor.ConstructClient();

        Assert.That(returnedClient, Is.SameAs(expectedClient));
        repository.Verify();
    }

    [Test]
    public void TestNoConstructOr()
    {
        NoMock();

        AsyncTestDelegate constructClient = shortConstructor.ConstructClient;

        Assert.That(constructClient, Throws.TypeOf<InvalidOperationException>());
        repository.Verify();
    }
}
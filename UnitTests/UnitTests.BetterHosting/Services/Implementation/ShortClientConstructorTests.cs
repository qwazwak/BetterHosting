using System;
using System.Threading;
using System.Threading.Tasks;
using DSharpPlus;
using BetterHosting.Services.Implementation.Internal;
using BetterHosting.Services.Interfaces.Internal;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Moq.AutoMock;

namespace UnitTests.BetterHosting.Services.Implementation;

[TestFixture(TestOf = typeof(ShortClientConstructor))]
public class ShortClientConstructorTests
{
    AutoMocker autoMocker;
    ShortClientConstructor shortConstructor;

    Mock<IServiceProvider> mockProvider;
    Mock<IServiceScope> mockScope;
    Mock<IServiceScopeFactory> mockFactory;

    [SetUp]
    public void SetUp()
    {
        autoMocker = new(MockBehavior.Strict);
        autoMocker.Use(Mock.Of<ILogger<ShortClientConstructor>>());

        mockProvider = autoMocker.GetMock<IServiceProvider>();
        mockScope = autoMocker.GetMock<IServiceScope>();
        mockFactory = autoMocker.GetMock<IServiceScopeFactory>();

        mockScope.Setup(s => s.Dispose())
            .Verifiable(Times.Once);

        mockScope.Setup(s => s.ServiceProvider)
            .Returns(mockProvider.Object)
            .Verifiable(Times.Once);

        mockFactory.Setup(f => f.CreateScope())
            .Returns(mockScope.Object)
            .Verifiable(Times.Once);

        shortConstructor = autoMocker.CreateInstance<ShortClientConstructor>();
    }

    [TearDown]
    public void TearDown() => autoMocker.Verify();

    [Test]
    public async Task TestConstructClient()
    {
        DiscordShardedClient expectedClient = new(new());

        Mock<IClientConstructor> mockConstructor = autoMocker.GetMock<IClientConstructor>();
        mockConstructor.Setup(s => s.ConstructClient(CancellationToken.None)).ReturnsAsync(expectedClient).Verifiable(Times.Once);

        mockProvider.Setup(s => s.GetService(typeof(IClientConstructor))).Returns(mockConstructor.Object).Verifiable(Times.Once);

        DiscordShardedClient returnedClient = await shortConstructor.ConstructClient(CancellationToken.None);

        Assert.That(returnedClient, Is.SameAs(expectedClient));
    }

    [Test]
    public void TestNoConstructOr()
    {
        mockProvider.Setup(s => s.GetService(typeof(IClientConstructor))).Returns(() => null).Verifiable(Times.Once);

        Task constructClient() => shortConstructor.ConstructClient(CancellationToken.None);

        Assert.That(constructClient, Throws.TypeOf<InvalidOperationException>());
    }
}
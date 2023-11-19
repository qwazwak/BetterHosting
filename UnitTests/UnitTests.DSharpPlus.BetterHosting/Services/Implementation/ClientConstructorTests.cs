using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;
using DSharpPlus;
using DSharpPlus.BetterHosting.Services.Implementation.Internal;
using DSharpPlus.BetterHosting.Services.Interfaces.Internal;
using Microsoft.Extensions.Options;

namespace UnitTests.DSharpPlus.BetterHosting.Services.Implementation;

[TestFixture(TestOf =typeof(ClientConstructor))]
public class ClientConstructorTests
{
    private MockRepository repository = default!;
    Mock<IOptions<DiscordConfiguration>> mockOptions = default!;
    Mock<IMasterClientConfigurator> mockMaster = default!;
    ClientConstructor sut = default!;

    [SetUp]
    public void SetUp()
    {
        repository = new(MockBehavior.Strict);
        mockMaster = repository.Create<IMasterClientConfigurator>();
        mockOptions = repository.Create<IOptions<DiscordConfiguration>>(); sut = new(mockOptions.Object, mockMaster.Object);
    }

    [Test]
    public void ConstructorDoesNothing()
    {
        Assert.That(sut, Is.Not.Null);
        repository.Verify();
    }

    [Test]
    public async Task TestConstruction()
    {
        List<DiscordShardedClient> clientCapture = new();
        DiscordConfiguration config = new();

        mockOptions.Setup(o => o.Value).Returns(config).Verifiable(Times.Once);
        mockMaster.Setup(m => m.Configure(Capture.In(clientCapture), CancellationToken.None)).Returns(Task.CompletedTask).Verifiable(Times.Once);

        DiscordShardedClient result = await sut.ConstructClient(CancellationToken.None);

        Assert.Multiple(() =>
        {
            Assert.That(clientCapture, Has.One.SameAs(result));
            Assert.That(result.GetConfiguration(), Is.SameAs(config));
        });
        repository.Verify();
    }
}

file static class Reflection
{
    [UnsafeAccessor(UnsafeAccessorKind.Method, Name = "get_Configuration")]
    public extern static DiscordConfiguration GetConfiguration(this DiscordShardedClient @this);
}
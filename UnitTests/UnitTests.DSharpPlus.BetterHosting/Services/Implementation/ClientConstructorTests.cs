using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using DSharpPlus;
using DSharpPlus.BetterHosting.Services.Implementation;
using DSharpPlus.BetterHosting.Services.Interfaces;
using Microsoft.Extensions.Options;

namespace UnitTests.DSharpPlus.BetterHosting.Services.Implementation;

[TestFixture]
public class ClientConstructorTests
{
    [Test]
    public void ConstructorDoesNothing()
    {
        MockRepository repository = new(MockBehavior.Strict);
        Mock<IOptions<DiscordConfiguration>> mockOptions = repository.Create<IOptions<DiscordConfiguration>>();
        Mock<IMasterClientConfigurator> mockMaster = repository.Create<IMasterClientConfigurator>();

        ClientConstructor sut = new(mockOptions.Object, mockMaster.Object);
        Assert.That(sut, Is.Not.Null);
        repository.Verify();
    }

    [Test]
    public async Task TestConstruction()
    {
        MockRepository repository = new(MockBehavior.Strict);
        Mock<IOptions<DiscordConfiguration>> mockOptions = repository.Create<IOptions<DiscordConfiguration>>();
        DiscordConfiguration config = new();
        mockOptions.Setup(o => o.Value).Returns(config).Verifiable(Times.Once);
        TaskCompletionSource tcs = new();
        Mock<IMasterClientConfigurator> mockMaster = repository.Create<IMasterClientConfigurator>();
        List<DiscordShardedClient> clientCapture = new();
        mockMaster.Setup(m => m.Configure(Capture.In(clientCapture))).Returns(tcs.Task).Verifiable(Times.Once);
        ClientConstructor sut = new(mockOptions.Object, mockMaster.Object);

        Task<DiscordShardedClient> task = sut.ConstructClient();
        Assert.That(task.IsCompleted, Is.False);
        repository.Verify();
        tcs.SetResult();
        await Task.Delay(TimeSpan.FromMilliseconds(50));
        DiscordShardedClient result = await task;

        Assert.Multiple(() =>
        {
            Assert.That(result.GetConfiguration(), Is.SameAs(config));
            Assert.That(clientCapture, Has.Count.EqualTo(1));
        });
        Assert.That(clientCapture[0], Is.SameAs(result));
    }
}

file static class Reflection
{
    [UnsafeAccessor(UnsafeAccessorKind.Method, Name = "get_Configuration")]
    public extern static DiscordConfiguration GetConfiguration(this DiscordShardedClient @this);
}
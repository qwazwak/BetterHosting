using System;
using System.Threading;
using System.Threading.Tasks;
using DSharpPlus;
using DSharpPlus.BetterHosting.Services.Extensions;
using DSharpPlus.BetterHosting.Services.Interfaces;

namespace UnitTests.DSharpPlus.BetterHosting.Services.Extensions;

[System.Diagnostics.CodeAnalysis.SuppressMessage("Roslynator", "RCS1196:Call extension method as instance method.", Justification = "Make SUT clear")]
[TestFixture]
public class ConnectedClientProviderExtensionTests
{
    [Test]
    public void ThrowsOnNull()
    {
        ArgumentNullException ex = Assert.Throws<ArgumentNullException>(CallMethod);
        Assert.That(ex.ParamName, Is.EqualTo("provider"));
        static void CallMethod() => IConnectedClientProviderExtensions.GetClient(null!, CancellationToken.None);
    }

    [Test]
    public void ReturnsFast()
    {
        Mock<IConnectedClientProvider> mockProvider = new(MockBehavior.Strict);
        CancellationToken token = new();
        DiscordShardedClient client = null!;
        mockProvider.Setup(p => p.GetClientAsync(token)).Returns(() => ValueTask.FromResult(client)).Verifiable(Times.Once);

        DiscordShardedClient result = IConnectedClientProviderExtensions.GetClient(mockProvider.Object, token);
        Assert.That(result, Is.Null);
        mockProvider.Verify();
    }
    [Test]
    public async Task ReturnsSlow()
    {
        Mock<IConnectedClientProvider> mockProvider = new(MockBehavior.Strict);
        CancellationToken token = new();
        DiscordShardedClient client = null!;
        TaskCompletionSource<DiscordShardedClient> tcs = new();
        mockProvider.Setup(p => p.GetClientAsync(token)).Returns(new ValueTask<DiscordShardedClient>(tcs.Task)).Verifiable(Times.Once);

        Task<DiscordShardedClient> resultTask = Task.Factory.StartNew(() => mockProvider.Object.GetClient(token));
        Assert.That(resultTask.IsCompleted, Is.False);
        tcs.SetResult(client);
        DiscordShardedClient result = await resultTask;
        Assert.That(result, Is.Null);
        mockProvider.Verify();
    }

    [Test]
    public void ThrowsOnCancel()
    {
        CancellationToken token = new(true);
        Mock<IConnectedClientProvider> mockProvider = new(MockBehavior.Strict);
        mockProvider.Setup(p => p.GetClientAsync(token)).Returns(new ValueTask<DiscordShardedClient>(new TaskCompletionSource<DiscordShardedClient>().Task)).Verifiable(Times.Once);

        Assert.Throws<TaskCanceledException>(CallMethod);
        void CallMethod() => IConnectedClientProviderExtensions.GetClient(mockProvider.Object, token);

        mockProvider.Verify();
    }
}
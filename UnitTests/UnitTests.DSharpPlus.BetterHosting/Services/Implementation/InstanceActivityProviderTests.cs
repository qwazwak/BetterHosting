using DSharpPlus.BetterHosting.Services.Implementation;
using DSharpPlus.Entities;

namespace UnitTests.DSharpPlus.BetterHosting.Services.Implementation;

public class InstanceActivityProviderTests
{
    [Test]
    public void IsExactInterface_Generic()
    {
        DiscordActivity activity = new();

        InstanceActivityProvider provider = new(activity);
        for (int i = 0; i < 5; i++)
        {
            DiscordActivity returned = provider.DefaultActivity;
            Assert.That(returned, Is.SameAs(activity));
        }
    }
}
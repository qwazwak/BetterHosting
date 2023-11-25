namespace DSharpPlus.BetterHosting;

[TestFixture]
public class RunsettingsCheckTests
{
    [Test]
    public void CheckForMagicString()
    {
        string? response = TestContext.Parameters["RunsettingsMagicWord"];
        Assert.That(response, Is.Not.Null.Or.Empty);
        Assert.That(response, Is.EqualTo("The magic words"));
    }
}
using System.Threading.Tasks;
using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;

namespace UnitTests.DSharpPlus.BetterHosting.CommandsNext.Stubs;

[System.Diagnostics.CodeAnalysis.SuppressMessage("Roslynator", "RCS1163:Unused parameter.", Justification = "Test Stub")]
[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE0060:Remove unused parameter", Justification = "Test Stub")]
public class StubCommandNextModule : BaseCommandModule
{
    public int Counter_1 { get; private set; }
    public int Counter_2 { get; private set; }

    [Command("test")]
    public Task TestCommand1(CommandContext ctx, int input)
    {
        Counter_1++;
        return Task.CompletedTask;
    }

    [Command("test2")]
    public Task TestCommand2(CommandContext ctx, string input)
    {
        Counter_2++;
        return Task.CompletedTask;
    }
}

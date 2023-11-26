using System;
using DSharpPlus.SlashCommands;

namespace UnitTests.BetterHosting.SlashCommands;

public static class SlashCommandModuleTestData
{
    public static readonly Type[] ApplicationCommandModuleType = new[] { typeof(ApplicationCommandModule) };

    public static readonly Type[] DerivedTypes = new[]
    {
        typeof(Module_Alpha),
        typeof(Module_Beta),
        typeof(Module_Gamma),
        typeof(Module_Delta)
    };
}

file class Module_Alpha : ApplicationCommandModule { }
file class Module_Beta : ApplicationCommandModule { }
file class Module_Gamma : ApplicationCommandModule { }
file abstract class Module_Delta : ApplicationCommandModule { }
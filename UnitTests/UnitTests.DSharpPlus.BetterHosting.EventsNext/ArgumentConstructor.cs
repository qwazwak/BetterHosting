using System;
using DSharpPlus.Entities;
using DSharpPlus.EventArgs;
using System.Collections.Generic;
using System.Reflection;
using System.Runtime.CompilerServices;

namespace UnitTests.DSharpPlus.BetterHosting.EventsNext;

public static class ArgumentConstructor<TArgument> where TArgument : DiscordEventArgs
{
    public static TArgument ConstructArgument()
    {
        if (typeof(TArgument) == typeof(GuildDownloadCompletedEventArgs))
        {
            return (TArgument)(DiscordEventArgs)ConstructGuildDownloadCompletedEventArgs();
        }
        if (typeof(TArgument) == typeof(ModalSubmitEventArgs))
        {
            return (TArgument)(DiscordEventArgs)ConstructModalSubmitEventArgs();
        }

        try
        {
            return Activator.CreateInstance<TArgument>();
        }
        catch
        {
        }

        try
        {
            return ConstructByParameterless();
        }
        catch
        {
            Assert.Inconclusive($"Could not construct argument {typeof(TArgument).Name}");
            return default!;
        }
    }

    private static GuildDownloadCompletedEventArgs ConstructGuildDownloadCompletedEventArgs()
    {
        ConstructorInfo? constructor = typeof(GuildDownloadCompletedEventArgs).GetConstructor(BindingFlags.Instance | BindingFlags.NonPublic, [typeof(IReadOnlyDictionary<ulong, DiscordGuild>)])!;
        Assume.That(constructor, Is.Not.Null);
        return (GuildDownloadCompletedEventArgs)constructor.Invoke([Mock.Of<IReadOnlyDictionary<ulong, DiscordGuild>>()]);
    }

    private static ModalSubmitEventArgs ConstructModalSubmitEventArgs()
    {
        ConstructorInfo? constructor = typeof(ModalSubmitEventArgs).GetConstructor(BindingFlags.Instance | BindingFlags.NonPublic, [typeof(DiscordInteraction)])!;
        Assume.That(constructor, Is.Not.Null);
        DiscordInteraction interaction = new();
        interaction.SetData(new());
        interaction.Data.GetComponents() = new();
        return (ModalSubmitEventArgs)constructor.Invoke([interaction]);
    }

    private static TArgument ConstructByParameterless()
    {
        try
        {
            ConstructorInfo? constructor = typeof(TArgument).GetConstructor(BindingFlags.Instance | BindingFlags.NonPublic, Type.EmptyTypes)!;
            Assume.That(constructor, Is.Not.Null);
            return (TArgument)constructor.Invoke(Array.Empty<object?>());
        }
        catch
        {
            Assert.Inconclusive($"Could not construct argument {typeof(TArgument).Name}");
            return default!;
        }
    }
}

file static class Reflection
{
    [UnsafeAccessor(UnsafeAccessorKind.Method, Name = "set_Data")]
    public extern static void SetData(this DiscordInteraction @this, DiscordInteractionData data);
    [UnsafeAccessor(UnsafeAccessorKind.Field, Name = "_components")]
    public extern static ref List<DiscordActionRowComponent> GetComponents(this DiscordInteractionData @this);
}

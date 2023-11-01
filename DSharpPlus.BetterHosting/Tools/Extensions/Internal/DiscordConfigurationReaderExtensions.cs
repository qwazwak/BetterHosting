using System.Runtime.CompilerServices;

namespace DSharpPlus.BetterHosting.Tools.Extensions.Internal;

internal static class DiscordConfigurationReaderExtensions
{
    [UnsafeAccessor(UnsafeAccessorKind.Method, Name = $"get_{nameof(DiscordConfiguration.Intents)}")]
    public extern static DiscordIntents GetIntents(this DiscordConfiguration @this);
}

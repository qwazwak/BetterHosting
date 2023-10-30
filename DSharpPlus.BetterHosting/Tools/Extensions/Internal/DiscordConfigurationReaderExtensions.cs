using System.Runtime.CompilerServices;
using DSharpPlus;

namespace DiscordExtensions;

internal static class DiscordConfigurationReaderExtensions
{
    [UnsafeAccessor(UnsafeAccessorKind.Method, Name = $"get_{nameof(DiscordConfiguration.Intents)}")]
    public extern static DiscordIntents GetIntents(this DiscordConfiguration @this);
}

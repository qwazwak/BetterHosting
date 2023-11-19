using System;
using System.Collections.Frozen;
using System.Threading.Tasks;
using FreddyBot.Options;
using Microsoft.Extensions.Options;

namespace FreddyBot.Services.Implementation;

public sealed partial class SimpleSwearDetector : IProfanityDetector
{
    private readonly FrozenSet<string> swears;

    /// <summary>
    /// Constructor that initializes the standard profanity list.
    /// </summary>
    public SimpleSwearDetector(IOptions<SwearList> options) => swears = options.Value.ToFrozenSet(StringComparer.OrdinalIgnoreCase);

    ValueTask<bool> IProfanityDetector.ContainsProfanity(string text) => ValueTask.FromResult(ContainsSwear(text));

    public bool ContainsSwear(string text)
    {
        ArgumentNullException.ThrowIfNull(text);
        if (string.IsNullOrWhiteSpace(text))
            return false;

        string[] words = text.Split(' ');

        return swears.Overlaps(words);
    }
}
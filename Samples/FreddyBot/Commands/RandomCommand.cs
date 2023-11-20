using System.Threading.Tasks;
using System;
using DSharpPlus.SlashCommands;

namespace FreddyBot.Commands;

public sealed class RandomSlashCommand : ApplicationCommandModule
{
    private readonly Random random;

    public RandomSlashCommand(Random random) => this.random = random;

    [SlashCommand("random", "Returns a random number within the specified range. Defaults between 0 and 10.")]
    public async Task RandomAsync(InteractionContext context, [Option(nameof(min), "minimum value")] long min = 0, [Option(nameof(max), "maximum value")] long max = 10, [Option(nameof(maxIsInclusive), "true if max is a valid value")] bool maxIsInclusive = true)
    {
        // Ensure that the minimum value is less than or equal to the maximum value.
        if (min > max)
        {
            // Inform the user that they messed up.
            await context.CreateResponseAsync("The minimum value must be less than or equal to the maximum value.");
            return;
        }

        if(maxIsInclusive)
            max++;

        // Respond with the random number.
        await context.CreateResponseAsync($"Your random number is {random.NextInt64(min, max)}.");
    }
}

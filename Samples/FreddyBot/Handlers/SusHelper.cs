using System;

namespace FreddyBot.Handlers;

public class SusHelper
{
    private readonly Random rng;

    public SusHelper(Random rng) => this.rng = rng;

    public string BuildStupidString()
    {
        const string initial = "When the impostor is sus";
        char[] temp = initial.ToCharArray();
        for (int i = 0; i < temp.Length; i++)
        {
            char c = temp[i];
            temp[i] = rng.Next(2) % 2 == 0 ? char.ToUpper(c) : char.ToLower(c);
        }
        return new(temp);
    }
}

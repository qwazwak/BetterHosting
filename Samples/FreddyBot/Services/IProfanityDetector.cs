using System.Threading.Tasks;

namespace FreddyBot.Services;

public interface IProfanityDetector
{
    public ValueTask<bool> ContainsProfanity(string text);
}

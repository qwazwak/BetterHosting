namespace FreddyBot.Services;

public interface IConnectionStringsProvider
{
    public string? Get(string name);
}

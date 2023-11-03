using System.Threading.Tasks;

namespace FreddyBot.Services;

public interface ISentimentAnalyzer
{
    public Task<double> AnalyzeSentiment(string text);
}

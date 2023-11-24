using System.Net.Http;

namespace FreddyBot.Services.Implementation;

public class SusPredictor(HttpClient client) : PredictorBase(client)
{
    private static readonly string[] StaticLabels = ["sus"];
    protected override sealed string[] Labels => StaticLabels;
    protected override string Name => "sus_weights";
}

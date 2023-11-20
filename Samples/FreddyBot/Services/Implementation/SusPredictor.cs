using System.Net.Http;

namespace FreddyBot.Services.Implementation;

public class SusPredictor(HttpClient client) : PredictorBase(client, Labels)
{
    protected override string Name => "sus_weights";
    private static readonly string[] Labels = ["sus"];
}

using System.Threading.Tasks;
using Cowsay.Abstractions;

namespace FreddyBot.Services.Implementation;

public class CowSayRenderer : ICowSayRenderer
{
    private readonly CowCache cowCache;

    public CowSayRenderer(CowCache cowCache) => this.cowCache = cowCache;

    public ValueTask<string> Render(string name, string phrase, string? eyes, string? cowTongue, int? maxCols, bool? isThought)
    {
        ValueTask<ICow> cowVT = cowCache.GetCow(name);
        if (cowVT.IsCompletedSuccessfully)
            return ValueTask.FromResult(RenderImpl(cowVT.GetAwaiter().GetResult(), phrase, eyes, cowTongue, maxCols, isThought));
        else
            return new(cowVT.AsTask().ContinueWith(t => RenderImpl(t.GetAwaiter().GetResult(), phrase, eyes, cowTongue, maxCols, isThought)));
    }
    private static string RenderImpl(ICow cow, string phrase, string? eyes, string? cowTongue, int? maxCols, bool? isThought)
        => cow.Say(phrase, eyes ?? "oo", cowTongue ?? "  ", maxCols ?? 40, isThought ?? false);
}

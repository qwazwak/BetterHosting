using System;
using System.Threading.Tasks;
using SixLabors.ImageSharp;
using Yolov8Net;
using System.Linq;
using System.Threading;
using DSharpPlus.Entities;
using System.IO;
using System.Net.Http;

namespace FreddyBot.Services.Implementation;

public abstract class PredictorBase : IDisposable
{
    protected abstract string[] Labels { get; }
    protected abstract string Name { get; }

    private readonly HttpClient client;
    private readonly IPredictor predictor;

    private bool isDisposed;

    protected PredictorBase(HttpClient client)
    {
        predictor = YoloV5Predictor.Create($"Assets/Weights/{Name}.onnx", Labels);
        this.client = client;
    }

    public Task<float[]> Predict(DiscordAttachment inputFile, CancellationToken cancellationToken) => Predict(inputFile.Url, cancellationToken);
    public async Task<float[]> Predict(string url, CancellationToken cancellationToken)
    {
        Prediction[] predictions;

        using (Stream downloadStream = await client.GetStreamAsync(url, cancellationToken))
        using (Image image = await Image.LoadAsync(downloadStream, cancellationToken))
        {
            predictions = predictor.Predict(image);
        }

        return PostPredict(predictions);
    }

    public float[] Predict(Image image) => PostPredict(predictor.Predict(image));
    private static float[] PostPredict(Prediction[] predictions) => predictions.Select(i => i.Score).ToArray();

    protected virtual void Dispose(bool disposing)
    {
        if (!isDisposed)
        {
            if (disposing)
                predictor.Dispose();

            isDisposed = true;
        }
    }

    public void Dispose()
    {
        // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
        Dispose(disposing: true);
        GC.SuppressFinalize(this);
    }

#if DEBUG
    public class YoloDebugger
    {
#if DrawText
    private static readonly Font font;

    static YoloDebugger()
    {
        FontCollection fontCollection = new();
        font = fontCollection.Add("C:/Windows/Fonts/consola.ttf").CreateFont(11);
    }
#endif
        public void DrawBoxes(Image image, Prediction[] predictions)
        {
            foreach (Prediction prediction in predictions)
                DrawBox(image, prediction);
        }

        public void DrawBox(Image image, Prediction prediction)
        {
            int originalImageHeight = image.Height;
            int originalImageWidth = image.Width;

            int x = (int)Math.Max(prediction.Rectangle.X, 0);
            int y = (int)Math.Max(prediction.Rectangle.Y, 0);
            int width = (int)Math.Min(originalImageWidth - x, prediction.Rectangle.Width);
            int height = (int)Math.Min(originalImageHeight - y, prediction.Rectangle.Height);

            //Note that the output is already scaled to the original image height and width.

            // Bounding Box Text
            string text = $"{prediction.Label?.Name ?? "unlabeled"} [{prediction.Score}]";

            image.Mutate(d => d.Draw(Pens.Solid(Color.Yellow, 2),
                new Rectangle(x, y, width, height)));
#if DrawText
        FontRectangle size = TextMeasurer.MeasureSize(text, new TextOptions(font));
        image.Mutate(d => d.DrawText(text, font, Color.Yellow, new Point(x, (int)(y - size.Height - 1))));
#endif
        }
    }
#endif
}
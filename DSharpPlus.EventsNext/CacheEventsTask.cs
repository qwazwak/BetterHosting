#if false

using System;
using System.Collections.Generic;
using Microsoft.Build.Utilities;
using Microsoft.Build.Framework;
using System.IO;
using System.Net.Http;
using System.Linq;
using System.Text.RegularExpressions;
using System.Text.Json;

namespace BuildHelper;

/// <summary>
/// Downloads a resource with the specified URI to a local file.
/// </summary>
/// <example>Download the Microsoft.com home page.
/// <code><![CDATA[
/// <WebDownload FileUri="http://www.microsoft.com/default.aspx"
///     FileName="microsoft.html" />
/// ]]></code>
/// </example>
/// <example>Download a page from your local intranet protected by Windows Authentication
/// <code><![CDATA[
/// <WebDownload FileUri="http://intranet/default.aspx" FileName="page.html" UseDefaultCredentials="True" />
/// ]]></code>
/// </example>
/// <example>Download a page from a password protected website
/// <code><![CDATA[
/// <WebDownload FileUri="http://example.com/myscore.aspx" FileName="page.html" Username="joeuser" Password="password123" />
/// ]]></code>
/// </example>
public class CacheEventsTask : Task
{
    private readonly JsonSerializerOptions options = new(JsonSerializerOptions.Default)
    {
        WriteIndented = true
    };

    public bool WriteIndented { get => options.WriteIndented; set => options.WriteIndented = value; }

    public TimeSpan MaxAge { get; set; } = TimeSpan.FromHours(6);

    /// <summary>
    /// Gets or sets the name of the local file that is to receive the data.
    /// </summary>
    /// <value>The name of the file.</value>
    [Required]
    public string DownloadURL { get; set; } = "https://raw.githubusercontent.com/DSharpPlus/DSharpPlus/master/DSharpPlus/Clients/DiscordClient.Events.cs";

    /// <summary>
    /// Gets or sets the URI from which to download data.
    /// </summary>
    /// <value>The file URI.</value>
    [Required]
    public string CacheFileName { get => cacheFileName; set => cacheFileName = value.EndsWith(".json") ? value : value + ".json"; }
    /// <summary>
    /// Gets or sets the URI from which to download data.
    /// </summary>
    /// <value>The file URI.</value>
    [Required]
    public string CacheDirectory { get; set; } = default!;

    private string CacheFilePath => Path.Combine(CacheFilePath, CacheFileName);
    private FileInfo CacheFileInfo => new(CacheFilePath);

    private bool ExistingFileIsOK()
    {
        FileInfo file_info = CacheFileInfo;
        if (file_info.Exists)
        {
            if (file_info.CreationTime > DateTime.Now)
                return false;
            if((file_info.CreationTime - DateTime.Now) < MaxAge)
                return true;
        }
        return false;
    }

    public override bool Execute()
    {
        try
        {
            if (ExistingFileIsOK())
                return true;
            if (CacheFileInfo.Exists)
                File.Delete(CacheFilePath);
            System.Threading.Tasks.Task<bool> completion = ExecuteAsync();
            completion.RunSynchronously();
            return completion.GetAwaiter().GetResult();
        }
        catch
        {
            return false;
        }
    }

    public async System.Threading.Tasks.Task<bool> ExecuteAsync()
    {
        List<EventNaming> newResult = await DownloadAndParse();
        await SerializeToFile(newResult);
        return true;
    }

    public async System.Threading.Tasks.Task<List<EventNaming>> GetData()
    {
        if (ExistingFileIsOK())
            return await LoadEventsFromFile();

        List<EventNaming> newResult = await DownloadAndParse();
        await SerializeToFile(newResult);
        return newResult;
    }

    private async System.Threading.Tasks.Task<List<EventNaming>> LoadEventsFromFile()
    {
        string json;
        using (FileStream fs = File.OpenRead(CacheFilePath))
        using (StreamReader reader = new(fs))
        {
            json = await reader.ReadToEndAsync();
        }

        return JsonSerializer.Deserialize<List<EventNaming>>(json, options) ?? throw new InvalidOperationException("Cached file was not a valid format");
    }
    private async System.Threading.Tasks.Task SerializeToFile(List<EventNaming> events)
    {
        string json = JsonSerializer.Serialize(events, options);
        File.WriteAllText(json)
        using FileStream fs = new(CacheFilePath, FileMode.Create, FileAccess.Write);
        using StreamWriter writer = new(fs);
        await writer.WriteAsync(json);
        await writer.FlushAsync();
    }
    private static readonly Regex regex = new("^ *public event AsyncEventHandler<DiscordClient, (?<EventArgType>.+?)> (?<EventName>.+?)$", RegexOptions.ExplicitCapture | RegexOptions.Multiline);

    private List<EventNaming> DownloadAndParse()
    {
        using HttpClient client = new();

        string sourceString = client.GetStringAsync(DownloadURL).GetAwaiter().GetResult();
        MatchCollection matchResult = regex.Matches(sourceString);
        IEnumerable<Match> matches = matchResult.Where(m => m.Success);
        return matches.Select(m => new EventNaming(m.Groups["EventName"].Value, m.Groups["EventArgType"].Value)).ToList();
    }
}
            using (FileStream fs = new(cacheFilePath, FileMode.Create, FileAccess.Write))
            using (StreamWriter writer = new(fs))
            {
                writer.Write(json);
            }
#endif
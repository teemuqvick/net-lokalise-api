using System.Text.Json.Serialization;

namespace Lokalise.Api.Models;

public class ProcessDetails
{
    [JsonPropertyName("download_url")]
    public string? DownloadUrl { get; set; }
    [JsonPropertyName("total_number_of_keys")]
    public int? TotalNumberOfKeys { get; set; }
    [JsonPropertyName("file_size_kb")]
    public int? FileSizeKb { get; set; }
}
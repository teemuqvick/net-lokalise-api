using System.Text.Json.Serialization;

namespace Lokalise.Api.Models;

public class ExportProcess
{
    [JsonPropertyName("process_id")]
    public string? ProcessId { get; set; }
}
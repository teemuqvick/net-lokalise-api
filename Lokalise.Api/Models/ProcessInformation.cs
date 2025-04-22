using System.Text.Json.Serialization;

namespace Lokalise.Api.Models;

public class ProcessInformation
{
    [JsonPropertyName("project_id")]
    public string? ProjectId { get; set; }
    
    [JsonPropertyName("process")]
    public Process? Process { get; set; }
}
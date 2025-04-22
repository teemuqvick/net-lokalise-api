using System.Text.Json.Serialization;

namespace Lokalise.Api.Models;

public class Process
{
    public const string StatusQueued = "queued";
    public const string StatusPreProcessing = "pre_processing";
    public const string StatusRunning = "running";
    public const string StatusPostProcessing = "post_processing";
    public const string StatusCancelled = "cancelled";
    public const string StatusFinished = "finished";
    public const string StatusFailed = "failed";
    
    [JsonPropertyName("process_id")]
    public string? ProcessId { get; set; }
    
    /// <summary>
    /// The type of the process. Can be file-import, sketch-import or bulk-apply-tm.
    /// </summary>
    [JsonPropertyName("type")]
    public string? Type { get; set; }
    
    /// <summary>
    /// Current status of the process.
    /// Can be queued, pre_processing, running, post_processing, cancelled, finished or failed.
    /// </summary>
    [JsonPropertyName("status")]
    public string? Status { get; set; }
    
    [JsonPropertyName("message")]
    public string? Message { get; set; }
    
    [JsonPropertyName("created_by")]
    public int? CreatedBy { get; set; }    
    
    [JsonPropertyName("created_by_email")]
    public string? CreatedByEmail { get; set; }
    
    [JsonPropertyName("created_at")]
    public string? CreatedAt { get; set; }
    
    [JsonPropertyName("created_at_timestamp")]
    public int? CreatedAtTimestamp { get; set; }

    /// <summary>
    /// Contains information for a specific process type.
    /// </summary>
    [JsonPropertyName("details")]
    public ProcessDetails? Details { get; set; }
}
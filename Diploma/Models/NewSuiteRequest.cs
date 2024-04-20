
using System.Text.Json.Serialization;

namespace Diploma.Models
{
    public record NewSuiteRequest
    {
        [JsonPropertyName("title")] public string Title { get; set; }
        [JsonPropertyName("description")] public string? Description { get; set; }
        [JsonPropertyName("preconditions")] public string? Preconditions { get; set; }
        [JsonPropertyName("parent_id")] public int? ParentId { get; set; }
    }
}
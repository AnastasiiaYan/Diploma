using System.Text.Json.Serialization;

namespace Diploma.Models
{
    public record NewProjectRequest
    {
        [JsonPropertyName("title")] public string Title { get; set; }
        [JsonPropertyName("code")] public string Code { get; set; }
        [JsonPropertyName("description")] public string? Description { get; set; }
        [JsonPropertyName("access")] public string? Access { get; set; }
    }
}
using System.Text.Json.Serialization;

namespace Diploma.Models.APIModels
{
    public record NewProjectRequest
    {
        [JsonPropertyName("title")] public string Title { get; set; }
        [JsonPropertyName("code")] public string Code { get; set; }
        [JsonPropertyName("description")] public string? Description { get; set; }
    }
}
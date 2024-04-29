using System.Text.Json.Serialization;

namespace Diploma.Models
{
    public record DeleteProjectResponse
    {
        [JsonPropertyName("status")] public bool StatusValue { get; set; }
    }
}
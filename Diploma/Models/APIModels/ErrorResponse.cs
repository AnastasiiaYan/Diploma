using System.Text.Json.Serialization;

namespace Diploma.Models.APIModels
{
    public record ErrorResponse
    {
        [JsonPropertyName("status")] public bool Status { get; set; }
        [JsonPropertyName("errorMessage")] public string ErrorMessage { get; set; }
    }
}
using System.Text.Json.Serialization;

namespace Diploma.Models.APIModels
{
    public record ProjectErrorResponse
    {
        [JsonPropertyName("status")] public bool Status { get; set; }
        [JsonPropertyName("errorMessage")] public string ErrorMessage { get; set; }
    }
}
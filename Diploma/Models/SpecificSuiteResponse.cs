using System.Text.Json.Serialization;

namespace Diploma.Models
{
    public record SpecificSuiteResponse
    {
        [JsonPropertyName("status")] public bool Status { get; set; }
        [JsonPropertyName("result")] public SpecificSuiteResultData Result { get; set; }
    }

    public class SpecificSuiteResultData
    {
        [JsonPropertyName("id")] public int Id { get; set; }
        [JsonPropertyName("title")] public string Title { get; set; }
        [JsonPropertyName("description")] public string? Description { get; set; }
        [JsonPropertyName("preconditions")] public string? Preconditions { get; set; }
        [JsonPropertyName("position")] public int Position { get; set; }
        [JsonPropertyName("cases_count")] public int CasesCount { get; set; }
    }
}
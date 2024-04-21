using System.Text.Json.Serialization;

namespace Diploma.Models
{
    public record AllSuitesResponse
    {
        [JsonPropertyName("status")] public bool Status { get; set; }
        [JsonPropertyName("result")] public AllSuitesResultData Result { get; set; }
    }

    public class AllSuitesResultData
    {
        [JsonPropertyName("total")] public int Total { get; set; }
        [JsonPropertyName("filtered")] public int Filtered { get; set; }
        [JsonPropertyName("count")] public int Count { get; set; }
        [JsonPropertyName("entities")] public List<SuiteEntity> Entities { get; set; }
    }

    public class SuiteEntity
    {
        [JsonPropertyName("id")] public int Id { get; set; }
        [JsonPropertyName("title")] public string Title { get; set; }
        [JsonPropertyName("description")] public string? Description { get; set; }
        [JsonPropertyName("preconditions")] public string? Preconditions { get; set; }
        [JsonPropertyName("position")] public int Position { get; set; }
        [JsonPropertyName("cases_count")] public int CasesCount { get; set; }
    }
}
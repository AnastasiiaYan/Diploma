using System.Text.Json.Serialization;

namespace Diploma.Models
{
    public record ProjectResponse
    {
        [JsonPropertyName("status")] public bool Status { get; set; }
        [JsonPropertyName("result")] public ProjectResultData Result { get; set; }

        public class ProjectResultData
        {
            [JsonPropertyName("title")] public string Title { get; set; }
            [JsonPropertyName("code")] public string Code { get; set; }
            [JsonPropertyName("counts")] public Counts Counts { get; set; }
        }

        public class Counts
        {
            [JsonPropertyName("cases")] public int Cases { get; set; }
            [JsonPropertyName("suites")] public int Suites { get; set; }
            [JsonPropertyName("milestones")] public int Milestones { get; set; }
            [JsonPropertyName("runs")] public Runs Runs { get; set; }
            [JsonPropertyName("defects")] public Defects Defects { get; set; }
        }

        public class Runs
        {
            [JsonPropertyName("total")] public int Total { get; set; }
            [JsonPropertyName("active")] public int Active { get; set; }
        }

        public class Defects
        {
            [JsonPropertyName("total")] public int Total { get; set; }
            [JsonPropertyName("open")] public int Open { get; set; }
        }
    }
}
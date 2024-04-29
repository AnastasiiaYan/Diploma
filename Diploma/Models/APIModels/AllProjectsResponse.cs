using System.Text.Json.Serialization;

namespace Diploma.Models
{
    public record AllProjectsResponse
    {
        [JsonPropertyName("status")] public bool Status { get; set; }
        [JsonPropertyName("result")] public AllProjectsResultData Result { get; set; }
    }

    public class AllProjectsResultData
    {
        [JsonPropertyName("total")] public int Total { get; set; }
        [JsonPropertyName("filtered")] public int Filtered { get; set; }
        [JsonPropertyName("count")] public int Count { get; set; }
        [JsonPropertyName("entities")] public List<ProjectEntities> ProjectEntities { get; set; }
    }

    public class ProjectEntities
    {
        [JsonPropertyName("title")] public string Title { get; set; }
        [JsonPropertyName("code")] public string Code { get; set; }
        [JsonPropertyName("counts")] public ProjectCounts Counts { get; set; }
    }

    public class ProjectCounts
    {
        [JsonPropertyName("cases")] public int Cases { get; set; }
        [JsonPropertyName("suites")] public int Suites { get; set; }
        [JsonPropertyName("milestones")] public int Milestones { get; set; }
        [JsonPropertyName("runs")] public ProjectRuns Runs { get; set; }
        [JsonPropertyName("defects")] public ProjectDefects Defects { get; set; }
    }

    public class ProjectRuns
    {
        [JsonPropertyName("total")] public int Total { get; set; }
        [JsonPropertyName("active")] public int Active { get; set; }
    }

    public class ProjectDefects
    {
        [JsonPropertyName("total")] public int Total { get; set; }
        [JsonPropertyName("open")] public int Open { get; set; }
    }
}
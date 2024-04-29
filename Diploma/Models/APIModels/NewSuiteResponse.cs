using System.Text.Json.Serialization;
using Newtonsoft.Json;

namespace Diploma.Models.APIModels
{
    public record NewSuiteResponse
    {
        [JsonPropertyName("status")] public bool Status { get; set; }
        [JsonPropertyName("result")] public NewSuiteResultData Result { get; set; }
    }

    public class NewSuiteResultData
    {
        [JsonProperty("id")] public int Id { get; set; }
    }
}
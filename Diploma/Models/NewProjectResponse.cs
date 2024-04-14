using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace Diploma.Models
{
    public record NewProjectResponse
    {
        [JsonPropertyName("status")] public bool Status { get; set; }
        [JsonPropertyName("result")] public NewProjectResultData Result { get; set; }
    }

    public class NewProjectResultData
    {
        [JsonProperty("code")] public string Code { get; set; }
    }
}
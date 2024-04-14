using System.Text.Json.Serialization;

namespace Diploma.Models;

public record SystemFields
{
    public class Root
    {
        [JsonPropertyName("status")]
        public bool Status { get; set; }

        [JsonPropertyName("result")]
        public List<Field> Result { get; set; }
    }
    
    public class Field
    {
        [JsonPropertyName("title")]
        public string Title { get; set; }

        [JsonPropertyName("slug")]
        public string Slug { get; set; }

        [JsonPropertyName("default_value")]
        public string DefaultValue { get; set; }

        [JsonPropertyName("is_required")]
        public bool IsRequired { get; set; }

        [JsonPropertyName("entity")]
        public int Entity { get; set; }

        [JsonPropertyName("type")]
        public int Type { get; set; }

        [JsonPropertyName("input_type")]
        public int InputType { get; set; }

        [JsonPropertyName("options")]
        public List<Option> Options { get; set; }
    }
    public class Option
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("title")]
        public string Title { get; set; }

        [JsonPropertyName("slug")]
        public string Slug { get; set; }

        [JsonPropertyName("color")]
        public string Color { get; set; }

        [JsonPropertyName("icon")]
        public string Icon { get; set; }

        [JsonPropertyName("is_default")]
        public bool IsDefault { get; set; }

        [JsonPropertyName("read_only")]
        public bool ReadOnly { get; set; }
    }
}
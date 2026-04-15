using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace AICopilot.Application.DTOS
{
    public class AIToolDefination
    {
        public string Name { get; }
        public string Description { get; }
        public ToolParameterSchema Parameters { get; }

        public AIToolDefination(
            string name,
            string description,
            ToolParameterSchema parameters)
        {
            Name = name ?? throw new ArgumentNullException(nameof(name));
            Description = description ?? throw new ArgumentNullException(nameof(description));
            Parameters = parameters ?? throw new ArgumentNullException(nameof(parameters));
        }
    }

    public class ToolParameterSchema
    {
        [JsonPropertyName("type")]
        public string Type { get; set; } = "object";

        [JsonPropertyName("properties")]
        public Dictionary<string, ToolProperty> Properties { get; init; }
            = new();

        [JsonPropertyName("required")]
        public List<string> Required { get; init; }
            = new();
    }

    public class ToolProperty
    {
        [JsonPropertyName("type")]
        public string Type { get; set; } = default!;

        [JsonPropertyName("description")]
        public string? Description { get; set; }
    }

}

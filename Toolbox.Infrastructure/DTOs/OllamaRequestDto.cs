using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Toolbox.Infrastructure.DTOs
{
    public class OllamaRequestDto
    {
        [JsonPropertyName("model")]
        public string Model { get; set; }
        
        [JsonPropertyName("prompt")]
        public string Prompt { get; set; }

        [JsonPropertyName("stream")]
        public bool Stream { get; set; } = true;

        // Optional: Add other Ollama request parameters
        [JsonPropertyName("context")]
        public string Context { get; set; }

        [JsonPropertyName("options")]
        public OllamaOptionsDto Options { get; set; }
    }
}

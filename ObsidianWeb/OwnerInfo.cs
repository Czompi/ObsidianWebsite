using System.Text.Json.Serialization;

namespace PluginsWeb
{
    public class OwnerInfo
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("url")]
        public string Url { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace PluginsWeb
{
    public class Plugins
    {
        [JsonPropertyName("obsidian-categories")]
        public Dictionary<string, string> ObsidianCategories { get; set; }
        [JsonPropertyName("obsidian")]
        public Dictionary<string, Plugin> Obsidian { get; set; }

        [JsonPropertyName("spigot")]
        public Dictionary<string, Plugin> Spigot { get; set; }
    }

    public class Plugin
    {
        [JsonPropertyName("id")]
        public string Id { get; set; }

        [JsonPropertyName("icon")]
        public string Icon { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("short_description")]
        public string ShortDescription { get; set; }

        [JsonPropertyName("description")]
        public string Description { get; set; }

        [JsonPropertyName("rating")]
        public double Rating { get; set; }

        [JsonPropertyName("author")]
        public string Author { get; set; }

        [JsonPropertyName("version_url_template")]
        public string VersionUrlTemplate { get; set; }

        [JsonPropertyName("versions")]
        public List<VersionInfo> Versions { get; set; }
    }

    public class VersionInfo
    {
        [JsonPropertyName("version")]
        public string Version { get; set; }

        [JsonPropertyName("change_log")]
        public string ChangeLog { get; set; }

        [JsonPropertyName("release_date")]
        public string ReleaseDate { get; set; }
    }
}
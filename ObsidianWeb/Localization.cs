
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;

namespace PluginsWeb
{
    public class Localization
    {
        [JsonPropertyName("Language")]
        public Info Language { get; set; }

        [JsonPropertyName("Translations")]
        public Dictionary<string, Translation> Translations { get; set; }

        public string GetTranslatedString(string key)
        {
            var elem = Translations.Where(x => x.Key == key).ToList();
            if (elem.Count == 0) return key;
            var response = elem.FirstOrDefault().Value.Translated ?? elem.FirstOrDefault().Value.Original;
            return response;
        }
    }

    public class Info
    {
        [JsonPropertyName("Name")]
        public string Name { get; set; }

        [JsonPropertyName("EnglishName")]
        public string EnglishName { get; set; }
    }

    public class Translation
    {
        [JsonPropertyName("Comment")]
        public string Original { get; set; }

        [JsonPropertyName("Value")]
        public string Translated { get; set; }
    }
}
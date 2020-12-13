using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace PluginsWeb
{
    public class PageList: Dictionary<string, PageItem>
    {

    }

    public class PageItem
    {
        [JsonPropertyName("is_listed")]
        public bool IsListed { get; set; }
    }
}
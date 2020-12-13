using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace PluginsWeb
{
    public class Brand
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }
        
        [JsonPropertyName("url")]
        public string Url { get; set; }

        [JsonPropertyName("owner")]
        public OwnerInfo Owner { get; set; }

        [JsonPropertyName("authors")]
        public List<string> Authors { get; set; }

    }
}

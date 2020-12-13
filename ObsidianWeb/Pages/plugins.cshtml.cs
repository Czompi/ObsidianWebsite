using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace PluginsWeb.Pages
{
    public class ObsidianModel : PageModel
    {
        public ObsidianModel()
        {
            if (System.IO.File.Exists("plugins.json")) Globals.Plugins = JsonSerializer.Deserialize<Plugins>(System.IO.File.ReadAllText("plugins.json"), Globals.jso);
        }

        public string Id { get; private set; }
        public string Category { get; private set; }

        [HttpGet]
        [Route("{id?}/{category?}")]
        public void OnGet(string id=null, string category = null)
        {
            Response.Headers.Add("Access-Control-Allow-Origin", "https://cdn.czompisoftware.hu");
            Response.Headers.Add("Access-Control-Allow-Methods", "*");
            Response.Headers.Add("Access-Control-Allow-Headers", "Origin, X-Requested-With, Content-Type, Accept, Authorization");
            this.Id = id;
            this.Category = category;
        }
    }
}

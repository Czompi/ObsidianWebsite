using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text.Json;
using System.Threading.Tasks;

namespace PluginsWeb
{
    public class Program
    {
        public static void Main(string[] args)
        {

            #region Config
            if (File.Exists("pages.json"))
                Globals.PageList = JsonSerializer.Deserialize<PageList>(File.ReadAllText("pages.json"));
            else
                File.WriteAllText("pages.json", JsonSerializer.Serialize(Globals.Default.PageList));
            Globals.PageList ??= Globals.Default.PageList;
            #endregion

            #region Brand
            if (File.Exists("brand.json"))
                Globals.Brand = JsonSerializer.Deserialize<Brand>(File.ReadAllText("brand.json"));
            else
                File.WriteAllText("brand.json", JsonSerializer.Serialize(Globals.Default.Brand));
            Globals.Brand ??= Globals.Default.Brand;
            #endregion
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    Globals.TranslationHanlder = new LanguageHandler(Assembly.GetExecutingAssembly());
                    Globals.Translation = Globals.TranslationHanlder.Current;
                    webBuilder.UseStartup<Startup>();
                });
    }
}

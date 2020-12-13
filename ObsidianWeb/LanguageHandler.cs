using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Resources;
using System.Text;
using System.Text.Json;
using System.Text.RegularExpressions;

namespace PluginsWeb
{
    public class LanguageHandler
    {
        public Localization Current;
        public Localization Default;
        internal static Assembly parentAssembly;

        public LanguageHandler(Assembly parentAssembly)
        {
            LanguageHandler.parentAssembly = Assembly.GetCallingAssembly();
            var osLang = CultureInfo.CurrentCulture.Name.Replace('-', '_');
            //Console.WriteLine(osLang);
            var list = new List<Localization>();

            var files = parentAssembly.GetManifestResourceNames();
            try
            {
                Default = LoadLocalization($"Resources/Lang/{osLang}.json");
            }
            catch (Exception)
            {
                Default = LoadLocalization("Resources/Lang/en.json");
            }
            finally
            {
                Default.Language.EnglishName = Default.Translations["languages.osdefault"].Original;
                Default.Language.Name = Default.Translations["languages.osdefault"].Translated;
            }
            list.Add(Default);

            foreach (string file in files)
            {
                //Console.WriteLine(entry);
                if (file.EndsWith(".hl3n")) list.Add(LoadLocalization(file));
            }
            Current = list[0];
        }

        public Localization FromCode(string languageCode)
        {
            Localization lang = null;
            try
            {
                lang = LoadLocalization($"Resources/Lang/{languageCode}.hl3n");
            }
            catch (Exception)
            {
                lang = Default;
            }
            return lang;
        }

        private Localization LoadLocalization(string entry)
        {
            if(!entry.StartsWith($"{parentAssembly.GetName().Name}"))
                entry = $"{parentAssembly.GetName().Name}.{entry.Replace("/", ".")}";
            //Logger.Debug(entry);
            try
            {
                var resourceStream = parentAssembly.GetManifestResourceStream(entry);

                using (var sr = new StreamReader(resourceStream))
                {
                    var text = sr.ReadToEnd();
                    Localization localization = JsonSerializer.Deserialize<Localization>(text, Globals.jso);
                    Console.WriteLine(localization.Language.Name);
                    return localization;
                }
            }
            catch (Exception ex)
            {

                throw new Exception($"Problem with '{entry}'.", ex);
            }
        }

        public Dictionary<String, Localization> GetLanguageList()
        {
            Dictionary<String, Localization> lst = new Dictionary<String, Localization>();
            var langs = GetResources(@"([Rl]esources\.[Ll]ang\..*\.json)$");
            for (int i = 0; i < langs.Count; i++)
            {
                var fileLoc = langs.ToArray()[i];
                var fileName = fileLoc.Split('.')[^2];
                lst.Add(fileName, LoadLocalization(fileLoc));
            }
            return lst;
        }

        /// <summary>
        /// Returns a dictionary of the assembly resources (not embedded).<br/>
        /// Code from <b>Aurelien Ribon</b>
        /// </summary>
        /// <param name="filter">A regex filter for the resource paths.</param>
        public static IList<string> GetResources(string filter)
        {
            var resources = LanguageHandler.parentAssembly.GetManifestResourceNames();

            IList<string> ret = new List<string>();
            foreach (String res in resources)
            {
                if (Regex.IsMatch(res, filter))
                    ret.Add(res);
            }
            return ret;
        }
    }
}

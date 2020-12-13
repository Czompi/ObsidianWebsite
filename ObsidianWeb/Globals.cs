using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json;

namespace PluginsWeb
{
    public class Globals
    {
        public static Plugins Plugins { get; internal set; }
        public static LanguageHandler TranslationHanlder { get; internal set; }
        public static Localization Translation { get; internal set; }
        public static string AppVersion
        {
            get
            {
                var ver = Assembly.GetExecutingAssembly().GetName().Version.ToString(3);
#if DEBUG
                ver += "-DEBUG";
#elif RELEASE
                //ver += "-RELEASE"; // Will we show this?
#endif
                return ver;
            }
        }
        public static PageList PageList { get; internal set; }

        public static Brand Brand { get; internal set; }
        public class Default
        {
            public static PageList PageList = new()
            {
                { "index", new PageItem { IsListed = true } }
            };

            public static Brand Brand = new()
            {
                Name = "",
                Owner = new() { Name = "", Url = "/" },
                Authors = new() { }
            };

        }
        #region Crypto
        public class SHA1
        {
            public static string Compute(string input)
            {
                var hash = new SHA1Managed().ComputeHash(Encoding.UTF8.GetBytes(input));
                return string.Concat(hash.Select(b => b.ToString("x2")));
            }
        }
        #endregion

        #region CDN
        public class CDN
        {
            private static string Host { get => "https://cdn.czompisoftware.hu/"; }
            public static string GetURL(string url)
            {
                if (url.StartsWith("/")) url.Substring(1);
                List<String> urls = url.Contains("/") ? url.Split("/").ToList() : new() { url };

                if (urls.Count > 2) urls[1] = SHA1.Compute(urls[1]);

                return $"{Host}{string.Join("/", urls)}";
            }
        }
        #endregion

        #region Newtonsoft.Json -> System.Text.Json
        public static JsonSerializerOptions jso
        {
            get
            {
                var jso = new JsonSerializerOptions
                {
                    WriteIndented = true,
                    PropertyNameCaseInsensitive = false,
                    IgnoreNullValues = true,
                    AllowTrailingCommas = true,
                    //ReadCommentHandling = JsonCommentHandling.Allow;
                    ReadCommentHandling = JsonCommentHandling.Skip
                };
                return jso;
            }
        }
        #endregion

    }
}

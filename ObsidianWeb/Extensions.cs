using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PluginsWeb
{
    public static class Extensions
    {
        public static string ToElapsedTime(this DateTime dt, DateTime? calcFrom = null)
        {
            calcFrom ??= DateTime.Now;
            //var elapsed = calcFrom?.Add(-dt.ToString("));
            return calcFrom?.ToString();
        }
        public static bool IsUrl(this string str) => Uri.IsWellFormedUriString(str, UriKind.Absolute);
        public static string ReplaceProductInfo(this string str, string prodId, string prodVer, PluginType pt) => str?.Replace("{version}", prodVer, StringComparison.OrdinalIgnoreCase)
            .Replace("{versionToLower}", prodVer.ToLower(), StringComparison.OrdinalIgnoreCase)
            .Replace("{type}", pt.ToString(), StringComparison.OrdinalIgnoreCase)
            .Replace("{product}", prodId, StringComparison.OrdinalIgnoreCase)
            .Replace("{productId}", prodId, StringComparison.OrdinalIgnoreCase)
            .Replace("{productVersion}", prodVer, StringComparison.OrdinalIgnoreCase)
            .Replace("{productVersionToLower}", prodVer.ToLower(), StringComparison.OrdinalIgnoreCase)
            .Replace("{productType}", pt.ToString(), StringComparison.OrdinalIgnoreCase)
            .Replace("{plugin}", prodId, StringComparison.OrdinalIgnoreCase)
            .Replace("{pluginId}", prodId, StringComparison.OrdinalIgnoreCase)
            .Replace("{pluginName}", prodId, StringComparison.OrdinalIgnoreCase)
            .Replace("{pluginVersion}", prodVer, StringComparison.OrdinalIgnoreCase)
            .Replace("{pluginVersionToLower}", prodVer.ToLower(), StringComparison.OrdinalIgnoreCase)
            .Replace("{pluginType}", pt.ToString(), StringComparison.OrdinalIgnoreCase);
    }
}

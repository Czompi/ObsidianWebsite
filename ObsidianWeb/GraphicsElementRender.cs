using Microsoft.AspNetCore.Html;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PluginsWeb
{
    public class GraphicsElementRender
    {
        public static HtmlString RenderRating(double rating, int maxRating = 5)
        {
            var stars = new List<string> { };
            HtmlString html;
            for (int i = 1; i < maxRating + 1; i++)
            {
                var hasHalfValue = rating < i && rating / .5 % 2 == 1;
                var starType = hasHalfValue ? "star-half-alt" : "star";
                var isActive = rating >= i || hasHalfValue ? " text-theme" : "";
                stars.Add($"<i class=\"fa fa-{starType}{isActive}\"></i>");
            }
            html = new HtmlString(string.Join("\r\n", stars));
            return html;
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace TechReady2016.TagHelpers
{
    [EditorBrowsable(EditorBrowsableState.Never)]
    [HtmlTargetElement("img", Attributes = "src")]
    public class ImgTagHelper : TagHelper
    {
        #region Image CDN Lookup
        private static readonly IReadOnlyDictionary<string, string> ImageCdnLookup = new Dictionary<string, string>(StringComparer.Ordinal)
        {
            { "~/images/banner1.svg", "https://c.s-microsoft.com/en-us/CMSImages/REBg6l.jpg?version=ccb8a567-96f5-b401-10cf-0326eb20e100" },
            { "~/images/banner2.svg", "https://c.s-microsoft.com/en-us/CMSImages/REwgwh.jpg?version=771827bd-d9de-2ecc-303f-f73e43225d66" },
            { "~/images/banner3.svg", "http://compass.xbox.com/assets/68/e2/68e29336-1335-4091-a75a-26c0811cf8d7.jpg?n=CTM2_Superhero_1920x720.jpg" },
            { "~/images/banner4.svg", "http://compass.xbox.com/assets/21/1c/211c306e-c240-47b3-9b25-0ecece6a0e2a.jpg?n=Gears-360-Collection_superhero-desktop_1920x720.jpg" },
        };
        #endregion

        public string Src { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            string cdnSrc;
            if (ImageCdnLookup.TryGetValue(Src, out cdnSrc))
            {
                Src = cdnSrc;
            }

            output.Attributes.SetAttribute("src", cdnSrc);
        }
    }
}

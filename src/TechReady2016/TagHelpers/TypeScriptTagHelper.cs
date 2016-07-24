using System;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace TechReady2016.TagHelpers
{
    [HtmlTargetElement("script", Attributes = "[src$=.ts]")]
    public class TypeScriptTagHelper : TagHelper
    {
        public override int Order
        {
            get
            {
                return -2000;
            }
        }

        public string Src { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            var srcCharArray = Src.ToCharArray();
            srcCharArray[srcCharArray.Length - 2] = 'j';

            var newSrc = new string(srcCharArray);
            output.Attributes.SetAttribute("src", newSrc);
        }
    }
}

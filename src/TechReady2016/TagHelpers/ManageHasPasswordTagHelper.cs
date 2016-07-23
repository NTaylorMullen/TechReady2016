using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace TechReady2016.TagHelpers
{
    [OutputElementHint("a")]
    public class ManageHasPasswordTagHelper : TagHelper
    {
        private readonly IUrlHelperFactory _urlHelperFactory;

        public ManageHasPasswordTagHelper(IUrlHelperFactory urlHelperFactory)
        {
            _urlHelperFactory = urlHelperFactory;
        }

        [ViewContext]
        [HtmlAttributeNotBound]
        public ViewContext ViewContext { get; set; }

        public bool Change { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "a";

            var linkContent = Change ? "Change" : "Set";
            output.Content.SetContent(linkContent);

            var actionName = Change ? "ChangePassword" : "SetPassword";
            var urlHelper = _urlHelperFactory.GetUrlHelper(ViewContext);
            var hrefValue = urlHelper.Action(actionName, "Manage");
            output.Attributes.SetAttribute("href", hrefValue);

            output.PreElement.SetContent("[ ");
            output.PostElement.SetContent(" ]");

            output.TagMode = TagMode.StartTagAndEndTag;
        }
    }
}

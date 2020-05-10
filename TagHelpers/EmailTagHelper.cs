using System;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace TextBooky.TagHelpers
{
    public class EmailTagHelper : TagHelper
    {
        public string Address { get; set; }
        public string LinkText { get; set; }

        // each tag helper is executed by a method called Process()
        // to create custom functionality - need to override this method & place logic in it

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            base.Process(context, output);

            output.TagName = "a"; // html element
            output.Attributes.SetAttribute("href", "mailto:" + Address);

            output.Content.SetContent(LinkText); // sets html element's main content
        }
    }
}

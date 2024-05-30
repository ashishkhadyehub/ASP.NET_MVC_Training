using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EBS.UI.TagHelpers
{
    public class EmailTagHelper : TagHelper
    {
        public string Address { get; set; }
        public string Display { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "a"; // Replaces the  tag with an  tag
            output.Attributes.SetAttribute("href", $"mailto:{Address}");
            output.Content.SetContent(Display);
        }
    }
}

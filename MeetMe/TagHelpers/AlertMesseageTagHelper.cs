using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MeetMe.TagHelpers
{
    public enum AlertType { Info, Success, Dannger, Warning, Primary, Secondary, Light, Dark }
    public class AlertMesseageTagHelper : TagHelper
    {
        public AlertType AlertType { get; set; }
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            string alertType = AlertType.ToString().ToLowerInvariant();
            output.TagName = "div";
            TagHelperAttribute existingClass;
            output.Attributes.TryGetAttribute("class", out existingClass);

            if (existingClass == null)
            {
                output.Attributes.SetAttribute("class", "alert alert-" + alertType);
            }
            else
            {
                output.Attributes.SetAttribute("class", existingClass.Value + " alert alert-" + alertType);
            }

        }
    }
}

using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace DotSvg.Presentation.Razor.TagHelpers
{
    [HtmlTargetElement(Attributes = nameof(Enrich))]
    public class EnrichTagHelper : TagHelper
    {
        public object Enrich { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            foreach(var (name, value) in GetProperties(Enrich))
                output.Attributes.SetAttribute(name, value);
        }

        protected IEnumerable<(string, string)> GetProperties(object data)
        {
            var type = data.GetType();
            foreach (var property in type.GetProperties())
            {
                var value = property.GetValue(data);
                if (value == null)
                    continue;

                if (property.CustomAttributes.Any(x => x.AttributeType == typeof(DisplayNameAttribute)))
                {
                    var displayNameAttribute = property.GetCustomAttributes().OfType<DisplayNameAttribute>().First();
                    yield return (displayNameAttribute.DisplayName, value.ToString());
                }
                else
                    yield return (property.Name, value.ToString());
            }
                
        }
    }
}

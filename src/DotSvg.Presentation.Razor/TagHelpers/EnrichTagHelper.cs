using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using DotSvg.Domain.Features.Conversion;
using DotSvg.Models.DataTypes;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace DotSvg.Presentation.Razor.TagHelpers
{
    [HtmlTargetElement(Attributes = nameof(Enrich))]
    public class EnrichTagHelper : TagHelper
    {
        public EnrichTagHelper(ISvgDataTypeConverter converter)
        {
            Converter = converter;
        }

        public object Enrich { get; set; }

        protected ISvgDataTypeConverter Converter { get; }

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

                if (value is Enum)
                    value = Enum.GetName(value.GetType(), value) ?? string.Empty;

                if(value is string valueString)
                    value = char.ToLowerInvariant(valueString[0]) + valueString.Substring(1);

                var result = Convert(value);
                if (property.CustomAttributes.Any(x => x.AttributeType == typeof(DisplayNameAttribute)))
                {
                    var displayNameAttribute = property.GetCustomAttributes().OfType<DisplayNameAttribute>().First();
                    yield return (displayNameAttribute.DisplayName, result);
                }
                else
                    yield return (property.Name, result);
            }    
        }

        protected string Convert(object data)
        {
            switch (data)
            {
                // Order is approximately the popularity per type
                case float number:
                    return Converter.Number(number);
                case Enum enumeration:
                    // TODO: some enumerations have dashes in them, CRAP!
                    var enumerationValue = Enum.GetName(enumeration.GetType(), enumeration);
                    return char.ToLowerInvariant(enumerationValue[0]) + enumerationValue.Substring(1);
                case Length length:
                    return Converter.Length(length);
                case string value when value.Length > 0:
                    return char.ToLowerInvariant(value[0]) + value.Substring(1);
                case IEnumerable enumerable:
                    var stringBuilder = new StringBuilder();
                    foreach (var item in enumerable)
                        stringBuilder.Append(Convert(item) + " ");
                    return stringBuilder.ToString().Trim();
                case TimeSpan span:
                    return Converter.ClockValue(span);
                case Angle angle:
                    return Converter.Angle(angle);
                case Frequency frequency:
                    return Converter.Frequency(frequency);
                case Opacity opacity:
                    return Converter.OpacityValue(opacity);
                case Time time:
                    return Converter.Time(time);
                case TransformList transformList:
                    return Converter.TransformList(transformList);
                case ViewBox viewBox:
                    return Converter.ViewBox(viewBox);
                default:
                    return data?.ToString();
            }
        }
    }
}

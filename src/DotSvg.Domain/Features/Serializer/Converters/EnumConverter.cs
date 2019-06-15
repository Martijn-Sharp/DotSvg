using System;
using DotSvg.Domain.Features.Serializer.Abstractions;
using DotSvg.Models.Attributes;

namespace DotSvg.Domain.Features.Serializer.Converters
{
    public class EnumConverter : ISvgTypeConverter, ISvgTypeConverter<Enum>
    {
        public bool CanConvert(Type type)
        {
            return type.IsEnum;
        }

        public string Convert(object value)
        {
            if (CanConvert(value.GetType()))
                return Convert(value as Enum);

            return default;
        }

        public string Convert(Enum @enum)
        {
            if (HasSvgProperty(@enum, out var attribute))
                return attribute.PropertyName;

            return Enum.GetName(@enum.GetType(), @enum).ToLower();
        }

        public bool HasSvgProperty(object @enum, out SvgPropertyAttribute attribute)
        {
            var type = @enum.GetType();
            var memInfo = type.GetMember(@enum.ToString());
            var attributes = memInfo[0].GetCustomAttributes(typeof(SvgPropertyAttribute), false);
            if (attributes.Length <= 0)
            {
                attribute = default;
                return false;
            }

            attribute = (SvgPropertyAttribute) attributes[0];
            return true;
        }
    }
}

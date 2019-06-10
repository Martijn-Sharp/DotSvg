﻿using System;
using DotSvg.Models.Attributes;

namespace DotSvg.Domain.Features.Serializer
{
    public class EnumConverter : ISvgTypeConverter, ISvgTypeConverter<Enum>
    {
        public bool CanConvert(Type type)
        {
            return type.IsEnum;
        }

        public string Convert(object value)
        {
            if (value == default || !CanConvert(value.GetType()))
                return null;

            return Convert(value as Enum);
        }

        public string Convert(Enum value)
        {
            if (HasSvgProperty(value, out var attribute))
                return attribute.PropertyName;

            return Enum.GetName(value.GetType(), value).ToLower();
        }

        public bool HasSvgProperty(object value, out SvgPropertyAttribute attribute)
        {
            var type = value.GetType();
            var memInfo = type.GetMember(value.ToString());
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

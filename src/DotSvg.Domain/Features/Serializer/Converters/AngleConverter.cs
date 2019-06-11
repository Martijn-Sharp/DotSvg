using System;
using DotSvg.Domain.Features.Serializer.Abstractions;
using DotSvg.Models.DataTypes;

namespace DotSvg.Domain.Features.Serializer.Converters
{
    public class AngleConverter : ISvgTypeConverter, ISvgTypeConverter<Angle>
    {
        private readonly Type _angleType = typeof(Angle);

        public AngleConverter(ISvgTypeConverter<float> numberConverter, ISvgTypeConverter<Enum> enumConverter)
        {
            NumberConverter = numberConverter;
            EnumConverter = enumConverter;
        }

        protected ISvgTypeConverter<float> NumberConverter { get; }

        protected ISvgTypeConverter<Enum> EnumConverter { get; }

        public virtual bool CanConvert(Type type) => type.IsAssignableFrom(_angleType);

        public string Convert(object value)
        {
            if (value is Angle angle)
                return Convert(angle);

            return default;
        }

        public string Convert(Angle angle)
        {
            return NumberConverter.Convert(angle.Number) + EnumConverter.Convert(angle.Unit);
        }
    }
}

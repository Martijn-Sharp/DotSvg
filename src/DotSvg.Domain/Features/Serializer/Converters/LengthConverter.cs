using System;
using DotSvg.Domain.Features.Serializer.Abstractions;
using DotSvg.Models.DataTypes;

namespace DotSvg.Domain.Features.Serializer.Converters
{
    public class LengthConverter : ISvgTypeConverter, ISvgTypeConverter<Length>
    {
        private readonly Type _lengthType = typeof(Length);

        public LengthConverter(ISvgTypeConverter<float> numberConverter, ISvgTypeConverter<Enum> enumConverter)
        {
            NumberConverter = numberConverter;
            EnumConverter = enumConverter;
        }

        protected ISvgTypeConverter<float> NumberConverter { get; }

        protected ISvgTypeConverter<Enum> EnumConverter { get; }

        public bool CanConvert(Type type) => type == _lengthType;

        public string Convert(object value)
        {
            if (value is Length length)
                return Convert(length);

            return default;
        }

        public string Convert(Length length)
        {
            return NumberConverter.Convert(length.Number) + EnumConverter.Convert(length.Unit);
        }
    }
}

using System;
using DotSvg.Domain.Features.Serializer.Abstractions;
using DotSvg.Models.DataTypes;

namespace DotSvg.Domain.Features.Serializer.Converters
{
    public class TimeConverter : ISvgTypeConverter, ISvgTypeConverter<Time>
    {
        private readonly Type _timeType = typeof(Time);

        public TimeConverter(ISvgTypeConverter<float> numberConverter, ISvgTypeConverter<Enum> enumConverter)
        {
            NumberConverter = numberConverter;
            EnumConverter = enumConverter;
        }

        protected ISvgTypeConverter<float> NumberConverter { get; }

        protected ISvgTypeConverter<Enum> EnumConverter { get; }

        public bool CanConvert(Type type) => type == _timeType;

        public string Convert(object value)
        {
            if (value is Time time)
                return Convert(time);

            return default;
        }

        public string Convert(Time time)
        {
            return NumberConverter.Convert(time.Number) + EnumConverter.Convert(time.Unit);
        }
    }
}

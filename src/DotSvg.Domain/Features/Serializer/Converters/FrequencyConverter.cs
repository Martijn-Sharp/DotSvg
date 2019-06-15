using System;
using DotSvg.Domain.Features.Serializer.Abstractions;
using DotSvg.Models.DataTypes;

namespace DotSvg.Domain.Features.Serializer.Converters
{
    public class FrequencyConverter : ISvgTypeConverter, ISvgTypeConverter<Frequency>
    {
        private readonly Type _frequencyType = typeof(Frequency);

        public FrequencyConverter(ISvgTypeConverter<float> numberConverter, ISvgTypeConverter<Enum> enumConverter)
        {
            NumberConverter = numberConverter;
            EnumConverter = enumConverter;
        }

        protected ISvgTypeConverter<float> NumberConverter { get; }

        protected ISvgTypeConverter<Enum> EnumConverter { get; }

        public bool CanConvert(Type type) => type == _frequencyType;

        public string Convert(object value)
        {
            if (value is Frequency frequency)
                return Convert(frequency);

            return default;
        }

        public string Convert(Frequency frequency)
        {
            return NumberConverter.Convert(frequency.Number) + EnumConverter.Convert(frequency.Unit);
        }
    }
}

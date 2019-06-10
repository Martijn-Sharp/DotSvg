using System;
using System.Globalization;

namespace DotSvg.Domain.Features.Serializer
{
    public class NumberConverter : ISvgTypeConverter, ISvgTypeConverter<float>
    {
        private readonly Type _floatType = typeof(float);

        protected CultureInfo Culture { get; } = new CultureInfo("en");

        public virtual bool CanConvert(Type type) => type == _floatType;

        public string Convert(object value)
        {
            if (value is float number)
                return Convert(number);

            return default;
        }

        public string Convert(float value) => value.ToString(Culture);
    }
}

using System;
using System.Globalization;
using DotSvg.Domain.Features.Serializer.Abstractions;
using DotSvg.Models.DataTypes;

namespace DotSvg.Domain.Features.Serializer.Converters
{
    public class NumberConverter : ISvgTypeConverter, ISvgTypeConverter<float>, ISvgTypeConverter<Opacity>, ISvgTypeConverter<Percentage>
    {
        private readonly Type[] _allowedTypes = {typeof(float), typeof(Opacity), typeof(Percentage)};

        protected CultureInfo Culture { get; } = new CultureInfo("en");

        public virtual bool CanConvert(Type type) => Array.Exists(_allowedTypes, t => type == t);

        public string Convert(object value)
        {
            switch (value)
            {
                case float number:
                    return Convert(number);
                case Opacity opacity:
                    return Convert(opacity);
                case Percentage percentage:
                    return Convert(percentage);
            }

            return default;
        }

        public string Convert(float value) => value.ToString(Culture);

        public string Convert(Opacity value) => Convert(value.Number);

        public string Convert(Percentage value) => $"{Convert(value.Number)}%";
    }
}

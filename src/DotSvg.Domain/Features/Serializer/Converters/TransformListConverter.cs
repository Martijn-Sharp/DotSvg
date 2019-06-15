using System;
using System.Text;
using DotSvg.Domain.Features.Serializer.Abstractions;
using DotSvg.Models.DataTypes;

namespace DotSvg.Domain.Features.Serializer.Converters
{
    public class TransformListConverter : ISvgTypeConverter, ISvgTypeConverter<TransformList>
    {
        private readonly Type _transformListType = typeof(TransformList);

        public TransformListConverter(ISvgTypeConverter<float> numberConverter)
        {
            NumberConverter = numberConverter;
        }

        protected ISvgTypeConverter<float> NumberConverter { get; }

        public bool CanConvert(Type type) => type == _transformListType;

        public string Convert(object value)
        {
            if (value is TransformList transformList)
                return Convert(transformList);

            return default;
        }

        public string Convert(TransformList transformList)
        {
            var stringBuilder = new StringBuilder();
            foreach (var value in transformList.Values)
            {
                stringBuilder.Append($"{NumberConverter.Convert(value)} ");
            }

            return $"{transformList.Function}({stringBuilder.ToString().Trim()})";
        }
    }
}

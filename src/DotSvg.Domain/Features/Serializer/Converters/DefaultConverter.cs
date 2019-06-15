using System;
using DotSvg.Domain.Features.Serializer.Abstractions;

namespace DotSvg.Domain.Features.Serializer.Converters
{
    public class DefaultConverter : ISvgTypeConverter
    {
        public bool CanConvert(Type type) => true;

        public string Convert(object value) => value.ToString();
    }
}

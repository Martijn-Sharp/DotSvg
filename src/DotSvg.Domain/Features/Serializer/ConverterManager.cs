using System;
using System.Collections.Generic;
using System.Linq;

namespace DotSvg.Domain.Features.Serializer
{
    public class ConverterManager : IConverterManager
    {
        private readonly IEnumerable<ISvgTypeConverter> _availableConverters;

        public ConverterManager(IEnumerable<ISvgTypeConverter> converters)
        {
            _availableConverters = converters;
        }

        public bool TryFind(Type type, out ISvgTypeConverter converter)
        {
            converter = _availableConverters.FirstOrDefault(x => x.CanConvert(type));
            return converter != default;
        }
    }
}

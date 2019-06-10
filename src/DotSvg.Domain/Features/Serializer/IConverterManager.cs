using System;

namespace DotSvg.Domain.Features.Serializer
{
    public interface IConverterManager
    {
        bool TryFind(Type type, out ISvgTypeConverter converter);
    }
}
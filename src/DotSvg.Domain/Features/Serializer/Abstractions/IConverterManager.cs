using System;

namespace DotSvg.Domain.Features.Serializer.Abstractions
{
    public interface IConverterManager
    {
        bool TryFind(Type type, out ISvgTypeConverter converter);
    }
}
﻿using System;

namespace DotSvg.Domain.Features.Serializer.Abstractions
{
    public interface ISvgTypeConverter
    {
        bool CanConvert(Type type);

        string Convert(object value);
    }

    public interface ISvgTypeConverter<in T>
    {
        string Convert(T value);
    }
}
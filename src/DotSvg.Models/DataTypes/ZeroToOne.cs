using System;
using DotSvg.Models.Traits;

namespace DotSvg.Models.DataTypes
{
    public struct ZeroToOne : IFillOpacity
    {
        public ZeroToOne(float number)
        {
            if(number < 0 || number > 1)
                throw new ArgumentException($"{nameof(number)} must be between 0 and 1");

            Number = number;
        }

        public float Number { get; }

        public static implicit operator ZeroToOne(float number) => new ZeroToOne(number);
    }
}

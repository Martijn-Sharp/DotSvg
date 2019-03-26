using System;

namespace DotSvg.Models.DataTypes
{
    public struct Opacity
    {
        public Opacity(float number)
        {
            if(number < 0 || number > 1)
                throw new ArgumentOutOfRangeException($"The value of {nameof(number)} should be between 0.0 and 1.0");

            Number = number;
        }

        public float Number { get; }
    }
}

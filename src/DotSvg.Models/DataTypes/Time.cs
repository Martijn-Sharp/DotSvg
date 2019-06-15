using DotSvg.Models.Attributes;

namespace DotSvg.Models.DataTypes
{
    public struct Time
    {
        public Time(float number, UnitOptions unit)
        {
            Number = number;
            Unit = unit;
        }

        public float Number { get; }

        public UnitOptions Unit { get; }

        public override string ToString()
        {
            return $"{Number} {Unit}";
        }

        public enum UnitOptions
        {
            [SvgProperty("ms")]
            Milliseconds,
            [SvgProperty("s")]
            Seconds
        }
    }
}

using DotSvg.Models.Attributes;

namespace DotSvg.Models.DataTypes
{
    public struct Angle
    {
        public Angle(float number, UnitOptions unit = UnitOptions.Degrees)
        {
            Number = number;
            Unit = unit;
        }

        public float Number { get; }

        public UnitOptions Unit { get; }

        public static implicit operator Angle(float number) => new Angle(number);

        public override string ToString()
        {
            return $"{Number} {Unit}";
        }

        public enum UnitOptions
        {
            [SvgProperty("deg")]
            Degrees,
            [SvgProperty("grad")]
            Grads,
            [SvgProperty("rad")]
            Radians
        }
    }
}

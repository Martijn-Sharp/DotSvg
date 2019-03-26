namespace DotSvg.Models.DataTypes
{
    public struct Angle
    {
        public Angle(float number, UnitOptions unit)
        {
            Number = number;
            Unit = unit;
        }

        public float Number { get; }

        public UnitOptions Unit { get; }

        public enum UnitOptions
        {
            Degrees,
            Grads,
            Radians
        }
    }
}

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

        public enum UnitOptions
        {
            Milliseconds,
            Seconds
        }
    }
}

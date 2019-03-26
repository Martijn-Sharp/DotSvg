namespace DotSvg.Models.DataTypes
{
    public struct Length
    {
        public Length(float number, UnitOptions unit)
        {
            Number = number;
            Unit = unit;
        }

        public float Number { get; }

        public UnitOptions Unit { get; }

        public enum UnitOptions
        {
            Unspecified,
            Em,
            Ex,
            Px,
            In,
            Cm,
            Mm,
            Pt,
            Pc,
            Percentage
        }
    }
}

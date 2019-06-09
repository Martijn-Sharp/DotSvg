namespace DotSvg.Models.DataTypes
{
    public struct Length
    {
        public Length(float number, UnitOptions unit = UnitOptions.Unspecified)
        {
            Number = number;
            Unit = unit;
        }

        public float Number { get; }

        public UnitOptions Unit { get; }

        public static implicit operator Length(float number) => new Length(number);

        public override string ToString()
        {
            if (Unit == UnitOptions.Unspecified)
                return Number.ToString();

            return $"{Number} {Unit}";
        }

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

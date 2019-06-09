namespace DotSvg.Models.DataTypes
{
    public struct Frequency
    {
        public Frequency(float number, UnitOptions unit)
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
            Hertz,
            KiloHertz
        }
    }
}

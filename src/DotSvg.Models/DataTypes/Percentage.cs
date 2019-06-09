namespace DotSvg.Models.DataTypes
{
    public struct Percentage
    {
        public Percentage(float number)
        {
            Number = number;
        }

        public float Number { get; }

        public static implicit operator Percentage(float number) => new Percentage(number);

        public override string ToString() => $"{Number}%";
    }
}

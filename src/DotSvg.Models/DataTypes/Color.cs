using System;
using System.Text.RegularExpressions;
using DotSvg.Models.Enumerations;

namespace DotSvg.Models.DataTypes
{
    public struct Color
    {
        private const int HexMinLength = 3;

        private const int HexMaxLength = 7;

        // SVG supports CSS2 fully, CSS3 in the future so NO RGBA
        private static readonly string HexRegEx = "^#[0-9a-fA-F]{6}$|#[0-9a-fA-F]{4}$|#[0-9a-fA-F]{3}$";

        private Color(string value)
        {
            Value = value;
        }

        public string Value { get; }

        public static Color Hexadecimal(string hexadecimal)
        {
            if(hexadecimal == null)
                throw new ArgumentNullException(nameof(hexadecimal));

            if(hexadecimal.Length < HexMinLength || hexadecimal.Length > HexMaxLength)
                throw new ArgumentOutOfRangeException(nameof(hexadecimal), $"Value should be (between) {HexMinLength} and {HexMaxLength} long.");

            if (hexadecimal[0] != '#')
                hexadecimal = $"#{hexadecimal}";

            var regex = new Regex(HexRegEx);
            if(!regex.IsMatch(hexadecimal))
                throw new ArgumentException("Provided value doesn't pass the regex validation", nameof(hexadecimal));

            return new Color(hexadecimal);
        }

        public static Color Rgb(int red, int green, int blue, bool percentages = false)
        {
            int maxValue = percentages ? 100 : 255;

            if (red < 0 || red > maxValue)
                throw new ArgumentOutOfRangeException(nameof(red), red, $"Value must be 0 - {maxValue}");

            if (green < 0 || green > maxValue)
                throw new ArgumentOutOfRangeException(nameof(green), green, $"Value must be 0 - {maxValue}");

            if (blue < 0 || blue > maxValue)
                throw new ArgumentOutOfRangeException(nameof(blue), blue, $"Value must be 0 - {maxValue}");

            string pc = percentages ? "%" : string.Empty;
            return new Color($"rgb({red}{pc},{green}{pc},{blue}{pc})");
        }

        public static Color Transparent => new Color("transparent");

        public static Color Code(X11Colors code)
        {
            return new Color(Enum.GetName(typeof(X11Colors), code));
        }

        public static implicit operator Color(X11Colors colorCode) => Code(colorCode);

        public override string ToString()
        {
            return Value;
        }
    }
}

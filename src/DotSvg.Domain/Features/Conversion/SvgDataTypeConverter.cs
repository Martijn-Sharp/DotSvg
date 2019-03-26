using System;
using System.Globalization;
using System.Text;
using DotSvg.Models.DataTypes;

namespace DotSvg.Domain.Features.Conversion
{
    public class SvgDataTypeConverter : ISvgDataTypeConverter
    {
        protected CultureInfo Culture { get; } = new CultureInfo("en");

        public string Angle(Angle angle)
        {
            string angleUnit;
            switch (angle.Unit)
            {
                case Models.DataTypes.Angle.UnitOptions.Degrees:
                    angleUnit = "deg";
                    break;
                case Models.DataTypes.Angle.UnitOptions.Grads:
                    angleUnit = "grad";
                    break;
                case Models.DataTypes.Angle.UnitOptions.Radians:
                    angleUnit = "rad";
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }

            return Number(angle.Number) + angleUnit;
        }

        public string Anything(object anything) => anything.ToString();

        public string ClockValue() => throw new NotImplementedException();

        public string Frequency(Frequency frequency)
        {
            string frequencyUnit;
            switch (frequency.Unit)
            {
                case Models.DataTypes.Frequency.UnitOptions.Hertz:
                    frequencyUnit = "Hz";
                    break;
                case Models.DataTypes.Frequency.UnitOptions.KiloHertz:
                    frequencyUnit = "kHz";
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }

            return Number(frequency.Number) + frequencyUnit;
        }

        public string Integer(int integer) => integer.ToString();

        public string Length(Length length)
        {
            string lengthUnit;
            switch (length.Unit)
            {
                case Models.DataTypes.Length.UnitOptions.Unspecified:
                    lengthUnit = string.Empty;
                    break;
                case Models.DataTypes.Length.UnitOptions.Percentage:
                    lengthUnit = "%";
                    break;
                case Models.DataTypes.Length.UnitOptions.Em:
                case Models.DataTypes.Length.UnitOptions.Ex:
                case Models.DataTypes.Length.UnitOptions.Px:
                case Models.DataTypes.Length.UnitOptions.In:
                case Models.DataTypes.Length.UnitOptions.Cm:
                case Models.DataTypes.Length.UnitOptions.Mm:
                case Models.DataTypes.Length.UnitOptions.Pt:
                case Models.DataTypes.Length.UnitOptions.Pc:
                    lengthUnit = Enum.GetName(typeof(Length.UnitOptions), length.Unit).ToLower();
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }

            return Number(length.Number) + lengthUnit;
        }

        public string Name(Name name) => name.Value;
        
        public string Number(float number) => number.ToString(Culture);

        public string OpacityValue(Opacity opacity) => Number(opacity.Number);

        public string Paint(Paint paint) => paint.Value;

        public string Percentage(float number) => Number(number) + "%";

        public string Time(Time time)
        {
            string timeUnit;
            switch (time.Unit)
            {
                case Models.DataTypes.Time.UnitOptions.Milliseconds:
                    timeUnit = "ms";
                    break;
                case Models.DataTypes.Time.UnitOptions.Seconds:
                    timeUnit = "s";
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }

            return Number(time.Number) + timeUnit;
        }

        public string TransformList(TransformList transformList)
        {
            var stringBuilder = new StringBuilder();
            foreach (var value in transformList.Values)
            {
                stringBuilder.Append(Number(value) + " ");
            }
            
            return $"{transformList.Function}({stringBuilder.ToString().Trim()})";
        }
    }
}

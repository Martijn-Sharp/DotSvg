using System;
using System.Globalization;
using System.Text;
using DotSvg.Models.DataTypes;
using DotSvg.Models.Enumerations;

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

        public string BasicShape(IBasicShape basicShape)
        {
            var stringBuilder = new StringBuilder(basicShape.Function);
            stringBuilder.Append("(");
            foreach (var parameter in basicShape.Parameters)
            {
                if (!string.IsNullOrEmpty(parameter.Function))
                    stringBuilder.Append($" {parameter.Function}");

                stringBuilder.Append($" {parameter.Value}");
            }

            stringBuilder.Append(")");
            if (basicShape.GeometryBox.HasValue)
                stringBuilder.Append($" {Enum.GetName(typeof(BoxOptions), basicShape.GeometryBox.Value).ToLower()}");

            return stringBuilder.ToString();
        }

        public string ClockValue(TimeSpan span)
        {
            var stringBuilder = new StringBuilder();
            if (span.TotalHours > 0)
                stringBuilder.Append($"{(int) span.TotalHours}:");

            stringBuilder.Append($"{span.Minutes:00}:{span.Seconds:00}");
            if (span.Milliseconds > 0)
                stringBuilder.Append($".{span.Milliseconds.ToString("000").TrimEnd('0')}");

            return stringBuilder.ToString();
        }

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
                default:
                    lengthUnit = Enum.GetName(typeof(Length.UnitOptions), length.Unit).ToLower();
                    break;
            }

            return Number(length.Number) + lengthUnit;
        }
        
        public string Number(float number) => number.ToString(Culture);

        public string OpacityValue(Opacity opacity) => Number(opacity.Number);
        
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

        public string ViewBox(ViewBox viewBox)
        {
            return $"{Number(viewBox.MinX)} {Number(viewBox.MinY)} {Number(viewBox.Width)} {Number(viewBox.Height)}";
        }
    }
}

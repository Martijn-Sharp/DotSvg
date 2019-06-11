using System;
using DotSvg.Domain.Features.Serializer.Abstractions;

namespace DotSvg.Domain.Features.Serializer.Converters
{
    public class ClockValueConverter : ISvgTypeConverter, ISvgTypeConverter<TimeSpan>
    {
        public bool CanConvert(Type type) => type == typeof(TimeSpan);

        public string Convert(object value)
        {
            if (value is TimeSpan span)
                return Convert(span);

            return default;
        }

        public string Convert(TimeSpan value)
        {
            var strategy = ChooseStrategy(value);
            return strategy.Execute(value);
        }

        public IClockValueConverterStrategy ChooseStrategy(TimeSpan timeSpan)
        {
            bool hasHours = timeSpan.Hours > 0;
            bool hasMinutes = timeSpan.Minutes > 0;
            bool hasSeconds = timeSpan.Seconds > 0;
            if((hasHours && hasMinutes) || (hasHours && hasSeconds))
                return new FullClockConverterStrategy();

            if(hasMinutes && hasSeconds)
                return new PartialClockConverterStrategy();

            return new TimecountConverterStrategy();
        }
    }
}

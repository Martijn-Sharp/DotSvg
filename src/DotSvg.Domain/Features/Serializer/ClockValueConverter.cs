using System;

namespace DotSvg.Domain.Features.Serializer
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

        public IClockValueStrategy ChooseStrategy(TimeSpan timeSpan)
        {
            bool hasHours = timeSpan.Hours > 0;
            bool hasMinutes = timeSpan.Minutes > 0;
            bool hasSeconds = timeSpan.Seconds > 0;
            if((hasHours && hasMinutes) || (hasHours && hasSeconds))
                return new FullClockStrategy();

            if(hasMinutes && hasSeconds)
                return new PartialClockStrategy();

            return new TimecountStrategy();
        }
    }

    public interface IClockValueStrategy
    {
        string Execute(TimeSpan timeSpan);
    }

    public class FullClockStrategy : IClockValueStrategy
    {
        public string Execute(TimeSpan timeSpan)
        {
            var result = $"{timeSpan.Days * 24 + timeSpan.Hours:00}:{timeSpan.Minutes:00}:{timeSpan.Seconds:00}";
            if (timeSpan.Milliseconds > 0)
                result += $".{timeSpan.Milliseconds.ToString("000").TrimEnd('0')}";

            return result;
        }
    }

    public class PartialClockStrategy : IClockValueStrategy
    {
        public string Execute(TimeSpan timeSpan)
        {
            var result = $"{timeSpan.Minutes:00}:{timeSpan.Seconds:00}";
            if (timeSpan.Milliseconds > 0)
                result += $".{timeSpan.Milliseconds.ToString("000").TrimEnd('0')}";

            return result;
        }
    }

    public class TimecountStrategy : IClockValueStrategy
    {
        public string Execute(TimeSpan timeSpan)
        {
            // 3.2h notation is not implemented
            // because it's not worth the effort

            if (timeSpan.Minutes > 0)
                return $"{timeSpan.Minutes}min";

            if(timeSpan.Seconds > 0)
                if (timeSpan.Milliseconds > 0)
                    return $"{timeSpan.Seconds:00}.{timeSpan.Milliseconds.ToString("000").TrimEnd('0')}";
                else
                    return $"{timeSpan.Seconds}s";

            if (timeSpan.Milliseconds > 0)
                return $"{timeSpan.Milliseconds}ms";

            return null;
        }
    }
}

using System;
namespace DotSvg.Domain.Features.Serializer.Abstractions
{
    public interface IClockValueConverterStrategy
    {
        string Execute(TimeSpan timeSpan);
    }

    public class FullClockConverterStrategy : IClockValueConverterStrategy
    {
        public string Execute(TimeSpan timeSpan)
        {
            var result = $"{timeSpan.Days * 24 + timeSpan.Hours:00}:{timeSpan.Minutes:00}:{timeSpan.Seconds:00}";
            if (timeSpan.Milliseconds > 0)
                result += $".{timeSpan.Milliseconds.ToString("000").TrimEnd('0')}";

            return result;
        }
    }

    public class PartialClockConverterStrategy : IClockValueConverterStrategy
    {
        public string Execute(TimeSpan timeSpan)
        {
            var result = $"{timeSpan.Minutes:00}:{timeSpan.Seconds:00}";
            if (timeSpan.Milliseconds > 0)
                result += $".{timeSpan.Milliseconds.ToString("000").TrimEnd('0')}";

            return result;
        }
    }

    public class TimecountConverterStrategy : IClockValueConverterStrategy
    {
        public string Execute(TimeSpan timeSpan)
        {
            // 3.2h notation is not implemented
            // because it's not worth the effort

            if (timeSpan.Minutes > 0)
                return $"{timeSpan.Minutes}min";

            if (timeSpan.Seconds > 0)
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

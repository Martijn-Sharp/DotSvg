using System;
using DotSvg.Domain.Features.Serializer.Converters;
using Xunit;

namespace DotSvg.Domain.Tests.Features.Serializer.Converters
{
    public class ClockValueConverterTests
    {
        public ClockValueConverterTests()
        {
            Converter = new ClockValueConverter();
        }

        protected ClockValueConverter Converter { get; }

        [Fact]
        public void TimeSpanTypeShouldBeAllowed()
        {
            Assert.True(Converter.CanConvert(typeof(TimeSpan)));
        }

        [Theory]
        [InlineData(typeof(string))]
        [InlineData(typeof(ClockValueConverterTests))]
        [InlineData(typeof(int))]
        public void NonTimeSpanTypeShouldNotBeAllowed(Type type)
        {
            Assert.False(Converter.CanConvert(type));
        }

        [Theory]
        [MemberData(nameof(TimeSpanData))]
        public void TimeSpanShouldBeFormattedCorrectly(TimeSpan timeSpan, string expected)
        {
            var actual = Converter.Convert(timeSpan);
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData("")]
        [InlineData(1f)]
        [InlineData(1)]
        [InlineData(1d)]
        public void NonAngleShouldReturnNull(object value)
        {
            var actual = Converter.Convert(value);
            Assert.Null(actual);
        }

        public static TheoryData<TimeSpan, string> TimeSpanData =>
            new TheoryData<TimeSpan, string>
            {
                {new TimeSpan(0, 2, 30, 3), "02:30:03"},
                {new TimeSpan(0, 50, 0, 10, 250), "50:00:10.25"},
                {new TimeSpan(0, 2, 33), "02:33"},
                {new TimeSpan(0, 0, 0, 10, 500), "10.5"},
                {new TimeSpan(3, 12, 0), "03:12:00"}, // According to documentation this could also be 3.2h, but an implementation of that isn't worth the effort
                {new TimeSpan(0, 45, 0), "45min"},
                {new TimeSpan(0, 0, 30), "30s"},
                {new TimeSpan(0, 0, 0, 0, 5), "5ms"},
                {new TimeSpan(0, 0, 0, 12, 467), "12.467"}
            };
    }
}

using System;
using DotSvg.Domain.Features.Serializer.Converters;
using DotSvg.Models.DataTypes;
using Xunit;

namespace DotSvg.Domain.Tests.Features.Serializer.Converters
{
    public class TimeConverterTests
    {
        public TimeConverterTests()
        {
            Converter = new TimeConverter(new NumberConverter(), new EnumConverter());
        }

        protected TimeConverter Converter { get; }

        [Fact]
        public void TimeTypeShouldBeAllowed()
        {
            Assert.True(Converter.CanConvert(typeof(Time)));
        }

        [Theory]
        [InlineData(typeof(string))]
        [InlineData(typeof(TimeConverterTests))]
        [InlineData(typeof(int))]
        public void NonTimeTypeShouldNotBeAllowed(Type type)
        {
            Assert.False(Converter.CanConvert(type));
        }

        [Theory]
        [InlineData(20f, Time.UnitOptions.Milliseconds, "20ms")]
        [InlineData(20f, Time.UnitOptions.Seconds, "20s")]
        public void TimeShouldBeFormattedDifferentPerUnit(float number, Time.UnitOptions unit, string expected)
        {
            var actual = Converter.Convert(new Time(number, unit));
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData("")]
        [InlineData(1f)]
        [InlineData(1)]
        [InlineData(1d)]
        public void NonTimeShouldReturnNull(object value)
        {
            var actual = Converter.Convert(value);
            Assert.Null(actual);
        }
    }
}

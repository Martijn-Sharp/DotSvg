using System;
using DotSvg.Domain.Features.Serializer.Converters;
using DotSvg.Models.DataTypes;
using Xunit;

namespace DotSvg.Domain.Tests.Features.Serializer.Converters
{
    public class FrequencyConverterTests
    {
        public FrequencyConverterTests()
        {
            Converter = new FrequencyConverter(new NumberConverter(), new EnumConverter());
        }

        protected FrequencyConverter Converter { get; }

        [Fact]
        public void FrequencyTypeShouldBeAllowed()
        {
            Assert.True(Converter.CanConvert(typeof(Frequency)));
        }

        [Theory]
        [InlineData(typeof(string))]
        [InlineData(typeof(FrequencyConverterTests))]
        [InlineData(typeof(int))]
        public void NonFrequencyTypeShouldNotBeAllowed(Type type)
        {
            Assert.False(Converter.CanConvert(type));
        }

        [Theory]
        [InlineData(20f, Frequency.UnitOptions.KiloHertz, "20kHz")]
        [InlineData(20f, Frequency.UnitOptions.Hertz, "20Hz")]
        public void FrequencyShouldBeFormattedDifferentPerUnit(float number, Frequency.UnitOptions unit, string expected)
        {
            var actual = Converter.Convert(new Frequency(number, unit));
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData("")]
        [InlineData(1f)]
        [InlineData(1)]
        [InlineData(1d)]
        public void NonFrequencyShouldReturnNull(object value)
        {
            var actual = Converter.Convert(value);
            Assert.Null(actual);
        }
    }
}

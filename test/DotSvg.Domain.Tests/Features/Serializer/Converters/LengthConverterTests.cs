using System;
using DotSvg.Domain.Features.Serializer.Converters;
using DotSvg.Models.DataTypes;
using Xunit;

namespace DotSvg.Domain.Tests.Features.Serializer.Converters
{
    public class LengthConverterTests
    {
        public LengthConverterTests()
        {
            Converter = new LengthConverter(new NumberConverter(), new EnumConverter());
        }

        protected LengthConverter Converter { get; }

        [Fact]
        public void LengthTypeShouldBeAllowed()
        {
            Assert.True(Converter.CanConvert(typeof(Length)));
        }

        [Theory]
        [InlineData(typeof(string))]
        [InlineData(typeof(LengthConverterTests))]
        [InlineData(typeof(int))]
        public void NonLengthTypeShouldNotBeAllowed(Type type)
        {
            Assert.False(Converter.CanConvert(type));
        }

        [Theory]
        [InlineData(20f, Length.UnitOptions.Em, "20em")]
        [InlineData(20f, Length.UnitOptions.Ex, "20ex")]
        [InlineData(20f, Length.UnitOptions.Px, "20px")]
        [InlineData(20f, Length.UnitOptions.In, "20in")]
        [InlineData(20f, Length.UnitOptions.Cm, "20cm")]
        [InlineData(20f, Length.UnitOptions.Mm, "20mm")]
        [InlineData(20f, Length.UnitOptions.Pt, "20pt")]
        [InlineData(20f, Length.UnitOptions.Pc, "20pc")]
        [InlineData(20f, Length.UnitOptions.Percentage, "20%")]
        [InlineData(20f, Length.UnitOptions.Unspecified, "20")]
        public void LengthShouldBeFormattedDifferentPerUnit(float number, Length.UnitOptions unit, string expected)
        {
            var actual = Converter.Convert(new Length(number, unit));
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData("")]
        [InlineData(1f)]
        [InlineData(1)]
        [InlineData(1d)]
        public void NonLengthShouldReturnNull(object value)
        {
            var actual = Converter.Convert(value);
            Assert.Null(actual);
        }
    }
}

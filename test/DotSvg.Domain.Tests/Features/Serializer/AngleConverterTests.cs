using DotSvg.Domain.Features.Serializer;
using DotSvg.Models.DataTypes;
using Xunit;

namespace DotSvg.Domain.Tests.Features.Serializer
{
    public class AngleConverterTests
    {
        public AngleConverterTests()
        {
            Converter = new AngleConverter(new NumberConverter(), new EnumConverter());
        }

        protected AngleConverter Converter { get; }

        [Fact]
        public void AngleTypeShouldBeAllowed()
        {
            var angle = new Angle();
            Assert.True(Converter.CanConvert(angle.GetType()));
        }

        [Theory]
        [InlineData("")]
        [InlineData(1)]
        [InlineData(1d)]
        public void NonAngleTypeShouldNotBeAllowed(object value)
        {
            Assert.False(Converter.CanConvert(value.GetType()));
        }

        [Theory]
        [InlineData(20f, Angle.UnitOptions.Degrees, "20deg")]
        [InlineData(20f, Angle.UnitOptions.Grads, "20grad")]
        [InlineData(20f, Angle.UnitOptions.Radians, "20rad")]
        public void AngleShouldBeFormattedDifferentPerUnit(float number, Angle.UnitOptions unit, string expected)
        {
            var actual = Converter.Convert(new Angle(number, unit));
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void ShouldDefaultToDegrees()
        {
            var actual = Converter.Convert(new Angle(20f));
            Assert.Equal("20deg", actual);
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
    }
}

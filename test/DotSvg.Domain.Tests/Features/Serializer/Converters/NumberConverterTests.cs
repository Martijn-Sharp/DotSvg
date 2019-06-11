using System;
using System.Globalization;
using System.Threading;
using DotSvg.Domain.Features.Serializer.Abstractions;
using DotSvg.Domain.Features.Serializer.Converters;
using Xunit;

namespace DotSvg.Domain.Tests.Features.Serializer.Converters
{
    public class NumberConverterTests
    {
        public NumberConverterTests()
        {
            Converter = new NumberConverter();
        }

        protected ISvgTypeConverter Converter { get; }

        [Fact]
        public void FloatTypeShouldBeAllowed()
        {
            Assert.True(Converter.CanConvert(typeof(float)));
        }

        [Theory]
        [InlineData(typeof(string))]
        [InlineData(typeof(EnumConverterTests))]
        [InlineData(typeof(int))]
        public void NonFloatTypeShouldNotBeAllowed(Type type)
        {
            Assert.False(Converter.CanConvert(type));
        }

        [Theory]
        [InlineData(1f, "1", "en")]
        [InlineData(1.01f, "1.01", "en")]
        [InlineData(1.01f, "1.01", "nl")]
        public void FloatShouldBeFormattedInEnglishNotation(float value, string expected, string cultureName)
        {
            var cultureToRestore = CultureInfo.CurrentCulture;
            var testCulture = CultureInfo.GetCultureInfo(cultureName);
            Thread.CurrentThread.CurrentCulture = testCulture;

            var actual = Converter.Convert(value);

            Thread.CurrentThread.CurrentCulture = cultureToRestore;
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData("")]
        [InlineData(1)]
        [InlineData(1d)]
        public void NonFloatShouldReturnNull(object value)
        {
            var actual = Converter.Convert(value);
            Assert.Null(actual);
        }
    }
}

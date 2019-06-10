using System;
using DotSvg.Domain.Features.Serializer;
using DotSvg.Models.Attributes;
using Xunit;

namespace DotSvg.Domain.Tests.Features.Serializer
{
    public class EnumConverterTests
    {
        private const string ThirdPropertyName = "driht";
        private const string FourthPropertyName = "htruof";

        public EnumConverterTests()
        {
            Converter = new EnumConverter();
        }

        protected ISvgTypeConverter Converter { get; }

        [Theory]
        [InlineData(NonAttributeEnum.First)]
        [InlineData(EnumWithAttribute.Third)]
        public void EnumTypeShouldBeAllowed(Enum value)
        {
            Assert.True(Converter.CanConvert(value.GetType()));
        }

        [Theory]
        [InlineData("")]
        [InlineData(1)]
        [InlineData(1f)]
        [InlineData(1d)]
        public void NonEnumTypeShouldNotBeAllowed(object value)
        {
            Assert.False(Converter.CanConvert(value.GetType()));
        }

        [Theory]
        [InlineData("first", NonAttributeEnum.First)]
        [InlineData("second", NonAttributeEnum.Second)]
        public void NonAttributeEnumShouldReturnLowered(string expected, Enum value)
        {
            var actual = Converter.Convert(value);
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData(ThirdPropertyName, EnumWithAttribute.Third)]
        [InlineData(FourthPropertyName, EnumWithAttribute.Fourth)]
        public void EnumWithAttributeShouldReturnAsAttributePropertyName(string expected, Enum value)
        {
            var actual = Converter.Convert(value);
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData("")]
        [InlineData(1)]
        [InlineData(1f)]
        [InlineData(1d)]
        public void NonEnumShouldReturnNull(object value)
        {
            var actual = Converter.Convert(value);
            Assert.Null(actual);
        }

        public enum NonAttributeEnum
        {
            First,
            Second
        }

        public enum EnumWithAttribute
        {
            [SvgProperty(ThirdPropertyName)]
            Third,
            [SvgProperty(FourthPropertyName)]
            Fourth
        }
    }
}

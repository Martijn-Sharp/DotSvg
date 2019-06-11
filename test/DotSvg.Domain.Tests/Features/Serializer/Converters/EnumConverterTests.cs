using System;
using DotSvg.Domain.Features.Serializer.Abstractions;
using DotSvg.Domain.Features.Serializer.Converters;
using DotSvg.Models.Attributes;
using Xunit;

namespace DotSvg.Domain.Tests.Features.Serializer.Converters
{
    public class EnumConverterTests
    {
        private const string ThirdPropertyName = "driht";
        private const string FourthPropertyName = "htruof";

        public EnumConverterTests()
        {
            Converter = new EnumConverter();
        }

        protected EnumConverter Converter { get; }

        [Theory]
        [InlineData(typeof(NonAttributeEnum))]
        [InlineData(typeof(EnumWithAttribute))]
        public void EnumTypeShouldBeAllowed(Type type)
        {
            Assert.True(Converter.CanConvert(type));
        }

        [Theory]
        [InlineData(typeof(string))]
        [InlineData(typeof(EnumConverterTests))]
        [InlineData(typeof(int))]
        public void NonEnumTypeShouldNotBeAllowed(Type type)
        {
            Assert.False(Converter.CanConvert(type));
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

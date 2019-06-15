using System;
using DotSvg.Domain.Features.Serializer.Converters;
using DotSvg.Models.DataTypes;
using Xunit;

namespace DotSvg.Domain.Tests.Features.Serializer.Converters
{
    public class TransformListConverterTests
    {
        public TransformListConverterTests()
        {
            Converter = new TransformListConverter(new NumberConverter());
        }

        protected TransformListConverter Converter { get; }

        [Fact]
        public void TransformListTypeShouldBeAllowed()
        {
            Assert.True(Converter.CanConvert(typeof(TransformList)));
        }

        [Theory]
        [InlineData(typeof(string))]
        [InlineData(typeof(TransformListConverterTests))]
        [InlineData(typeof(int))]
        public void NonTransformListTypeShouldNotBeAllowed(Type type)
        {
            Assert.False(Converter.CanConvert(type));
        }
    }
}

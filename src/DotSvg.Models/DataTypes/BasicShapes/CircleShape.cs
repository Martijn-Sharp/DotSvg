using System.Collections.Generic;
using DotSvg.Models.Enumerations;
using DotSvg.Models.SpecialProperties;
using DotSvg.Models.Traits.Enumerations;

namespace DotSvg.Models.DataTypes.BasicShapes
{
    public struct CircleShape : IBasicShape
    {
        public CircleShape(float? shapeRadius, float? position, BoxOptions? geometryBox)
        {
            GeometryBox = geometryBox;
            var parameters = new List<(string, float)>();
            if (shapeRadius.HasValue)
                parameters.Add((null, shapeRadius.Value));

            if(position.HasValue)
                parameters.Add(("at", position.Value));

            Parameters = parameters;
        }

        public CircleShape(float? shapeRadius, CompositeProperty<HorizontalPositionOptions, VerticalPositionOptions> position, BoxOptions? geometryBox)
        {
            GeometryBox = geometryBox;
            var parameters = new List<(string, float)>();
            if (shapeRadius.HasValue)
                parameters.Add((null, shapeRadius.Value));

            // TODO: This calls for a complete revamp of converting objects to strings for the rendering
            parameters.Add(("at", 1f));

            Parameters = parameters;
        }

        public CircleShape(float? shapeRadius,
            CompositeProperty<HorizontalPositionOptions, Length, Percentage> horizontalPosition,
            CompositeProperty<VerticalPositionOptions, Length, Percentage>? verticalPosition, BoxOptions? geometryBox)
        {
            GeometryBox = geometryBox;
            var parameters = new List<(string, float)>();
            if (shapeRadius.HasValue)
                parameters.Add((null, shapeRadius.Value));

            // TODO: This calls for a complete revamp of converting objects to strings for the rendering
            parameters.Add(("at", 1f));
            if(verticalPosition.HasValue)
                parameters.Add((null, 2f));

            Parameters = parameters;
        }

        public CircleShape(float? shapeRadius, bool left, CompositeProperty<Length, Percentage> horizontalPosition, bool top, CompositeProperty<Length, Percentage> verticalPosition, BoxOptions? geometryBox)
        {
            GeometryBox = geometryBox;
            var parameters = new List<(string, float)>();
            if (shapeRadius.HasValue)
                parameters.Add((null, shapeRadius.Value));

            // TODO: This calls for a complete revamp of converting objects to strings for the rendering
            parameters.Add(("at", left ? 0f : 1f ));
            parameters.Add((null, 2f));
            parameters.Add((null, top ? 3f : 4f));
            parameters.Add((null, 5f));

            Parameters = parameters;
        }

        public string Function => "circle";

        public BoxOptions? GeometryBox { get; }

        public IEnumerable<(string Function, float Value)> Parameters { get; }
    }
}

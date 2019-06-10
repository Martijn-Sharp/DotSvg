using System.Collections.Generic;
using DotSvg.Models.Enumerations;

namespace DotSvg.Models.DataTypes.BasicShapes
{
    public struct InsetShape : IBasicShape
    {
        public InsetShape(float top, float right, float bottom, float left, float? borderRadius, BoxOptions? geometryBox)
        {
            GeometryBox = geometryBox;
            var parameters = new List<(string, float)>
            {
                (null, top),
                (null, right),
                (null, bottom),
                (null, left),
            };

            if(borderRadius.HasValue)
                parameters.Add(("round", borderRadius.Value));

            Parameters = parameters;
        }

        public InsetShape(float one, float two, float? borderRadius, BoxOptions? geometryBox) 
            : this(one, one, two, two, borderRadius, geometryBox)
        {
        }

        public InsetShape(float position, float? borderRadius, BoxOptions? geometryBox)
            : this(position, position, position, position, borderRadius, geometryBox)
        {
        }

        public string Function => "inset";

        public BoxOptions? GeometryBox { get; }

        public IEnumerable<(string Function, float Value)> Parameters { get; }
    }
}

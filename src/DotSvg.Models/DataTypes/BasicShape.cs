using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;
using DotSvg.Models.Enumerations;

namespace DotSvg.Models.DataTypes
{
    public interface IBasicShape
    {
        string Function { get; }

        BoxOptions? GeometryBox { get; }

        IEnumerable<(string Function, float Value)> Parameters { get; }
    }

    public struct InsetShape : IBasicShape
    {
        public InsetShape(float top, float right, float bottom, float left, float? borderRadius, BoxOptions? geometryBox)
        {
            GeometryBox = geometryBox;
            var instructions = new List<(string, float)>
            {
                (null, top),
                (null, right),
                (null, bottom),
                (null, left),
            };

            if(borderRadius.HasValue)
                instructions.Add(("round", borderRadius.Value));

            Parameters = instructions;
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

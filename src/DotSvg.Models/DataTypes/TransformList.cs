using System;
using System.Collections.Generic;

namespace DotSvg.Models.DataTypes
{
    public struct TransformList
    {
        private TransformList(string function, params float[] values)
        {
            if(values.Length == 0)
                throw new ArgumentException("Provide at least 1 value", nameof(Values));

            Function = function;
            Values = values;
        }

        public TransformList Matrix(float a, float b, float c, float d, float e, float f)
        {
            return new TransformList("matrix", a, b, c, d, e, f);
        }

        public TransformList Translate(float x, float? y)
        {
            float[] values;
            if (y.HasValue)
                values = new[] {x, y.Value};
            else
                values = new[] {x};

            return new TransformList("translate", values);
        }

        public TransformList Scale(float x, float? y)
        {
            float[] values;
            if (y.HasValue)
                values = new[] { x, y.Value };
            else
                values = new[] { x };

            return new TransformList("scale", values);
        }

        public TransformList Rotate(float a, float? x, float? y)
        {
            var values = new List<float> { a };
            if(x.HasValue)
                values.Add(x.Value);

            if(y.HasValue)
                values.Add(y.Value);

            return new TransformList("rotate", values.ToArray());
        }

        public TransformList SkewX(float a) => new TransformList("skewX", a);

        public TransformList SkewY(float a) => new TransformList("skewY", a);
        
        public string Function { get; }

        public float[] Values { get; }
    }
}

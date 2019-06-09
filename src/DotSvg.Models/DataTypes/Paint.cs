using System;
using System.Diagnostics;
using System.Drawing;
using DotSvg.Models.Enumerations;

namespace DotSvg.Models.DataTypes
{
    public struct Paint
    {
        private Paint(string value)
        {
            Value = value;
        }
        
        public static Paint Url(string reference, X11Colors? color = null)
        {
            if(string.IsNullOrEmpty(reference))
                throw new ArgumentException($"{nameof(reference)} can't be null or empty");

            if (!reference.StartsWith("#"))
                reference = "#" + reference;

            if(!color.HasValue)
                return new Paint($"Url({reference}");

            return new Paint($"Url({reference} {Enum.GetName(typeof(X11Colors), color.Value)}");
        }
        
        public static Paint Color(Color color) => new Paint(color.Value);

        public static Paint Context(ContextOptions context)
        {
            string contextOption;
            switch (context)
            {
                case ContextOptions.Fill:
                    contextOption = "context-fill";
                    break;
                case ContextOptions.Stroke:
                    contextOption = "context-stroke";
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(context), context, null);
            }

            return new Paint(contextOption);
        }

        public string Value { get; }

        public static implicit operator Paint(Color color) => Color(color);

        public static implicit operator Paint(ContextOptions contextOption) => Context(contextOption);

        public override string ToString()
        {
            return Value;
        }

        public enum ContextOptions
        {
            Fill,
            Stroke
        }
    }
}

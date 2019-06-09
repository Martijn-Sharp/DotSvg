using System;
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
        
        public static Paint Url(string reference, Css3ColorCodes? color = null)
        {
            if(string.IsNullOrEmpty(reference))
                throw new ArgumentException($"{nameof(reference)} can't be null or empty");

            if (!reference.StartsWith("#"))
                reference = "#" + reference;

            if(!color.HasValue)
                return new Paint($"Url({reference}");

            return new Paint($"Url({reference} {Enum.GetName(typeof(Css3ColorCodes), color.Value)}");
        }

        public static Paint Code(Css3ColorCodes code)
        {
            return new Paint(Enum.GetName(typeof(Css3ColorCodes), code));
        }

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

        public static implicit operator Paint(Css3ColorCodes colorCode) => Code(colorCode);

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

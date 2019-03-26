using System;
using System.Drawing;

namespace DotSvg.Models.DataTypes
{
    public struct Paint
    {
        private Paint(string value)
        {
            Value = value;
        }
        
        public Paint Url(string reference, string color = null)
        {
            if(string.IsNullOrEmpty(reference))
                throw new ArgumentException($"{nameof(reference)} can't be null or empty");

            if (!reference.StartsWith("#"))
                reference = "#" + reference;

            if(string.IsNullOrEmpty(color))
                return new Paint($"Url({reference}");

            return new Paint($"Url({reference} {color}");
        }

        public Paint Color(string color) => new Paint(color);

        public Paint Context(ContextOptions context)
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

        public enum ContextOptions
        {
            Fill,
            Stroke
        }
    }
}

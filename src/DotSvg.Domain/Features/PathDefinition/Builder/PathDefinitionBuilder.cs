using System;
using System.Collections.Generic;
using System.Globalization;
using DotSvg.Domain.Features.PathDefinition.Models;
using DotSvg.Domain.Features.PathDefinition.Renderer;

namespace DotSvg.Domain.Features.PathDefinition.Builder
{
    public class PathDefinitionBuilder : IPathDefinitionBuilder
    {
        private readonly IList<PathDefinitionInstruction> _instructions = new List<PathDefinitionInstruction>();

        /// <summary>
        /// SVGs parses numbers either as `[+-]? [0-9]* "." [0-9]+``or in attributes as `[+-]? [0-9]* "." [0-9]+ ([Ee] integer)?`
        /// To accomplish this we use the english culture
        /// </summary>
        protected CultureInfo Culture { get; } = new CultureInfo("en");

        public string Build(PathDefinitionBuilderSettings settings)
        {
            IPathDefinitionRenderer renderer;
            if(settings.Pretty)
                renderer = new PathDefinitionPrettyRenderer();
            else
                renderer = new PathDefinitionUglyRenderer();

            return renderer.Render(_instructions);
        }

        public IPathDefinitionBuilder MoveTo(float x, float y, bool absolute = true)
        {
            _instructions.Add(new PathDefinitionInstruction(absolute ? 'M' : 'm', x.ToString(Culture), y.ToString(Culture)));
            return this;
        }

        public IPathDefinitionBuilder LineTo(float? x, float? y, bool absolute = true)
        {
            if (!x.HasValue & !y.HasValue)
                throw new ArgumentNullException($"Provide a value for at least one of either '{nameof(x)}' or '{nameof(y)}' parameters");

            PathDefinitionInstruction instruction;
            if (!x.HasValue)
                instruction = new PathDefinitionInstruction(absolute ? 'V' : 'v', y.Value.ToString(Culture));
            else if (!y.HasValue)
                instruction = new PathDefinitionInstruction(absolute ? 'H' : 'h', x.Value.ToString(Culture));
            else
                instruction = new PathDefinitionInstruction(absolute ? 'L' : 'l', x.Value.ToString(Culture), y.Value.ToString(Culture));

            _instructions.Add(instruction);
            return this;
        }

        public IPathDefinitionBuilder CubicBezier()
        {
            throw new NotImplementedException();
        }

        public IPathDefinitionBuilder QuadraticBezier()
        {
            throw new NotImplementedException();
        }

        public IPathDefinitionBuilder Arc(float xRadius, float yRadius, float angle, bool largeArc, bool sweep, float x, float y, bool absolute = true)
        {
            _instructions.Add(new PathDefinitionInstruction(absolute ? 'A' : 'a', 
                xRadius.ToString(Culture),
                yRadius.ToString(Culture), 
                angle.ToString(Culture), 
                largeArc ? "1" : "0", 
                sweep ? "1" : "0",
                x.ToString(Culture), 
                y.ToString(Culture)));
            return this;
        }

        public IPathDefinitionBuilderExecutioner Close(bool absolute = true)
        {
            _instructions.Add(new PathDefinitionInstruction(absolute ? 'Z' : 'z'));
            return this;
        }
    }
}

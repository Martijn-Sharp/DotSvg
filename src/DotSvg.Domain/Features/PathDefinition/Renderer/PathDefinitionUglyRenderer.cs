using System.Collections.Generic;
using System.Linq;
using System.Text;
using DotSvg.Domain.Features.PathDefinition.Models;

namespace DotSvg.Domain.Features.PathDefinition.Renderer
{
    public class PathDefinitionUglyRenderer : IPathDefinitionRenderer
    {
        private const char BogusCommand = '_';

        public string Render(IEnumerable<PathDefinitionInstruction> instructions)
        {
            var stringBuilder = new StringBuilder();
            PathDefinitionInstruction lastInstruction = new PathDefinitionInstruction(BogusCommand);
            foreach (var instruction in instructions)
            {
                stringBuilder.Append(instruction.Command.Equals(lastInstruction.Command) ? ',' : instruction.Command);
                if (instruction.Parameters.Length == 1)
                    stringBuilder.Append(instruction.Parameters[0]);
                else if (instruction.Parameters.Length > 1)
                    stringBuilder.Append(instruction.Parameters.Aggregate((x, y) => $"{x},{y}"));
                
                lastInstruction = instruction;
            }

            return stringBuilder.ToString();
        }
    }
}

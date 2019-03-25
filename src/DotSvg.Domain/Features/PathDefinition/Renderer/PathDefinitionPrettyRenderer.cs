using System.Collections.Generic;
using System.Linq;
using System.Text;
using DotSvg.Domain.Features.PathDefinition.Models;

namespace DotSvg.Domain.Features.PathDefinition.Renderer
{
    public class PathDefinitionPrettyRenderer : IPathDefinitionRenderer
    {
        public string Render(IEnumerable<PathDefinitionInstruction> instructions)
        {
            var stringBuilder = new StringBuilder();
            foreach (var instruction in instructions)
            {
                stringBuilder.Append(instruction.Command);
                stringBuilder.Append(' ');

                if (instruction.Parameters.Length == 1)
                    stringBuilder.Append(instruction.Parameters[0]);
                else if (instruction.Parameters.Length > 1)
                    stringBuilder.Append(instruction.Parameters.Aggregate((x, y) => $"{x}, {y}"));
                
                stringBuilder.AppendLine();
            }

            return stringBuilder.ToString().Trim();
        }
    }
}

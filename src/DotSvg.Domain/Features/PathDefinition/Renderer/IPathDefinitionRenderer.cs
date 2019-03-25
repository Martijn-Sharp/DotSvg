using System.Collections.Generic;
using DotSvg.Domain.Features.PathDefinition.Models;

namespace DotSvg.Domain.Features.PathDefinition.Renderer
{
    public interface IPathDefinitionRenderer
    {
        string Render(IEnumerable<PathDefinitionInstruction> instructions);
    }
}

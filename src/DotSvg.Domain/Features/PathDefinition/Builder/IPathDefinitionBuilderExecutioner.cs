namespace DotSvg.Domain.Features.PathDefinition.Builder
{
    public interface IPathDefinitionBuilderExecutioner
    {
        string Build(PathDefinitionBuilderSettings settings);
    }
}
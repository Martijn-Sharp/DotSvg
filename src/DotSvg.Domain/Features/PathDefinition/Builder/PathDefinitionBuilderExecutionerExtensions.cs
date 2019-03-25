namespace DotSvg.Domain.Features.PathDefinition.Builder
{
    public static class PathDefinitionBuilderExecutionerExtensions
    {
        public static string Build(this IPathDefinitionBuilderExecutioner executioner)
        {
            return executioner.Build(PathDefinitionBuilderSettings.DefaultSettings);
        }
    }
}

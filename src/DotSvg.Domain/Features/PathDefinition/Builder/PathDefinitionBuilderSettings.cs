namespace DotSvg.Domain.Features.PathDefinition.Builder
{
    public class PathDefinitionBuilderSettings
    {
        public static PathDefinitionBuilderSettings DefaultSettings = new PathDefinitionBuilderSettings
        {
            Pretty = false
        };

        public bool Pretty { get; set; }
    }
}

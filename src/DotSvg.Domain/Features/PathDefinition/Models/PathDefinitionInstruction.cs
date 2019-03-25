namespace DotSvg.Domain.Features.PathDefinition.Models
{
    public struct PathDefinitionInstruction
    {
        public PathDefinitionInstruction(char command, params string[] parameters)
        {
            Command = command;
            Parameters = parameters;
        }

        public char Command { get; }

        public string[] Parameters { get; }
    }
}

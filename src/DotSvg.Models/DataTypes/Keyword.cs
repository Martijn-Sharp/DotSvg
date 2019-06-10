namespace DotSvg.Models.DataTypes
{
    public interface IKeyword
    {
        string Value { get; }
    }

    public static class Keyword
    {
        public static InheritKeyword Inherit { get; } = new InheritKeyword();

        public static InitialKeyword Initial { get; } = new InitialKeyword();

        public static UnsetKeyword Unset { get; } = new UnsetKeyword();
    }

    public struct InheritKeyword : IKeyword
    {
        public string Value => "inherit";
    }

    public struct InitialKeyword : IKeyword
    {
        public string Value => "initial";
    }

    public struct UnsetKeyword : IKeyword
    {
        public string Value => "unset";
    }
}

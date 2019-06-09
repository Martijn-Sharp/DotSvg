namespace DotSvg.Models.DataTypes
{
    public interface IKeyword
    {
        string Value { get; }
    }

    public static class Keyword
    {
        public static NoneKeyword None { get; } = new NoneKeyword();

        public static InheritKeyword Inherit { get; } = new InheritKeyword();
    }

    public struct NoneKeyword : IKeyword
    {
        public string Value => "none";
    }

    public struct InheritKeyword : IKeyword
    {
        public string Value => "inherit";
    }
}

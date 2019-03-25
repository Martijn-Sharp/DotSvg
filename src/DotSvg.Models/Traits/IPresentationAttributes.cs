namespace DotSvg.Models.Traits
{
    public interface IPresentation
    {
        string Fill { get; set; }

        string Stroke { get; set; }
        
        string StrokeWidth { get; set; }
    }
}

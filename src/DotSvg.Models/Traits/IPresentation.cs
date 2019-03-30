using DotSvg.Models.DataTypes;

namespace DotSvg.Models.Traits
{
    public interface IPresentation
    {
        Paint Fill { get; set; }

        Paint Stroke { get; set; }

        Length StrokeWidth { get; set; }
    }
}

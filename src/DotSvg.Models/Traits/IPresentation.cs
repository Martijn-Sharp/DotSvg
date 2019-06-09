using DotSvg.Models.DataTypes;
using DotSvg.Models.Traits.Enumerations;

namespace DotSvg.Models.Traits
{
    public interface IPresentation
    {
        AlignmentBaselineOptions? AlignmentBaseline { get; set; }

        // TODO: has both enumeration AND length
        string BaselineShift { get; set; }

        string ClipPath { get; set; }

        RuleOptions? ClipRule { get; set; }

        Color? Color { get; set; }

        ColorInterpolationOptions? ColorInterpolation { get; set; }

        ColorInterpolationOptions? ColorInterpolationFilters { get; set; }

        RenderingOptions? ColorRendering { get; set; }

        string Cursor { get; set; }

        DirectionOptions? Direction { get; set; }

        string Display { get; set; }

        DominantBaselineOptions? DominantBaseline { get; set; }

        Paint? Fill { get; set; }

        // TODO: get angry with idiot wildwestweb values later
        string FillOpacity { get; set; }

        RuleOptions? FillRule { get; set; }

        string Filter { get; set; }

        Color? FloodColor { get; set; }

        // TODO: get angry with idiot wildwestweb values later
        string FloodOpacity { get; set; }

        string FontFamily { get; set; }

        string FontSize { get; set; }

        // TODO: get angry with idiot wildwestweb values later
        string FontSizeAdjust { get; set; }

        string FontStretch { get; set; }

        string FontVariant { get; set; }

        // TODO: get angry with idiot wildwestweb values later
        string FontWeight { get; set; }

        RenderingOptions? ImageRendering { get; set; }

        Paint? Stroke { get; set; }

        Length? StrokeWidth { get; set; }
    }
}

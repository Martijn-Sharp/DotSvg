using System;
using DotSvg.Models.DataTypes;
using DotSvg.Models.DataTypes.BasicShapes;
using DotSvg.Models.SpecialProperties;
using DotSvg.Models.Traits.Enumerations;

namespace DotSvg.Models.Traits
{
    /// <remarks>Source: https://developer.mozilla.org/nl/docs/Web/SVG/Attribute/Presentation </remarks>
    public interface IPresentation
    {
        AlignmentBaselineOptions? AlignmentBaseline { get; set; }

        /// <remarks>This property is going to be deprecated, I'll leave the string-type as it is</remarks>
        string BaselineShift { get; set; }

        CompositeProperty<Uri, IBasicShape, InheritKeyword>? ClipPath { get; set; }

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

        CompositeProperty<ZeroToOne, Percentage>? FillOpacity { get; set; }

        RuleOptions? FillRule { get; set; }

        string Filter { get; set; }

        Color? FloodColor { get; set; }

        CompositeProperty<ZeroToOne, Percentage>? FloodOpacity { get; set; }

        string FontFamily { get; set; }

        string FontSize { get; set; }

        CompositeProperty<float, InheritKeyword>? FontSizeAdjust { get; set; }

        string FontStretch { get; set; }

        string FontVariant { get; set; }

        // TODO: get angry with idiot wildwestweb values later
        string FontWeight { get; set; }

        RenderingOptions? ImageRendering { get; set; }

        Paint? Stroke { get; set; }

        Length? StrokeWidth { get; set; }
    }
}

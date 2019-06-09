using System.ComponentModel;
using DotSvg.Models.DataTypes;
using DotSvg.Models.Traits;
using DotSvg.Models.Traits.Enumerations;

namespace DotSvg.Models
{
    public abstract class SvgElement : IPresentation
    {
        [DisplayName("alignment-baseline")]
        public AlignmentBaselineOptions? AlignmentBaseline { get; set; }

        [DisplayName("baseline-shift")]
        public string BaselineShift { get; set; }

        [DisplayName("clip-path")]
        public string ClipPath { get; set; }

        [DisplayName("clip-rule")]
        public RuleOptions? ClipRule { get; set; }

        public Color? Color { get; set; }

        [DisplayName("color-interpolation")]
        public ColorInterpolationOptions? ColorInterpolation { get; set; }

        [DisplayName("color-interpolation-filters")]
        public ColorInterpolationOptions? ColorInterpolationFilters { get; set; }

        [DisplayName("color-rendering")]
        public RenderingOptions? ColorRendering { get; set; }

        public string Cursor { get; set; }

        public DirectionOptions? Direction { get; set; }

        public string Display { get; set; }

        [DisplayName("dominant-baseline")]
        public DominantBaselineOptions? DominantBaseline { get; set; }

        public Paint? Fill { get; set; }

        [DisplayName("fill-opacity")]
        public string FillOpacity { get; set; }

        [DisplayName("fill-rule")]
        public RuleOptions? FillRule { get; set; }

        public string Filter { get; set; }

        [DisplayName("flood-color")]
        public Color? FloodColor { get; set; }

        [DisplayName("flood-opacity")]
        public string FloodOpacity { get; set; }

        [DisplayName("font-family")]
        public string FontFamily { get; set; }

        [DisplayName("font-size")]
        public string FontSize { get; set; }

        [DisplayName("font-size-adjust")]
        public string FontSizeAdjust { get; set; }

        [DisplayName("font-stretch")]
        public string FontStretch { get; set; }

        [DisplayName("font-variant")]
        public string FontVariant { get; set; }

        [DisplayName("font-weight")]
        public string FontWeight { get; set; }

        [DisplayName("image-rendering")]
        public RenderingOptions? ImageRendering { get; set; }

        public Paint? Stroke { get; set; }

        [DisplayName("stroke-width")]
        public Length? StrokeWidth { get; set; }
    }
}

using System.ComponentModel;
using DotSvg.Models.DataTypes;
using DotSvg.Models.Traits;

namespace DotSvg.Models
{
    public abstract class SvgElement : IPresentation
    {
        public Paint Fill { get; set; }

        public Paint Stroke { get; set; }

        [DisplayName("stroke-width")]
        public Length StrokeWidth { get; set; }
    }
}

using System.ComponentModel;
using DotSvg.Models.Traits;

namespace DotSvg.Models
{
    public abstract class SvgElement : IPresentation
    {
        public string Fill { get; set; }

        public string Stroke { get; set; }

        [DisplayName("stroke-width")]
        public string StrokeWidth { get; set; }
    }
}

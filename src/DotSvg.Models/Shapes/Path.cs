using System.ComponentModel;

namespace DotSvg.Models.Shapes
{
    public class Path : SvgElement
    {
        [DisplayName("d")]
        public string PathData { get; set; }
    }
}

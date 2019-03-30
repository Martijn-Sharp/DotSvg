using System.ComponentModel;

namespace DotSvg.Models.Shapes
{
    public class Path : SvgElement
    {
        /// <summary>This defines the shape of the path.</summary>
        [DisplayName("d")]
        public string Definition { get; set; }

        /// <summary>This lets specify the total length for the path, in user units.</summary>
        public float PathLength { get; set; }
    }
}

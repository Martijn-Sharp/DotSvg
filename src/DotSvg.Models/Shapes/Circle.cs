using System.ComponentModel;

namespace DotSvg.Models.Shapes
{
    public class Circle : SvgElement
    {
        /// <summary>This defines the x-axis coordinate of the center of the element.</summary>
        [DisplayName("cx")]
        public string XAxisCoordinate { get; set; }

        /// <summary>This defines the y-axis coordinate of the center of the element.</summary>
        [DisplayName("cy")]
        public string YAxisCoordinate { get; set; }

        /// <summary>
        /// This defines the radius of the element.
        /// A value lower or equal to zero disables rendering of the circle.
        /// </summary>
        [DisplayName("r")]
        public string Radius { get; set; }
        
        /// <summary>This lets specify the total length for the path, in user units.</summary>
        public string PathLength { get; set; }
    }
}

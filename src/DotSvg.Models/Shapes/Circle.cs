using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace DotSvg.Models.Shapes
{
    public class Circle : SvgElement
    {
        [DisplayName("cx")]
        public string XAxisCoordinate { get; set; }

        [DisplayName("yx")]
        public string YAxisCoordinate { get; set; }

        [DisplayName("r")]
        public string Radius { get; set; }
    }
}

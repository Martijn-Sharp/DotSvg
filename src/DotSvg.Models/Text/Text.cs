using System.ComponentModel;
using DotSvg.Models.Text.Enumerations;

namespace DotSvg.Models.Text
{
    public class Text : SvgElement
    {
        /// <summary>This determines the x coordinate of the starting point of the text baseline.</summary>
        public string X { get; set; }

        /// <summary>This determines the y coordinate of the starting point of the text baseline.</summary>
        public string Y { get; set; }

        /// <summary>This allows to shift the text position horizontally.</summary>
        [DisplayName("dx")]
        public string XShift { get; set; }

        /// <summary>This allows to shift the text position vertically.</summary>
        [DisplayName("dy")]
        public string YShift { get; set; }

        /// <summary>This set the orientation of each individual glyph.</summary>
        public string Rotate { get; set; }

        /// <summary>This determines how the text is stretched or compressed to fit the width define by the textLength attribute.</summary>
        public LengthAdjustOptions LengthAdjust { get; set; }

        /// <summary>This lets specify the width into which the text will be drawn.</summary>
        public string TextLength { get; set; }
    }
}

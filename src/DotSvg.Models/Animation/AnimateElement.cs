using System.ComponentModel;
using DotSvg.Models.DataTypes;

namespace DotSvg.Models.Animation
{
    public class AnimateElement : SvgElement
    {
        public string AttributeName { get; set; }

        public Time? Begin { get; set; }

        [DisplayName("dur")]
        public Time? Duration { get; set; }

        public float? From { get; set; }

        public string KeyTimes { get; set; }

        public int? RepeatCount { get; set; }

        public float? To { get; set; }

        public string Values { get; set; }
    }
}

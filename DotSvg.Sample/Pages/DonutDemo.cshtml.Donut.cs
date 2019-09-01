using System.Collections.Generic;
using DotSvg.Models;
using DotSvg.Models.Shapes;
using DotSvg.Models.Text;

namespace DotSvg.Sample.Pages
{
    public class Donut
    {
        public IList<Fragment> Fragments { get; set; }
        
        public Circle BaseCircle { get; set; }

        public string Text { get; set; }
    }
}

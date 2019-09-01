using DotSvg.Models.Animation;
using DotSvg.Models.Shapes;

namespace DotSvg.Sample.Pages
{
    public class Fragment
    {
        public string Title { get; set; }

        public Path Path { get; set; }

        public AnimateElement PathAnimation { get; set; }

        public Circle BackupCircle { get; set; }

        public AnimateElement BackupCircleAnimation { get; set; }
    }
}

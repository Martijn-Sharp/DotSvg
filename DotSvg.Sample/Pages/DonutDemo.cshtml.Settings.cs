namespace DotSvg.Sample.Pages
{
    public class Settings
    {
        public float Rotation { get; set; }

        public float Thickness { get; set; }

        public float HalfThickness => Thickness / 2;

        public string DefaultColor { get; set; }
    }
}

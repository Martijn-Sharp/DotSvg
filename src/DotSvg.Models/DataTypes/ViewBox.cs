namespace DotSvg.Models.DataTypes
{
    public struct ViewBox
    {
        public ViewBox(float minX, float minY, float width, float height)
        {
            MinX = minX;
            MinY = minY;
            Width = width;
            Height = height;
        }

        public float MinX { get; }

        public float MinY { get; }

        public float Width { get; }

        public float Height { get; }
    }
}

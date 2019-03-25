namespace DotSvg.Domain.Features.PathDefinition.Builder
{
    public interface IPathDefinitionBuilder : IPathDefinitionBuilderExecutioner
    {
        /// <summary>
        /// MoveTo instructions can be thought of as picking up the drawing instrument,
        /// and setting it down somewhere else, i.e. moving the current point (Po; {xo, yo}).
        /// There is no line drawn between Po and the new current point (Pn; {xn, yn}).
        /// </summary>
        /// <param name="x">X-axis coordinate</param>
        /// <param name="y">Y-axis coordinate</param>
        /// <param name="absolute">Absolute positioning</param>
        IPathDefinitionBuilder MoveTo(float x, float y, bool absolute = true);

        /// <summary>
        /// LineTo instructions draw a straight line from the current point (Po; {xo, yo})
        /// to the end point (Pn; {xn, yn}) based on the parameters specified.
        /// The end point (Pn) then becomes the current point for the next command (Po').
        /// </summary>
        /// <param name="x">End point x-axis coordinate</param>
        /// <param name="y">End point y-axis coordinate</param>
        /// <param name="absolute">Absolute positioning</param>
        IPathDefinitionBuilder LineTo(float? x, float? y, bool absolute = true);

        IPathDefinitionBuilder CubicBezier();

        IPathDefinitionBuilder QuadraticBezier();

        /// <summary>
        /// Elliptical arc curves are curves defined as a portion of an ellipse.
        /// It is sometimes easier to draw highly regular curves with an elliptical arc than with a Bézier curve.
        /// </summary>
        /// <param name="xRadius">X-axis radius</param>
        /// <param name="yRadius">Y-axis radius</param>
        /// <param name="angle">Rotation (in degree) of the ellipse relative to the x-axis</param>
        /// <param name="largeArc">Large arc or small arc</param>
        /// <param name="sweep">Clockwise (true) or anti-clockwise (false)</param>
        /// <param name="x">End point x-axis coordinate</param>
        /// <param name="y">End point y-axis coordinate</param>
        /// <param name="absolute">Absolute positioning</param>
        /// <returns></returns>
        IPathDefinitionBuilder Arc(float xRadius, float yRadius, float angle, bool largeArc, bool sweep, float x, float y, bool absolute = true);

        /// <summary>
        /// ClosePath instructions draw a straight line from the current position, to the first point in the path.
        /// </summary>
        /// <param name="absolute">Absolute positioning</param>
        IPathDefinitionBuilderExecutioner Close(bool absolute = true);
    }
}

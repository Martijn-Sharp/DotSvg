using System.Collections.Generic;
using DotSvg.Models.Enumerations;

namespace DotSvg.Models.DataTypes.BasicShapes
{
    public interface IBasicShape
    {
        string Function { get; }

        BoxOptions? GeometryBox { get; }

        IEnumerable<(string Function, float Value)> Parameters { get; }
    }
}
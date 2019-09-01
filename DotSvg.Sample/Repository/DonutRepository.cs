using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotSvg.Sample.Repository
{
    public class DonutRepository
    {
        public IEnumerable<IEnumerable<Slice>> GetSlices()
        {
            return new List<IEnumerable<Slice>>
            {
                new List<Slice>
                {
                    new Slice {Name = "Full", Percentage = 100, Color = "#CAD381"}
                },
                new List<Slice>
                {
                    new Slice {Name = "First half", Percentage = 60, Color = "#CAD381"},
                    new Slice {Name = "Second half", Percentage = 39, Color = "#61A3D8"},
                },
                new List<Slice>
                {
                    new Slice {Name = "First", Percentage = 47, Color = "#CAD381"},
                    new Slice {Name = "Second", Percentage = 30, Color = "#61A3D8"},
                    new Slice {Name = "Third", Percentage = 23, Color = "#A6C7E9"}
                },
                new List<Slice>(),
                new List<Slice>
                {
                    new Slice{Name = "Incomplete", Percentage = 62, Color = "#CAD381" }
                },
                new List<Slice>
                {
                    new Slice {Name = "First", Percentage = 33, Color = "#CAD381"},
                    new Slice {Name = "Second", Percentage = 20, Color = "#61A3D8"},
                    new Slice {Name = "Third", Percentage = 17, Color = "#A6C7E9"},
                    new Slice {Name = "Fourth", Percentage = 20, Color = "brown"},
                    new Slice {Name = "Fifth", Percentage = 25, Color = "#yellow"}
                }
            };
        }
    }
}

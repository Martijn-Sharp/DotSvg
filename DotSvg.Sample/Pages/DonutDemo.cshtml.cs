using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DotSvg.Models;
using DotSvg.Models.DataTypes;
using DotSvg.Models.Text;
using DotSvg.Models.Traits.Enumerations;
using DotSvg.Sample.Factories;
using DotSvg.Sample.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DotSvg.Sample.Pages
{
    public class DonutDemoModel : PageModel
    {
        public DonutDemoModel()
        {
            Factory = new DonutViewModelFactory();
            Repository = new DonutRepository();
        }

        public IEnumerable<Donut> Donuts { get; set; }

        public SvgRoot Svg { get; set; }

        public Text TextElement { get; set; }

        protected DonutViewModelFactory Factory { get; }

        protected DonutRepository Repository { get; }

        public void OnGet()
        {
            Svg = new SvgRoot { ViewBox = new ViewBox(-1, -1, 2, 2) };
            TextElement = new Text
            {
                X = 0,
                Y = 0,
                TextAnchor = TextAnchorOptions.Middle,
                DominantBaseline = DominantBaselineOptions.Middle
            };

            var donuts = Repository.GetSlices();
            var settings = new Settings { Thickness = 0.26f, DefaultColor = "#EEEEEE", Rotation = -90f };
            Donuts = donuts.Select(slices => Factory.Build(slices, settings, $"{GetEffectivePercentage(slices)}%"));
        }

        private int GetEffectivePercentage(IEnumerable<Slice> slices)
        {
            int cumulative = 0;
            foreach (var slice in slices)
            {
                if (cumulative + slice.Percentage > 100)
                    return cumulative;

                cumulative += slice.Percentage;
            }

            return cumulative;
        }
    }
}
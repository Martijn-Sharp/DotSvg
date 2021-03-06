﻿using System.Collections.Generic;
using DotSvg.Domain.Features.PathDefinition.Builder;
using DotSvg.Models;
using DotSvg.Models.Shapes;
using DotSvg.Models.Text;
using DotSvg.Models.Text.Enumerations;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DotSvg.Sample.Pages
{
    public class IndexModel : PageModel
    {
        public void OnGet()
        {
            Svg = new SvgRoot { ViewBox = "-1 -1 2 2" };

            Circle = new Circle
            {
                XAxisCoordinate = "0",
                YAxisCoordinate = "0",
                Radius = "0.9",
                Stroke = "grey",
                StrokeWidth = "0.2",
                Fill = "transparent"
            };

            var redPath = new PathDefinitionBuilder()
                .MoveTo(0, 1)
                .Arc(1, 1, 0, false, true, -1, 0)
                .Arc(0.1f, 0.1f, 0, true, true, -0.8f, 0)
                .Arc(0.8f, 0.8f, 0, false, false, 0, 0.8f)
                .Arc(0.1f, 0.1f, 0, true, false, 0, 1)
                .Build();

            var settings = new PathDefinitionBuilderSettings { Pretty = true };
            var greenPath = new PathDefinitionBuilder()
                .MoveTo(-1, 0)
                .Arc(1, 1, 0, false, true, 0, -1)
                .Arc(0.1f, 0.1f, 0, true, true, 0, -0.8f)
                .Arc(0.8f, 0.8f, 0, false, false, -0.8f, 0)
                .Arc(0.1f, 0.1f, 0, true, false, -1, 0)
                .Build(settings);
            
            Paths = new List<Path>
            {
                new Path { Fill = "blue", Definition = "M0,-1 A1,1,0,0,1,1,0 A0.1,0.1,0,1,1,0.8,0 A0.8,0.8,0,0,0,0,-0.8 A0.1,0.1,0,1,0,0,-1"},
                new Path { Fill = "yellow", Definition = "M1,0 A1,1,0,0,1,0,1 A0.1,0.1,0,1,1,0,0.8 A0.8,0.8,0,0,0,0.8,0 A0.1,0.1,0,1,0,1,0"},
                new Path { Fill = "red", Definition = redPath },
                new Path { Fill = "green", Definition = greenPath }
            };

            Text = new Text { X = "0", Y = "0", TextLength = "10", LengthAdjust = LengthAdjustOptions.SpacingAndGlyphs};
        }

        public SvgRoot Svg { get; set; }

        public Circle Circle { get; set; }

        public IEnumerable<Path> Paths { get; set; }

        public Text Text { get; set; }
    }
}

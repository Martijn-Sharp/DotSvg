using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Linq;
using DotSvg.Domain.Features.PathDefinition.Builder;
using DotSvg.Models.Animation;
using DotSvg.Models.DataTypes;
using DotSvg.Models.Enumerations;
using DotSvg.Models.Shapes;
using DotSvg.Models.Traits.Enumerations;
using DotSvg.Sample.Pages;
using DotSvg.Sample.Repository;

namespace DotSvg.Sample.Factories
{
    public class DonutViewModelFactory
    {
        public DonutViewModelFactory()
        {
            BuilderSettings = new PathDefinitionBuilderSettings
            {
                //Pretty = true
            };
        }

        protected PathDefinitionBuilderSettings BuilderSettings { get; }

        public Donut Build(IEnumerable<Slice> slices, Settings settings, string text)
        {
            var viewModel = new Donut
            {
                Fragments = new List<Fragment>(), Text = text, BaseCircle = new Circle { XAxisCoordinate = 0, YAxisCoordinate = 0, Radius = 1 - settings.HalfThickness, Stroke = TryGetColor(settings.DefaultColor), StrokeWidth = settings.Thickness, Fill = Paint.Transparent() }
            };

            var rotationAdjustment = Math.PI / (settings.HalfThickness * Math.PI);
            var totalPercentage = slices.Sum(x => x.Percentage);
            var rotation = totalPercentage < 98 || totalPercentage > 100 ? settings.Rotation : settings.Rotation - rotationAdjustment;

            int cumulativePercentage = 0;
            var slicesCount = slices.Count();
            foreach (var slice in slices)
            {
                if (cumulativePercentage + slice.Percentage > 100)
                    break;

                var path = new Path { Fill = TryGetColor(slice.Color) };
                var steps = Enumerable.Range(cumulativePercentage, slice.Percentage + 1)
                    .Select(x => CreateStep(cumulativePercentage, x, rotation, x - cumulativePercentage));

                var fragmentStart = GetCoordinatesForPercentage(cumulativePercentage, rotation);
                var frames = steps.Select(step => CreateFrame(fragmentStart, step, totalPercentage >= 98, 1 - settings.Thickness, settings.HalfThickness));
                var framesCount = frames.Count();
                var keyTimes = Enumerable.Range(1, framesCount).Select(x => GetKeyTime(cumulativePercentage, slice.Percentage, x, framesCount).ToString(new CultureInfo("en")));
                var animation = new AnimateElement
                {
                    AttributeName = "d",
                    Duration = new Time(1000, Time.UnitOptions.Milliseconds),
                    Fill = slicesCount == 1 && cumulativePercentage + slice.Percentage == 100 ? AnimateFillOptions.None : AnimateFillOptions.Freeze,
                    Values = $"L0,0L0,0L0,0;{frames.Aggregate((x, y) => $"{x};{y}")};{frames.Last()}",
                    KeyTimes = $"0;{keyTimes.Aggregate((x, y) => $"{x};{y}")};1"
                };

                Circle backupCircle = null;
                AnimateElement backupCircleAnimation = null;
                if (slicesCount == 1 && cumulativePercentage + slice.Percentage == 100)
                {
                    backupCircle = new Circle {XAxisCoordinate = 0, YAxisCoordinate = 0, Radius = 1 - settings.HalfThickness, Stroke = TryGetColor(slice.Color), StrokeWidth = settings.Thickness, Fill = Paint.Transparent(), Opacity = new Percentage(0)};
                    backupCircleAnimation = new AnimateElement
                    {
                        Begin = new Time(1000 - 1, Time.UnitOptions.Milliseconds),
                        Duration = new Time(1, Time.UnitOptions.Milliseconds),
                        AttributeName = "opacity",
                        From = 0,
                        To = 1,
                        Fill = AnimateFillOptions.Freeze
                    };
                }

                var fragment = new Fragment
                {
                    Path = path,
                    PathAnimation = animation,
                    Title = $"{slice.Name} {slice.Percentage}%",
                    BackupCircle = backupCircle,
                    BackupCircleAnimation = backupCircleAnimation
                };
                viewModel.Fragments.Insert(0, fragment);
                cumulativePercentage += slice.Percentage;
            }

            return viewModel;
        }

        private Step CreateStep(int startingPercentage, int percentage, double rotation, int index)
        {
            return new Step
            {
                End = GetCoordinatesForPercentage(percentage, rotation),
                LargeArcFlag = percentage - startingPercentage > 50,
                Index = index
            };
        }

        private PointF GetCoordinatesForPercentage(int percentage, double rotation)
        {
            var radiant = (PercentageToDegree(percentage) + rotation) * Math.PI / 180;
            var x = Math.Cos(radiant);
            var y = Math.Sin(radiant);
            return new PointF(Convert.ToSingle(x), Convert.ToSingle(y));
        }

        private double PercentageToDegree(int percentage)
        {
            return percentage * 3.6;
        }

        private string CreateFrame(PointF fragmentStart, Step step, bool shouldRound, float thickness, float halfThickness)
        {
            var builder = new PathDefinitionBuilder();
            builder.MoveTo(fragmentStart.X, fragmentStart.Y);
            builder.Arc(1, 1, 0, step.LargeArcFlag, true, step.End.X, step.End.Y);
            if (step.Index > 0)
                builder.Arc(halfThickness, halfThickness, 0, true, true, step.End.X * thickness, step.End.Y * thickness);
            else
                builder.LineTo(step.End.X * thickness, step.End.Y * thickness);

            builder.Arc(thickness, thickness, 0, step.LargeArcFlag, false, fragmentStart.X * thickness, fragmentStart.Y * thickness);

            if (step.Index > 0 && shouldRound)
                builder.Arc(halfThickness, halfThickness, 0, true, false, fragmentStart.X, fragmentStart.Y);

            return builder.Build(BuilderSettings);
        }

        private double GetKeyTime(int cumulativePercentage, int percentage, int stepIndex, int totalSteps)
        {
            var startingTime = cumulativePercentage / 100d;
            var endTime = (cumulativePercentage + percentage) / 100d;

            // increment with delta
            var delta = (endTime - startingTime) / totalSteps * stepIndex;

            return startingTime + delta;
        }

        private Models.DataTypes.Color TryGetColor(string colorName)
        {
            if (Enum.TryParse(typeof(X11Colors), colorName, out var color))
                return Models.DataTypes.Color.Code((X11Colors)color);

            return Models.DataTypes.Color.Hexadecimal(colorName);
        }

        public class Step
        {
            public PointF End { get; set; }

            public bool LargeArcFlag { get; set; }

            public int Index { get; set; }
        }
    }
}

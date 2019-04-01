using System;
using DotSvg.Models.DataTypes;

namespace DotSvg.Domain.Features.Conversion
{
    public interface ISvgDataTypeConverter
    {
        string Angle(Angle angle);

        string ClockValue(TimeSpan span);
        
        string Frequency(Frequency frequency);
        
        string Length(Length length);
        
        string Number(float number);
        
        string OpacityValue(Opacity opacity);
        
        string Percentage(float number);

        string Time(Time time);

        string TransformList(TransformList transformList);
    }
}

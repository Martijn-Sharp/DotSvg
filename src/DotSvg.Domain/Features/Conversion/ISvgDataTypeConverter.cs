using DotSvg.Models.DataTypes;

namespace DotSvg.Domain.Features.Conversion
{
    public interface ISvgDataTypeConverter
    {
        string Angle(Angle angle);

        string Anything(object anything);

        string ClockValue();

        string Frequency(Frequency frequency);
        
        string Integer(int integer);

        string Length(Length length);

        string Name(Name name);
        
        string Number(float number);
        
        string OpacityValue(Opacity opacity);
        
        string Paint(Paint paint);

        string Percentage(float number);

        string Time(Time time);

        string TransformList(TransformList transformList);
    }
}

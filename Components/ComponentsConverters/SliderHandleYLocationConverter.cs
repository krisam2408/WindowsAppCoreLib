using Aide;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace WindowsAppCoreLib.Components.ComponentsConverters;

internal class SliderHandleYLocationConverter : IMultiValueConverter
{
    private readonly double m_startPosition = -HorizontalSlider.SliderHandleSide * 0.24;

    public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
    {
        if (values[0] is not Point value)
            return Binding.DoNothing;

        if (values[1] is not Point minValue)
            return Binding.DoNothing;

        if (values[2] is not Point maxValue)
            return Binding.DoNothing;

        if (values[3] is not double height)
            return Binding.DoNothing;

        double endPosition = height - HorizontalSlider.SliderHandleSide * 0.741;

        double t = Easings.LerpTValue(minValue.Y, maxValue.Y, value.Y);
        double y = Easings.Lerp(m_startPosition, endPosition, t);

        if (double.TryParse(parameter.ToString(), out double offset))
            return y + offset;

        return y;
    }

    public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }
}

using System.Windows.Data;
using System.Windows.Media;
using System.Globalization;

namespace WindowsAppCoreLib.Converter;

[ValueConversion(typeof(Color), typeof(SolidColorBrush))]
public sealed class ColorToBrush : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        if(value is not Color color)
            return Binding.DoNothing;

        return new SolidColorBrush(color);
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        if(value is not SolidColorBrush brush)
            return Binding.DoNothing;

        return brush.Color;
    }
}

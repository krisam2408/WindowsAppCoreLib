using System.Globalization;
using System.Windows.Data;
using System.Windows.Media;

namespace WindowsAppCoreLib.Converter;

[ValueConversion(typeof(SolidColorBrush), typeof(SolidColorBrush))]
public sealed class SolidColorAlpha : IValueConverter
{
    private byte? m_originalAlpha;

    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        if(value is not SolidColorBrush brush) 
            return Binding.DoNothing;

        if(CheckParameter(parameter, out byte arg))
            return Binding.DoNothing;

        Color color = brush.Color;
        m_originalAlpha = color.A;

        color.A = arg;

        return new SolidColorBrush(color);
    }

    private static bool CheckParameter(object parameter, out byte b)
    {
        b = 0;
        if (parameter is not string str)
            return true;

        if(byte.TryParse(str, out b))
            return false;

        return true;
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        if (value is not SolidColorBrush brush)
            return Binding.DoNothing;

        if (m_originalAlpha is null)
            m_originalAlpha = 255;

        Color color = brush.Color;
        color.A = (byte)m_originalAlpha;

        return new SolidColorBrush(color);
    }
}

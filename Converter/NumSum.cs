using System.Globalization;
using System.Windows.Data;

namespace WindowsAppCoreLib.Converter;

public sealed class NumSum : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        if (value is not double v)
            return Binding.DoNothing;

        if(parameter is not double s)
        {
            if (parameter is not string str)
                return Binding.DoNothing;

            if (!double.TryParse(str, out s))
                return Binding.DoNothing;
        }

        return v + s;
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        if (value is not double v)
            return Binding.DoNothing;

        if (parameter is not double s)
        {
            if (parameter is not string str)
                return Binding.DoNothing;

            if (!double.TryParse(str, out s))
                return Binding.DoNothing;
        }

        return v - s;
    }
}

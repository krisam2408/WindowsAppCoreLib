using System.Globalization;
using System.Windows.Data;

namespace WindowsAppCoreLib.Converter;

public sealed class DefaultValue : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        if (value is not null)
            return value;

        if (parameter is null)
            return Binding.DoNothing;

        return parameter;
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        return Binding.DoNothing;
    }
}

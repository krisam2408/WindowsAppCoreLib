using System.Globalization;
using System.Windows.Data;

namespace WindowsAppCoreLib.Converter;

[ValueConversion(typeof(int), typeof(object))]
public sealed class IntToOption : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        if (value is not int i)
            return Binding.DoNothing;

        if (parameter is not Array array)
            return Binding.DoNothing;

        if (array.Length == 0)
            return Binding.DoNothing;

        object? v = array.GetValue(i);

        if (v is null)
            return Binding.DoNothing;

        return v;
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        return Binding.DoNothing;
    }
}

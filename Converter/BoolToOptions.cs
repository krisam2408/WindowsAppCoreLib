using System.Globalization;
using System.Windows.Data;

namespace WindowsAppCoreLib.Converter;

[ValueConversion(typeof(bool), typeof(object))]
public sealed class BoolToOptions : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        if(value is not bool b)
            return Binding.DoNothing;

        if(parameter is not Array array)
            return Binding.DoNothing;

        if(array.Length != 2)
            return Binding.DoNothing;

        object? handleArray()
        {
            if(b)
                return array.GetValue(0);
            return array.GetValue(1);
        }
        
        object? v = handleArray();

        if(v is null)
            return Binding.DoNothing;

        return v;
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        return Binding.DoNothing;
    }
}

using System.Globalization;
using System.Windows.Data;
using System.Windows.Media;

namespace WindowsAppCoreLib.Converter;

[ValueConversion(typeof(string), typeof(ImageSource))]
public sealed class StringToImage : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
        string str = (string)value;

        return null;
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        return Binding.DoNothing;
    }
}

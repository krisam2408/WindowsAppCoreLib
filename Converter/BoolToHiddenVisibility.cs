using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace WindowsAppCoreLib.Converter
{
    [ValueConversion(typeof(bool), typeof(Visibility))]
    public sealed class BoolToHiddenVisibility : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            bool b = (bool)value;
            if(b)
                return Visibility.Visible;
            return Visibility.Hidden;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            Visibility v = (Visibility)value;

            if (v == Visibility.Visible)
                return true;

            return false;
        }
    }
}

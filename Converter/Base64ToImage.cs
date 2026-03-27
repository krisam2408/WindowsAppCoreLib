using System.Globalization;
using System.IO;
using System.Windows.Data;
using System.Windows.Media.Imaging;

namespace WindowsAppCoreLib.Converter;

public sealed class Base64ToImage : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        if(value is not string base64)
            return Binding.DoNothing;

        if(string.IsNullOrWhiteSpace(base64)) 
            return Binding.DoNothing;

        byte[] image = System.Convert.FromBase64String(base64);

        using (MemoryStream ms = new(image))
        {
            return BitmapFrame.Create(ms, BitmapCreateOptions.None, BitmapCacheOption.OnLoad);
        }
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        return Binding.DoNothing;
    }
}

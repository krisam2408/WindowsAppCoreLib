using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace WindowsAppCoreLib.Converter;

public sealed class PointX : IValueConverter
{
    private static bool IsNum(string str, out double num)
    {
        bool isNum = double.TryParse(str, out num);

        if (!isNum)
        {
            if (!int.TryParse(str, out int i))
            {
                num = 0;
                return false;
            }

            num = i;
            isNum = true;
        }

        return isNum;
    }

    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        if(value is null)
            return Binding.DoNothing;

        string? valueStr = value.ToString();
        if(string.IsNullOrWhiteSpace(valueStr))
            return Binding.DoNothing;

        if(!IsNum(valueStr, out double num))
            return Binding.DoNothing;

        string paramStr = (string)parameter;
        IsNum(paramStr, out double p);

        return new Point(num, p);
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        if(value is not Point point)
            return Binding.DoNothing;
        return point.X;
    }
}

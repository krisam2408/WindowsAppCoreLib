using System.Globalization;
using System.Windows.Data;

namespace WindowsAppCoreLib.Converter;

public sealed class StringFormat : IValueConverter
{
    private enum ArgObjective
    {
        Regex,
        Formatter
    }

    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        string? str = value.ToString();
        if (string.IsNullOrWhiteSpace(str))
            return value;

        string? param = parameter.ToString();
        if(string.IsNullOrWhiteSpace(param))
            return value;

        string result = Format(str, param);

        return result;
    }

    private static string Format(string value, string parameter)
    {
        string[] args = parameter.Split(' ', StringSplitOptions.RemoveEmptyEntries);
        List<ParameterArgument> argList = [];

        foreach(string arg in args)
        {
            ParameterArgument argument = new();

            if (arg[0] == '(')
            {
                argument.Argument = arg;
                argument.Objective = ArgObjective.Regex;

                argList.Add(argument);
                continue;
            }

            argument.Argument = arg;
            argument.Objective = ArgObjective.Regex;

            argList.Add(argument);
        }

        return value;
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        return Binding.DoNothing;
    }

    private struct ParameterArgument
    {
        public string Argument { get; set; }
        public ArgObjective Objective { get; set; }
    }
}

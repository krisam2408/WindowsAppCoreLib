using System.Windows;

namespace WindowsAppCoreLib.DataTransfer;

public sealed class TitleBarDragActionArgs
{
    public Window Window { get; set; }
    public string Name { get; set; }
    public double X { get; set; }
    public double Y { get; set; }

    public TitleBarDragActionArgs(Window window)
    {
        Window = window;
        X = window.Left;
        Y = window.Top;

        Name = window
            .GetType()
            .Name;
    }
}

using System.Windows;

namespace WindowsAppCoreLib.DataTransfer;

internal sealed class HandleTransform
{
    public bool IsDragging { get; set; } = false;
    public Point StartPoint { get; set; }
    public Point CurrentPoint { get; set; }

    public double XDelta => CurrentPoint.X - StartPoint.X;
    public double YDelta => CurrentPoint.Y - StartPoint.Y;
}

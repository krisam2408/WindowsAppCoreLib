using System.Diagnostics;
using System.Windows;
using System.Windows.Media;

namespace WindowsAppCoreLib.DataTransfer;

public sealed class CrossRadialStop
{
    public double Degrees { get; set; }
    public double Radius { get; set; }
    public Color Start { get; set; }
    public Color Main { get; set; }
    public Color End { get; set; }

    private Point? m_position = null;

    public Point Position 
    {
        get
        {
            if(m_position is null)
            {
                double angle = Degrees * Math.PI / 180.0;
                double x = Radius * Math.Sin(angle);
                double y = Radius * Math.Cos(angle);
                //Debug.WriteLine($"deg: {Degrees}, x: {x}, y: {y}");
                m_position = new(x, y);
            }

            return m_position.Value;
        }
    }
}

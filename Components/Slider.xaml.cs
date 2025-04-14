using Aide;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WindowsAppCoreLib.Components
{
    /// <summary>
    /// Interaction logic for Slider.xaml
    /// </summary>
    public partial class Slider : UserControl
    {
        private const double m_handleSide = 24;
        private bool m_isDragging;

        private const double m_positionXStart = -m_handleSide * 0.2;
        private double[] XPositionEnds => [m_positionXStart, BarWidth - m_handleSide * 0.8];

        private const double m_positionYStart = -m_handleSide * 0.24;
        private double[] YPositionEnds => [m_positionYStart, BarHeight - (m_handleSide * 0.741)];

        public Slider()
        {
            InitializeComponent();
            UpdateHandlePosition(Value);
        }

        public ICommand DragCommand => new DelegateCommand(Drag);

        private void Drag(object? e)
        {
            if (e is not MouseEventArgs ev)
                return;

            if (ev.LeftButton != MouseButtonState.Pressed)
            {
                m_isDragging = false;
                ShowTooltip = false;
                System.Windows.Input.Mouse.Capture(null);
                return;
            }

            if (ev.Source is not Border border)
                return;

            if (!m_isDragging)
            {
                ShowTooltip = true;
                m_isDragging = true;
                System.Windows.Input.Mouse.Capture(border);
            }

            if (m_isDragging)
            {
                Point currentPosition = ev.GetPosition(border);
                UpdateValue(currentPosition);
            }
        }

        public readonly static DependencyProperty MinValueProperty = DependencyProperty.Register("MinValue", typeof(Point), typeof(Slider));
        public Point MinValue
        {
            get => (Point)GetValue(MinValueProperty);
            set => SetValue(MinValueProperty, value);
        }

        public readonly static DependencyProperty MaxValueProperty = DependencyProperty.Register("MaxValue", typeof(Point), typeof(Slider));
        public Point MaxValue
        {
            get => (Point)GetValue(MaxValueProperty);
            set => SetValue(MaxValueProperty, value);
        }

        public int Decimals { get; set; }

        public readonly static DependencyProperty ValueProperty = DependencyProperty.Register("Value", typeof(Point), typeof(Slider));
        public Point Value
        {
            get
            {
                Point point = (Point)GetValue(ValueProperty);
                return point;
            }
            set
            {
                if (value == (Point)GetValue(ValueProperty))
                    return;

                double x = System.Math.Round(value.X, Decimals);
                double y = System.Math.Round(value.Y, Decimals);

                value = new(x, y);
                UpdateHandlePosition(value);
                SetValue(ValueProperty, value);
            }
        }

        private void UpdateHandlePosition(Point value)
        {
            double x = Aide.Math.LerpValue(MinValue.X, MaxValue.X, value.X);
            x = Aide.Math.Lerp(XPositionEnds[0], XPositionEnds[1], x);

            double y = Aide.Math.LerpValue(MinValue.Y, MaxValue.Y, value.Y);
            y = Aide.Math.Lerp(YPositionEnds[0], YPositionEnds[1], y);

            HandlePosition = new(x, y);
        }

        private void UpdateValue(Point value)
        {
            double x = HandlePosition.X + value.X;
            x = x.Clamp(XPositionEnds[0], XPositionEnds[1]);
            double hx = Aide.Math.LerpValue(XPositionEnds[0], XPositionEnds[1], x);
            hx = Aide.Math.Lerp(MinValue.X, MaxValue.X, hx);
            
            double y = HandlePosition.Y + value.Y;
            y = x.Clamp(YPositionEnds[0], YPositionEnds[1]);
            double hy = Aide.Math.LerpValue(YPositionEnds[0], YPositionEnds[1], y);
            hy = Aide.Math.Lerp(MinValue.Y, MaxValue.Y, hy);

            HandlePosition = new(x, y);
            Value = new(hx, hy);
        }

        internal readonly static DependencyProperty HandlePositionProperty = DependencyProperty.Register("HandlePosition", typeof(Point), typeof(Slider));
        internal Point HandlePosition 
        { 
            get => (Point)GetValue(HandlePositionProperty);
            set => SetValue(HandlePositionProperty, value);
        }

        internal readonly static DependencyProperty ShowTooltipProperty = DependencyProperty.Register("ShowTooltip", typeof(bool), typeof(Slider));
        internal bool ShowTooltip
        {
            get => (bool)GetValue(ShowTooltipProperty);
            set => SetValue(ShowTooltipProperty, value);
        }

        public readonly static DependencyProperty BarHeightProperty = DependencyProperty.Register("BarHeight", typeof(double), typeof(Slider), new PropertyMetadata(12.0));
        public double BarHeight
        {
            get => (double)GetValue(BarHeightProperty);
            set => SetValue(BarHeightProperty, value);
        }

        public readonly static DependencyProperty BarWidthProperty = DependencyProperty.Register("BarWidth", typeof(double), typeof(Slider), new PropertyMetadata(255.0));
        public double BarWidth
        {
            get => (double)GetValue(BarWidthProperty);
            set => SetValue(BarWidthProperty, value);
        }

        public readonly static DependencyProperty BarCornerRadiusProperty = DependencyProperty.Register("BarCornerRadius", typeof(CornerRadius), typeof(Slider), new PropertyMetadata(new CornerRadius(0)));
        public CornerRadius BarCornerRadius
        {
            get => (CornerRadius)GetValue(BarWidthProperty);
            set => SetValue(BarWidthProperty, value);
        }

        public readonly static DependencyProperty BarBrushProperty = DependencyProperty.Register("BarBrush", typeof(Brush), typeof(Slider), new PropertyMetadata(new SolidColorBrush(Colors.White)));
        public Brush BarBrush
        {
            get => (Brush)GetValue(BarBrushProperty);
            set => SetValue(BarBrushProperty, value);
        }
    }
}

using Aide;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Globalization;
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
using WindowsAppCoreLib.DataTransfer;

namespace WindowsAppCoreLib.Components
{
    /// <summary>
    /// Interaction logic for Slider.xaml
    /// </summary>
    public partial class HorizontalSlider : UserControl
    {
        internal const double SliderHandleSide = 24;
        private double[] m_barPoints =>
        [
            -SliderHandleSide * 0.2,
            BarWidth - SliderHandleSide * 0.8
        ];


        private bool m_isDragging;

        public HorizontalSlider()
        {
            InitializeComponent();
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
                UpdateValue(currentPosition.X);
            }
        }

        public readonly static DependencyProperty MinValueProperty = DependencyProperty.Register("MinValue", typeof(double), typeof(HorizontalSlider));
        public double MinValue
        {
            get => (double)GetValue(MinValueProperty);
            set => SetValue(MinValueProperty, value);
        }

        public readonly static DependencyProperty MaxValueProperty = DependencyProperty.Register("MaxValue", typeof(double), typeof(HorizontalSlider));
        public double MaxValue
        {
            get => (double)GetValue(MaxValueProperty);
            set => SetValue(MaxValueProperty, value);
        }

        public int Decimals { get; set; }

        public readonly static DependencyProperty ValueProperty = DependencyProperty.Register("Value", typeof(double), typeof(HorizontalSlider));
        public double Value
        {
            get => (double)GetValue(ValueProperty);
            set
            {
                double v = System.Math.Round(value, Decimals);
                v = v.Clamp(MinValue, MaxValue);
                SetValue(ValueProperty, v);
            }
        }

        private void UpdateValue(double value)
        {
            double v = Easings.LerpTValue(m_barPoints[0], m_barPoints[1], value);
            double x = Easings.Lerp(MinValue, MaxValue, v);
            Value = x;
        }

        internal readonly static DependencyProperty ShowTooltipProperty = DependencyProperty.Register("ShowTooltip", typeof(bool), typeof(HorizontalSlider));
        internal bool ShowTooltip
        {
            get => (bool)GetValue(ShowTooltipProperty);
            set => SetValue(ShowTooltipProperty, value);
        }

        public readonly static DependencyProperty BarHeightProperty = DependencyProperty.Register("BarHeight", typeof(double), typeof(HorizontalSlider), new PropertyMetadata(12.0));
        public double BarHeight
        {
            get => (double)GetValue(BarHeightProperty);
            set => SetValue(BarHeightProperty, value);
        }

        public readonly static DependencyProperty BarWidthProperty = DependencyProperty.Register("BarWidth", typeof(double), typeof(HorizontalSlider), new PropertyMetadata(255.0));
        public double BarWidth
        {
            get => (double)GetValue(BarWidthProperty);
            set => SetValue(BarWidthProperty, value);
        }

        public readonly static DependencyProperty BarCornerRadiusProperty = DependencyProperty.Register("BarCornerRadius", typeof(CornerRadius), typeof(HorizontalSlider), new PropertyMetadata(new CornerRadius(0)));
        public CornerRadius BarCornerRadius
        {
            get => (CornerRadius)GetValue(BarWidthProperty);
            set => SetValue(BarWidthProperty, value);
        }

        public readonly static DependencyProperty BarBrushProperty = DependencyProperty.Register("BarBrush", typeof(Brush), typeof(HorizontalSlider), new PropertyMetadata(new SolidColorBrush(Colors.White)));
        public Brush BarBrush
        {
            get => (Brush)GetValue(BarBrushProperty);
            set => SetValue(BarBrushProperty, value);
        }
    }

    internal class SliderHandleXLocationConverter : IMultiValueConverter
    {
        private readonly double m_startPosition = -HorizontalSlider.SliderHandleSide * 0.2;

        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            if (values[0] is not double value)
                return Binding.DoNothing;

            if (values[1] is not double minValue)
                return Binding.DoNothing;

            if (values[2] is not double maxValue)
                return Binding.DoNothing;

            if (values[3] is not double width)
                return Binding.DoNothing;

            double endPosition = width - HorizontalSlider.SliderHandleSide * 0.8;

            double t = Easings.LerpTValue(minValue, maxValue, value);
            double x = Easings.Lerp(m_startPosition, endPosition, t);

            Debug.WriteLine($"!!!! x:{x}, ");
            return x;
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}

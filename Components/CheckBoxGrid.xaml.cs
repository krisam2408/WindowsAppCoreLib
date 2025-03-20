using System;
using System.Collections.Generic;
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
    /// Interaction logic for CheckBoxGrid.xaml
    /// </summary>
    public partial class CheckBoxGrid : UserControl
    {
        private const double m_checkWidth = 48;
        public static GridLength CheckWidth => new(m_checkWidth);
        public static GridLength ZeroWidth => new(0);

        public ICommand ToggleValueCommand => new DelegateCommand(ToggleValue);

        public CheckBoxGrid()
        {
            InitializeComponent();
        }

        public static readonly DependencyProperty ContentWidthProperty = DependencyProperty.Register("ContentWidth", typeof(GridLength), typeof(CheckBoxGrid));

        public GridLength ContentWidth
        {
            get => (GridLength)GetValue(WidthProperty);
            set => SetValue(ContentWidthProperty, value);
        }

        public static readonly DependencyProperty GapProperty = DependencyProperty.Register("Gap", typeof(GridLength), typeof(CheckBoxGrid), new PropertyMetadata(ZeroWidth));

        public GridLength Gap
        {
            get => (GridLength)GetValue(GapProperty);
            set => SetValue(GapProperty, value);
        }

        public static readonly DependencyProperty TextProperty = DependencyProperty.Register("Text", typeof(string), typeof(CheckBoxGrid));

        public string Text
        {
            get => (string)GetValue(TextProperty);
            set => SetValue(TextProperty, value);
        }

        public static readonly DependencyProperty CheckerBackgroundProperty = DependencyProperty.Register("CheckerBackground", typeof(SolidColorBrush), typeof(CheckBoxGrid), new PropertyMetadata(new SolidColorBrush(Color.FromRgb(255,255,255))));

        public SolidColorBrush CheckerBackground
        {
            get => (SolidColorBrush)GetValue(CheckerBackgroundProperty);
            set => SetValue(CheckerBackgroundProperty, value);
        }

        public static readonly DependencyProperty CheckerBorderProperty = DependencyProperty.Register("CheckerBorder", typeof(SolidColorBrush), typeof(CheckBoxGrid), new PropertyMetadata(new SolidColorBrush(Color.FromRgb(180, 180, 180))));

        public SolidColorBrush CheckerBorder
        {
            get => (SolidColorBrush)GetValue(CheckerBorderProperty);
            set => SetValue(CheckerBorderProperty, value);
        }

        public static readonly DependencyProperty TickIconProperty = DependencyProperty.Register("TickIcon", typeof(string), typeof(CheckBoxGrid));

        public string TickIcon
        {
            get => (string)(GetValue(TickIconProperty));
            set => SetValue(TickIconProperty, value);
        }

        public static readonly DependencyProperty ValueProperty = DependencyProperty.Register("Value", typeof(bool), typeof(CheckBoxGrid));

        public bool Value
        {
            get => (bool)GetValue(ValueProperty);
            set => SetValue(ValueProperty, value);
        }

        private void ToggleValue(object? e)
        {
            Value = !Value;
        }
    }
}

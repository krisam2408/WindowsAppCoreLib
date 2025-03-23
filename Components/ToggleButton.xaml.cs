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
    /// Interaction logic for ToggleButton.xaml
    /// </summary>
    public partial class ToggleButton : UserControl
    {
        public ToggleButton()
        {
            InitializeComponent();
        }

        public static readonly DependencyProperty IconProperty = DependencyProperty.Register("Icon", typeof(string), typeof(ToggleButton), new PropertyMetadata(null));

        public string Icon
        {
            get => (string)GetValue(IconProperty);
            set => SetValue(IconProperty, value);
        }

        public static readonly DependencyProperty ValueProperty = DependencyProperty.Register("Value", typeof(bool), typeof(ToggleButton));

        public bool Value
        {
            get => (bool)GetValue(ValueProperty);
            set => SetValue(ValueProperty, value);
        }

        public ICommand ToggleValueCommand => new DelegateCommand((e) => Value = !Value);

        public static readonly DependencyProperty IdleProperty = DependencyProperty.Register("Idle", typeof(SolidColorBrush), typeof(ToggleButton), new PropertyMetadata(new SolidColorBrush(Color.FromArgb(0, 255, 255, 255))));

        public SolidColorBrush Idle
        {
            get => (SolidColorBrush)GetValue(IdleProperty);
            set => SetValue(IdleProperty, value);
        }

        public static readonly DependencyProperty HoverProperty = DependencyProperty.Register("Hover", typeof(SolidColorBrush), typeof(ToggleButton), new PropertyMetadata(new SolidColorBrush(Color.FromRgb(22, 25, 28))));

        public SolidColorBrush Hover
        {
            get => (SolidColorBrush)GetValue(HoverProperty);
            set => SetValue(HoverProperty, value);
        }

        public SolidColorBrush InactiveColor => new(Color.FromArgb(80, 255, 255, 255));
    }
}

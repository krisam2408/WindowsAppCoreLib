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
    /// Interaction logic for IconButton.xaml
    /// </summary>
    public partial class IconButton : UserControl
    {
        public string? Argument { get; set; }

        public IconButton()
        {
            InitializeComponent();
        }

        public static readonly DependencyProperty IconProperty = DependencyProperty.Register("Icon", typeof(string), typeof(IconButton));

        public string Icon
        {
            get => (string)GetValue(CommandProperty);
            set => SetValue(CommandProperty, value);
        }

        public static readonly DependencyProperty CommandProperty = DependencyProperty.Register("Command", typeof(ICommand), typeof(IconButton), new PropertyMetadata(null));

        public ICommand Command
        {
            get => (ICommand)GetValue(CommandProperty);
            set => SetValue(CommandProperty, value);
        }

        public static readonly DependencyProperty IdleProperty = DependencyProperty.Register("Idle", typeof(SolidColorBrush), typeof(IconButton), new PropertyMetadata(new SolidColorBrush(Color.FromArgb(0, 255, 255, 255))));

        public SolidColorBrush Idle
        {
            get => (SolidColorBrush)GetValue(IdleProperty);
            set => SetValue(IdleProperty, value);
        }

        public static readonly DependencyProperty HoverProperty = DependencyProperty.Register("Hover", typeof(SolidColorBrush), typeof(IconButton), new PropertyMetadata(new SolidColorBrush(Color.FromRgb(22, 25, 28))));

        public SolidColorBrush Hover
        {
            get => (SolidColorBrush)GetValue(HoverProperty);
            set => SetValue(HoverProperty, value);
        }

        public static bool CheckIf(MouseEventArgs ev, out IconButton? button)
        {
            button = null;
            if (ev.OriginalSource is not Image img)
                return false;

            if (img.Parent is not Border brd)
                return false;

            if (brd.Parent is IconButton btn)
            {
                button = btn;
                return true;
            }

            return false;
        }
    }
}

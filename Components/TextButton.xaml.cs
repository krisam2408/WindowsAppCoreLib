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
    /// Interaction logic for TextButton.xaml
    /// </summary>
    public partial class TextButton : UserControl
    {
        public string? Argument { get; set; }

        public TextButton()
        {
            InitializeComponent();
        }

        public static readonly DependencyProperty CommandProperty = DependencyProperty.Register("Command", typeof(ICommand), typeof(TextButton));

        public ICommand Command
        {
            get => (ICommand)GetValue(CommandProperty);
            set => SetValue(CommandProperty, value);
        }

        public static readonly DependencyProperty TextProperty = DependencyProperty.Register("Text", typeof(string), typeof(TextButton));

        public string Text
        {
            get => (string)GetValue(TextProperty);
            set => SetValue(TextProperty, value);
        }

        public static readonly DependencyProperty IdleProperty = DependencyProperty.Register("Idle", typeof(SolidColorBrush), typeof(TextButton), new PropertyMetadata(new SolidColorBrush(Color.FromArgb(0, 255, 255, 255))));

        public SolidColorBrush Idle
        {
            get => (SolidColorBrush)GetValue(IdleProperty);
            set => SetValue(IdleProperty, value);
        }

        public static readonly DependencyProperty HoverProperty = DependencyProperty.Register("Hover", typeof(SolidColorBrush), typeof(TextButton), new PropertyMetadata(new SolidColorBrush(Color.FromRgb(22, 25, 28))));

        public SolidColorBrush Hover
        {
            get => (SolidColorBrush)GetValue(HoverProperty);
            set => SetValue(HoverProperty, value);
        }

        public static readonly DependencyProperty TextAlignmentProperty = DependencyProperty.Register("TextAlignment", typeof(HorizontalAlignment), typeof(TextButton), new PropertyMetadata(HorizontalAlignment.Center));

        public HorizontalAlignment TextAlignment
        {
            get => (HorizontalAlignment)GetValue(TextAlignmentProperty);
            set => SetValue(TextAlignmentProperty, value);
        }


        public static bool CheckIf(MouseEventArgs ev, out TextButton? button)
        {
            button = null;
            if (ev.OriginalSource is not TextBlock img)
                return false;

            if (img.Parent is not Border brd)
                return false;

            if (brd.Parent is TextButton btn)
            {
                button = btn;
                return true;
            }

            return false;
        }
    }
}

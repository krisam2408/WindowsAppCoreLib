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
    /// Interaction logic for ColorPicker.xaml
    /// </summary>
    public partial class ColorPicker : UserControl
    {
        public ColorPicker()
        {
            InitializeComponent();
        }

        public readonly static DependencyProperty HueProperty = DependencyProperty.Register("Hue", typeof(double), typeof(ColorPicker));

        public double Hue
        {
            get => (double)GetValue(HueProperty);
            set
            {

                SetValue(HueProperty, value);
            }
        }
    }
}

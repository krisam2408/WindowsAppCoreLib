using Aide;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography.X509Certificates;
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
    /// Interaction logic for ColorPicker.xaml
    /// </summary>
    public partial class HSLColorWheelPicker : UserControl
    {
        public HSLColorWheelPicker()
        {
            InitializeComponent();
        }

        public readonly static DependencyProperty HueProperty = DependencyProperty.Register("Hue", typeof(double), typeof(HSLColorWheelPicker));
        public double Hue
        {
            get => (double)GetValue(HueProperty);
            set => SetValue(HueProperty, value);
        }

        public readonly static DependencyProperty AlphaProperty = DependencyProperty.Register("Alpha", typeof(double), typeof(HSLColorWheelPicker));
        public double Alpha
        {
            get => (double)GetValue(AlphaProperty);
            set => SetValue(AlphaProperty, value);
        }
    }
}

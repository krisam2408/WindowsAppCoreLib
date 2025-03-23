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
using WindowsAppCoreLib.DataTransfer;

namespace WindowsAppCoreLib.Components
{
    /// <summary>
    /// Interaction logic for TitleBar.xaml
    /// </summary>
    public partial class SimpleTitleBar : UserControl
    {
        public string Text { get; set; } = "";

        public ICommand DragWindowCommand => new DelegateCommand(DragWindow);
        public ICommand CloseWindowCommand => new DelegateCommand(CloseWindow);

        private Window? m_window = null;

        public SimpleTitleBar()
        {
            InitializeComponent();
        }

        public static readonly DependencyProperty DragActionProperty = DependencyProperty.Register("DragAction", typeof(ICommand), typeof(SimpleTitleBar), new PropertyMetadata(null));

        public ICommand DragAction
        {
            get => (ICommand)GetValue(DragActionProperty);
            set => SetValue(DragActionProperty, value);
        }

        public static readonly DependencyProperty IconProperty = DependencyProperty.Register("Icon", typeof(string), typeof(SimpleTitleBar));

        public string Icon
        {
            get => (string)GetValue(IconProperty);
            set => SetValue(IconProperty, value);
        }

        public static readonly DependencyProperty BarBackgroundProperty = DependencyProperty.Register("BarBackground", typeof(SolidColorBrush), typeof(SimpleTitleBar));

        public SolidColorBrush BarBackground
        {
            get => (SolidColorBrush)GetValue(BarBackgroundProperty);
            set => SetValue(BarBackgroundProperty, value);
        }

        private static Window? SetWindow(MouseEventArgs ev)
        {
            FrameworkElement? currentElement = (FrameworkElement)ev.OriginalSource;

            while (currentElement is not null)
            {
                currentElement = (FrameworkElement?)currentElement.Parent;

                if (currentElement is null)
                    break;

                Type currentType = currentElement.GetType();

                if (currentType.BaseType == typeof(Window))
                    return (Window)currentElement;
            }

            return null;
        }

        private void DragWindow(object? e)
        {
            if (e is not MouseEventArgs ev)
                return;

            if (m_window is null)
                m_window = SetWindow(ev);

            if (ev.LeftButton == MouseButtonState.Pressed && m_window is not null)
            {
                m_window.DragMove();
                return;
            }

            if (ev.LeftButton == MouseButtonState.Released && m_window is not null)
            {
                TitleBarDragActionArgs args = new(m_window);
                DragAction.Execute(args);
            }
        }

        private void CloseWindow(object? e)
        {
            if (e is MouseEventArgs ev)
            {
                if (m_window is null)
                    m_window = SetWindow(ev);

                if (m_window is not null)
                    m_window.Close();
            }
        }
    }
}

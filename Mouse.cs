using System.Windows.Input;
using System.Windows;

namespace WindowsAppCoreLib;

public sealed class Mouse
{
    #region Enable Triggers
    public static readonly DependencyProperty EnableTriggersProperty = DependencyProperty.RegisterAttached("EnableTriggers", typeof(bool), typeof(Mouse), new FrameworkPropertyMetadata(false, new PropertyChangedCallback(EnableTriggersChanged)));

    private static void EnableTriggersChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
    {
        FrameworkElement element = (FrameworkElement)sender;

        if ((bool)e.NewValue)
        {
            element.MouseLeftButtonDown += new MouseButtonEventHandler(IsLeftButtonDown);
            element.MouseLeftButtonUp += new MouseButtonEventHandler(IsLeftButtonUp);

            element.MouseRightButtonDown += new MouseButtonEventHandler(IsRightButtonDown);
            element.MouseRightButtonUp += new MouseButtonEventHandler(IsRightButtonUp);

            element.MouseLeave += new MouseEventHandler(IsLeftButtonUp);
            element.MouseLeave += new MouseEventHandler(IsRightButtonUp);
            return;
        }

        element.MouseLeftButtonDown -= new MouseButtonEventHandler(IsLeftButtonDown);
        element.MouseLeftButtonUp -= new MouseButtonEventHandler(IsLeftButtonUp);

        element.MouseRightButtonDown -= new MouseButtonEventHandler(IsRightButtonDown);
        element.MouseRightButtonUp -= new MouseButtonEventHandler(IsRightButtonUp);

        element.MouseLeave -= new MouseEventHandler(IsLeftButtonUp);
        element.MouseLeave -= new MouseEventHandler(IsRightButtonUp);

    }

    public static void SetEnableTriggers(UIElement element, bool value)
    {
        element.SetValue(EnableTriggersProperty, value);
    }

    public static bool GetEnableTriggers(UIElement element)
    {
        return (bool)element.GetValue(EnableTriggersProperty);
    }
    #endregion

    #region Left Mouse Button Press
    public static readonly DependencyProperty LeftPressCommandProperty = DependencyProperty.RegisterAttached("LeftPressCommand", typeof(ICommand), typeof(Mouse), new FrameworkPropertyMetadata(new PropertyChangedCallback(LeftPressCommandChanged)));

    private static void LeftPressCommandChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
    {
        FrameworkElement element = (FrameworkElement)sender;

        element.MouseLeftButtonDown += new MouseButtonEventHandler(LeftPressCommand);
    }

    private static void LeftPressCommand(object sender, MouseEventArgs e)
    {
        FrameworkElement element = (FrameworkElement)sender;

        ICommand command = GetLeftPressCommand(element);
        command.Execute(e);
    }

    public static void SetLeftPressCommand(UIElement element, ICommand command)
    {
        element.SetValue(LeftPressCommandProperty, command);
    }

    public static ICommand GetLeftPressCommand(UIElement element)
    {
        return (ICommand)element.GetValue(LeftPressCommandProperty);
    }
    #endregion

    #region Left Mouse Button Release
    public static readonly DependencyProperty LeftReleaseCommandProperty = DependencyProperty.RegisterAttached("LeftReleaseCommand", typeof(ICommand), typeof(Mouse), new FrameworkPropertyMetadata(new PropertyChangedCallback(LeftReleaseCommandChanged)));

    private static void LeftReleaseCommandChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
    {
        FrameworkElement element = (FrameworkElement)sender;

        element.MouseLeftButtonUp += new MouseButtonEventHandler(LeftReleaseCommand);
    }

    private static void LeftReleaseCommand(object sender, MouseEventArgs e)
    {
        FrameworkElement element = (FrameworkElement)sender;

        SetIsLeftButtonDown(element, false);

        ICommand command = GetLeftReleaseCommand(element);
        command.Execute(e);
    }

    public static void SetLeftReleaseCommand(UIElement element, ICommand command)
    {
        element.SetValue(LeftReleaseCommandProperty, command);
    }

    public static ICommand GetLeftReleaseCommand(UIElement element)
    {
        return (ICommand)element.GetValue(LeftReleaseCommandProperty);
    }
    #endregion

    #region Is Left Mouse Button Down
    private static readonly DependencyPropertyKey IsLeftButtonDownPropertyKey = DependencyProperty.RegisterAttachedReadOnly("IsLeftButtonDown", typeof(bool), typeof(Mouse), new FrameworkPropertyMetadata(false));
    public static readonly DependencyProperty IsLeftButtonDownProperty = IsLeftButtonDownPropertyKey.DependencyProperty;

    private static void IsLeftButtonDown(object sender, MouseEventArgs e)
    {
        FrameworkElement element = (FrameworkElement)sender;
        SetIsLeftButtonDown(element, true);
    }

    private static void IsLeftButtonUp(object sender, MouseEventArgs e)
    {
        FrameworkElement element = (FrameworkElement)sender;
        SetIsLeftButtonDown(element, false);
    }

    public static void SetIsLeftButtonDown(UIElement element, bool value)
    {
        element.SetValue(IsLeftButtonDownPropertyKey, value);
    }

    public static bool GetIsLeftButtonDown(UIElement element)
    {
        return (bool)element.GetValue(IsLeftButtonDownProperty);
    }
    #endregion

    #region Mouse Right Button Press
    public static readonly DependencyProperty RightPressCommandProperty = DependencyProperty.RegisterAttached("RightPressCommand", typeof(ICommand), typeof(Mouse), new FrameworkPropertyMetadata(new PropertyChangedCallback(RightPressCommandChanged)));
    
    private static void RightPressCommandChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
    {
        FrameworkElement element = (FrameworkElement)sender;

        element.MouseRightButtonDown += new MouseButtonEventHandler(RightPressCommand);
    }

    private static void RightPressCommand(object sender, MouseEventArgs e)
    {
        FrameworkElement element = (FrameworkElement)sender;
        ICommand command = GetRightPressCommand(element);
        command.Execute(e);
    }

    public static void SetRightPressCommand(UIElement element, ICommand command)
    {
        element.SetValue(RightPressCommandProperty, command);
    }

    public static ICommand GetRightPressCommand(UIElement element)
    {
        return (ICommand)element.GetValue(RightPressCommandProperty);
    }
    #endregion

    #region Right Mouse Button Release
    public static readonly DependencyProperty RightReleaseCommandProperty = DependencyProperty.RegisterAttached("RightReleaseCommand", typeof(ICommand), typeof(Mouse), new FrameworkPropertyMetadata(new PropertyChangedCallback(RightReleaseCommandChanged)));

    private static void RightReleaseCommandChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
    {
        FrameworkElement element = (FrameworkElement)sender;

        element.MouseRightButtonUp += new MouseButtonEventHandler(RightReleaseCommand);
    }

    private static void RightReleaseCommand(object sender, MouseEventArgs e)
    {
        FrameworkElement element = (FrameworkElement)sender;
        ICommand command = GetRightReleaseCommand(element);
        command.Execute(e);
    }

    public static void SetRightReleaseCommand(UIElement element, ICommand command)
    {
        element.SetValue(RightReleaseCommandProperty, command);
    }

    public static ICommand GetRightReleaseCommand(UIElement element)
    {
        return (ICommand)element.GetValue(RightReleaseCommandProperty);
    }
    #endregion

    #region Is Right Mouse Button Down
    private static readonly DependencyPropertyKey IsRightButtonDownPropertyKey = DependencyProperty.RegisterAttachedReadOnly("IsRightButtonDown", typeof(bool), typeof(Mouse), new FrameworkPropertyMetadata(false));
    public static readonly DependencyProperty IsRightButtonDownProperty = IsRightButtonDownPropertyKey.DependencyProperty;

    private static void IsRightButtonDown(object sender, MouseEventArgs e)
    {
        FrameworkElement element = (FrameworkElement)sender;
        SetIsRightButtonDown(element, true);
    }

    private static void IsRightButtonUp(object sender, MouseEventArgs e)
    {
        FrameworkElement element = (FrameworkElement)sender;
        SetIsRightButtonDown(element, false);
    }

    public static void SetIsRightButtonDown(UIElement element, bool value)
    {
        element.SetValue(IsRightButtonDownPropertyKey, value);
    }

    public static bool GetIsRightButtonDown(UIElement element)
    {
        return (bool)element.GetValue(IsRightButtonDownProperty);
    }
    #endregion

    #region Mouse Drag
    public static readonly DependencyProperty DragCommandProperty = DependencyProperty.RegisterAttached("DragCommand", typeof(ICommand), typeof(Mouse), new FrameworkPropertyMetadata(new PropertyChangedCallback(DragCommandChanged)));

    private static void DragCommandChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
    {
        FrameworkElement element = (FrameworkElement)sender;

        element.MouseMove += new MouseEventHandler(DragCommand);
    }

    private static void DragCommand(object sender, MouseEventArgs e)
    {
        FrameworkElement element = (FrameworkElement)sender;
        ICommand command = GetDragCommand(element);
        command.Execute(e);
    }

    public static void SetDragCommand(UIElement element, ICommand command)
    {
        element.SetValue(DragCommandProperty, command);
    }

    public static ICommand GetDragCommand(UIElement element)
    {
        return (ICommand)element.GetValue(DragCommandProperty);
    }
    #endregion

    #region Mouse Enter
    public static readonly DependencyProperty EnterCommandProperty = DependencyProperty.RegisterAttached("EnterCommand", typeof(ICommand), typeof(Mouse), new FrameworkPropertyMetadata(new PropertyChangedCallback(EnterCommandChanged)));

    private static void EnterCommandChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
    {
        FrameworkElement element = (FrameworkElement)sender;

        element.MouseEnter += new MouseEventHandler(EnterCommand);
    }

    private static void EnterCommand(object sender, MouseEventArgs e)
    {
        FrameworkElement element = (FrameworkElement)sender;
        ICommand command = GetEnterCommand(element);
        command.Execute(e);
    }

    public static void SetEnterCommand(UIElement element, ICommand command)
    {
        element.SetValue(EnterCommandProperty, command);
    }

    public static ICommand GetEnterCommand(UIElement element)
    {
        return (ICommand)element.GetValue(EnterCommandProperty);
    }
    #endregion

    #region Mouse Leave
    public static readonly DependencyProperty LeaveCommandProperty = DependencyProperty.RegisterAttached("LeaveCommand", typeof(ICommand), typeof(Mouse), new FrameworkPropertyMetadata(new PropertyChangedCallback(LeaveCommandChanged)));

    private static void LeaveCommandChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
    {
        FrameworkElement element = (FrameworkElement)sender;

        element.MouseLeave += new MouseEventHandler(LeaveCommand);
    }

    private static void LeaveCommand(object sender, MouseEventArgs e)
    {
        FrameworkElement element = (FrameworkElement)sender;
        ICommand command = GetLeaveCommand(element);
        command.Execute(e);
    }

    public static void SetLeaveCommand(UIElement element, ICommand command)
    {
        element.SetValue(LeaveCommandProperty, command);
    }

    public static ICommand GetLeaveCommand(UIElement element)
    {
        return (ICommand)element.GetValue(LeaveCommandProperty);
    }
    #endregion
}

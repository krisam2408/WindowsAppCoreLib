namespace WindowsAppCoreLib;

public class BaseViewModel : IObservableModel
{
    private bool m_enabled;
    public bool Enabled { get => m_enabled; set => SetValue(ref m_enabled, value); }

    protected BaseViewModel() { }
}

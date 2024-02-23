namespace Sniffer;

public partial class App : Application
{
    public App()
    {
        InitializeComponent();
        
        MainPage = new NavigationPage(new AppShell());
        MainPage = new AppShell();
    }
    
#if WINDOWS
    protected override Window CreateWindow(IActivationState activationState) {
        var window = base.CreateWindow(activationState);

        window.Title = AppInfo.Current.Name;
        return window;
    }
#endif
}
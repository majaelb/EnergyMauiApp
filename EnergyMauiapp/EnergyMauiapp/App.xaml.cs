namespace EnergyMauiapp;

public partial class App : Application
{
    public App()
    {
        InitializeComponent();

        MainPage = new AppShell();
    }

    //Sätter fönstret till en fast max-storlek
    protected override Window CreateWindow(IActivationState activationState)
    {
        var window = base.CreateWindow(activationState);

        const int newWidth = 900;
        const int newHeight = 1050;

        window.MaximumHeight = newHeight;
        window.MaximumHeight = newHeight;

        window.MaximumWidth = newWidth;
        window.MaximumWidth = newWidth;

        return window;
    }
}


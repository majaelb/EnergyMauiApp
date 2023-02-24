namespace EnergyMauiapp.Views;

public partial class SelfEstimationPage : ContentPage
{

    public SelfEstimationPage()
    {
        InitializeComponent();
    }

    private async void OnNewSelfEstBtnClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new MakeNewSelfEstimationPage());
    }

    private async void OnPrevSelfEstBtnClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new PreviousSelfEstimationsPage());
    }

    private async void OnBackClicked(object sender, EventArgs e)
    {
        await Navigation.PopAsync();
    }

   
}
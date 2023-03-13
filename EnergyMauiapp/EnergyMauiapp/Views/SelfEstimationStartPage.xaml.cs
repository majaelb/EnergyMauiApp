using EnergyMauiapp.ViewModels;

namespace EnergyMauiapp.Views;

public partial class SelfEstimationPage : ContentPage
{
    SelfEstimationViewModel vm = new();

    public SelfEstimationPage()
    {
        InitializeComponent();
        BindingContext = vm;
    }

    private async void OnNewSelfEstBtnClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new MakeNewSelfEstimationPage());
        //await Navigation.PushAsync(new NewSelfEstPage());

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
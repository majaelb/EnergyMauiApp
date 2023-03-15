using EnergyMauiapp.Helpers;
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
        string fileName = "testmedsystem.txt";
        bool existingFile = FileManager.FindExistingFile(fileName);
        if (existingFile)
            await Navigation.PushAsync(new PreviousSelfEstimationsPage());
        else
            await DisplayAlert("Error", "Det finns inga skattningar att visa", "OK");
    }

    private async void OnBackClicked(object sender, EventArgs e)
    {
        await Navigation.PopAsync();
    }

   
}
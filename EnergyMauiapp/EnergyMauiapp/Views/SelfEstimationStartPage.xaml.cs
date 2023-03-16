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
    }

    private async void OnPrevSelfEstBtnClicked(object sender, EventArgs e)
    {
        string fileName = "minaSkattningsResultat.txt";
        bool existingFile = FileManager.FindExistingFile(fileName);
        if (existingFile)
            await Navigation.PushAsync(new PreviousSelfEstimationsPage());
        else
            await DisplayAlert("Error", "Det finns inga skattningar att visa", "OK");
        //Ser till att man inte kommer in på sidan om filen inte finns/inga skattningar finns sparade
    }

    private async void OnBackClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new MainPage());
    }

   
}
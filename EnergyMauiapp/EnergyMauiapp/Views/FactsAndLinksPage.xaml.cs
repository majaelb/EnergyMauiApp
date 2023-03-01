using System.Windows.Input;

namespace EnergyMauiapp.Views;

public partial class FactsAndLinksPage : ContentPage
{
    //TODO: Label med tapcommand f�r l�nk
    ViewModels.FactsAndLinksPageViewModel vm = new();

    public FactsAndLinksPage()
    {
        InitializeComponent();
        BindingContext = vm;
    }


    private async void OnBackClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new MainPage()); //TODO: Pusha ny sida f�r att ladda nya tips?
    }
}
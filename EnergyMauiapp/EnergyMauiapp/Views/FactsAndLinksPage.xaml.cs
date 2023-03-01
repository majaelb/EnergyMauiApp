using System.Windows.Input;

namespace EnergyMauiapp.Views;

public partial class FactsAndLinksPage : ContentPage
{
    //TODO: Label med tapcommand för länk
    ViewModels.FactsAndLinksPageViewModel vm = new();

    public FactsAndLinksPage()
    {
        InitializeComponent();
        BindingContext = vm;
    }


    private async void OnBackClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new MainPage()); //TODO: Pusha ny sida för att ladda nya tips?
    }
}
using System.Windows.Input;

namespace EnergyMauiapp.Views;

public partial class FactsAndLinksPage : ContentPage
{
    ViewModels.FactsAndLinksPageViewModel vm = new();

    public FactsAndLinksPage()
    {
        InitializeComponent();
        BindingContext = vm;
    }


    private async void OnBackClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new MainPage()); 
    }
}
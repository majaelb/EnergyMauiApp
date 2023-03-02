using static System.Net.Mime.MediaTypeNames;
using System.Text.Json;
using EnergyMauiapp.Views;

namespace EnergyMauiapp.Views;

public partial class PreviousSelfEstimationsPage : ContentPage
{
    ViewModels.PreviousSelfEstimationPageViewModel vm = new();
	public PreviousSelfEstimationsPage()
	{
		InitializeComponent();
        BindingContext = vm;
        
        None.Text = "Inga problem (0-10)";
        Low.Text = "Mild mental trötthet (10,5-14,5)";
        Middle.Text = "Måttlig mental trötthet (15-20)";
        High.Text = "Svår mental trötthet (20,5 & högre)";
        //TODO: Koppla resultatens färg till resultat?
        //TODO: Lägg till ta bort-knapp på resultaten
    }

    private async void OnBackClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new MainPage());
    }
}
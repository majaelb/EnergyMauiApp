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
        Low.Text = "Mild mental tr�tthet (10,5-14,5)";
        Middle.Text = "M�ttlig mental tr�tthet (15-20)";
        High.Text = "Sv�r mental tr�tthet (20,5 & h�gre)";
        //TODO: Koppla resultatens f�rg till resultat?
        //TODO: L�gg till ta bort-knapp p� resultaten
    }

    private async void OnBackClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new MainPage());
    }
}
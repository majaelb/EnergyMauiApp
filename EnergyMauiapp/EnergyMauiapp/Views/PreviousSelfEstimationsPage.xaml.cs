using static System.Net.Mime.MediaTypeNames;
using System.Text.Json;

namespace EnergyMauiapp.Views;

public partial class PreviousSelfEstimationsPage : ContentPage
{
	public PreviousSelfEstimationsPage()
	{
		InitializeComponent();
        BindingContext = new ViewModels.PreviousSelfEstimationPageViewModel();
        
        None.Text = "Inga problem (0-10)";
        Low.Text = "Mild mental tr�tthet (10,5-14,5)";
        Middle.Text = "M�ttlig mental tr�tthet (15-20)";
        High.Text = "Sv�r mental tr�tthet (20,5 & h�gre)";
    }

    private async void OnBackClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new MainPage());
    }
}
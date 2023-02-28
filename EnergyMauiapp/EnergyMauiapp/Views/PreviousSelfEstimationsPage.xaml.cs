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
        Low.Text = "Mild mental trötthet (10,5-14,5)";
        Middle.Text = "Måttlig mental trötthet (15-20)";
        High.Text = "Svår mental trötthet (20,5 & högre)";
    }

    private async void OnBackClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new MainPage());
    }
}
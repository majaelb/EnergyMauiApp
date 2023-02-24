namespace EnergyMauiapp.Views;

public partial class PreviousSelfEstimationsPage : ContentPage
{
	public PreviousSelfEstimationsPage()
	{
		InitializeComponent();
	}

    private async void OnBackClicked(object sender, EventArgs e)
    {
        await Navigation.PopAsync();
    }
}
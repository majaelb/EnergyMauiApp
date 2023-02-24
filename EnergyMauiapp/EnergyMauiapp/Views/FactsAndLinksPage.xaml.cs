namespace EnergyMauiapp.Views;

public partial class FactsAndLinksPage : ContentPage
{
	public FactsAndLinksPage()
	{
		InitializeComponent();
	}
    private async void OnBackClicked(object sender, EventArgs e)
    {
        await Navigation.PopAsync();
    }
}
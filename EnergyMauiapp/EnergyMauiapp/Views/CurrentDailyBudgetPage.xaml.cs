namespace EnergyMauiapp.Views;

public partial class CurrentDailyBudgetPage : ContentPage
{
	public CurrentDailyBudgetPage()
	{
		InitializeComponent();
	}
    private async void OnBackClicked(object sender, EventArgs e)
    {
        await Navigation.PopAsync();
    }
}
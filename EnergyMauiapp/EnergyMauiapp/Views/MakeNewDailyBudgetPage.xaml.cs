namespace EnergyMauiapp.Views;

public partial class MakeNewDailyBudgetPage : ContentPage
{
	public MakeNewDailyBudgetPage()
	{
		InitializeComponent();
	}

    private async void OnBackClicked(object sender, EventArgs e)
    {
        await Navigation.PopAsync();
    }
}
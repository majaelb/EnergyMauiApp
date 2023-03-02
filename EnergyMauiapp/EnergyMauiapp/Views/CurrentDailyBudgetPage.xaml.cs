using EnergyMauiapp.ViewModels;


namespace EnergyMauiapp.Views;

public partial class CurrentDailyBudgetPage : ContentPage
{
    CurrentDailyBudgetPageViewModel vm = new();
	public CurrentDailyBudgetPage()
	{
		InitializeComponent();
        BindingContext = vm;
	}
    private async void OnBackClicked(object sender, EventArgs e)
    {
        await Navigation.PopAsync();
    }
}
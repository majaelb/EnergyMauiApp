using EnergyMauiapp.ViewModels;
using EnergyMauiapp.Models;

namespace EnergyMauiapp.Views;

public partial class MakeNewDailyBudgetPage : ContentPage
{
    MakeNewDailyBudgetPageViewModel vm = new();
	public MakeNewDailyBudgetPage()
	{
		InitializeComponent();
        BindingContext = vm;
	}

    private async void OnBackClicked(object sender, EventArgs e)
    {
        User.MyBudget = 0;
        await Navigation.PopAsync();
    }
}
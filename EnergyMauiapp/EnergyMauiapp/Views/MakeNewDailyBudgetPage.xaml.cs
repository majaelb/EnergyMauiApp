using EnergyMauiapp.ViewModels;
using EnergyMauiapp.Models;

namespace EnergyMauiapp.Views;

public partial class MakeNewDailyBudgetPage : ContentPage
{
    MakeNewDailyBudgetPageViewModel vm = new();

    static UserSingleton user = UserSingleton.GetUserSessionData();

    public MakeNewDailyBudgetPage()
	{
		InitializeComponent();
        BindingContext = vm;
	}

    private async void OnSaveBtnClicked(object sender, EventArgs e)
    {
        await DisplayAlert("Klart!", "Din nya dagsbudget är sparad", "Ok");
        await Navigation.PopAsync();
        user.MyBudget = 0; //Använder singleton-instansen, nollställer budgeträknaren när man lämnar sidan
    }

    private async void OnBackClicked(object sender, EventArgs e)
    {
        user.MyBudget = 0; //Använder singleton-instansen, nollställer budgeträknaren när man lämnar sidan 
        await Navigation.PopAsync();
    }
}
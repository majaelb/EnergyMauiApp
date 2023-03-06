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
        await DisplayAlert("Klart!", "Din nya dagsbudget �r sparad", "Ok");
        await Navigation.PopAsync();
        user.MyBudget = 0; //Anv�nder singleton-instansen, nollst�ller budgetr�knaren n�r man l�mnar sidan
    }

    private async void OnBackClicked(object sender, EventArgs e)
    {
        user.MyBudget = 0; //Anv�nder singleton-instansen, nollst�ller budgetr�knaren n�r man l�mnar sidan 
        await Navigation.PopAsync();
    }
}
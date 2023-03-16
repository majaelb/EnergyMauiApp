using EnergyMauiapp.Helpers;
using EnergyMauiapp.Models;
using EnergyMauiapp.ViewModels;
using System.Text.Json;

namespace EnergyMauiapp.Views;

public partial class DailyBudgetPage : ContentPage
{

    DailyBudgetStartPageViewModel vm = new();

    public DailyBudgetPage()
    {
        InitializeComponent();
        BindingContext = vm;
    }


    private async void OnNewBudgetBtnClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new MakeNewDailyBudgetPage());
    }


    private async void OnCurrentBudgetBtnClicked(object sender, EventArgs e)
    {
        bool existingFile = FileManager.FindExistingFile("MyDailyBudget.txt");
        if (existingFile)
        {
            await Navigation.PushAsync(new CurrentDailyBudgetPage());
        }
        else
        {
            await DisplayAlert("Error", "Du måste göra en dagsbudget först!", "OK");
        }
    }

    private async void OnBackClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new MainPage());
    }

}

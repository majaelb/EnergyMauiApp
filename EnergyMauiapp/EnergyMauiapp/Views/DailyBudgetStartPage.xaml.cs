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
        DailyBudget dailyBudget = null;
        try
        {
            string json = File.ReadAllText(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "MyDailyBudget.txt"));
            dailyBudget = JsonSerializer.Deserialize<DailyBudget>(json);
        }
        catch (Exception)
        {
            await DisplayAlert("Error", "Du måste göra en dagsbudget först!", "OK");
        }
        if (dailyBudget != null)
        {
            await Navigation.PushAsync(new CurrentDailyBudgetPage());
        }
    }

    private async void OnBackClicked(object sender, EventArgs e)
    {
        await Navigation.PopAsync();
    }

}

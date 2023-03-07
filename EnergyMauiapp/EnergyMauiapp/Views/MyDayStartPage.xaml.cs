using EnergyMauiapp.Helpers;
using EnergyMauiapp.Models;
using EnergyMauiapp.ViewModels;
using System.Text.Json;
namespace EnergyMauiapp.Views;

public partial class MyDayStartPage : ContentPage
{
    DailyBudgetStartPageViewModel vm = new();

    public MyDayStartPage()
    {
        InitializeComponent();
        BindingContext = vm;
    }



    private async void OnPrevDaysBtnClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new MyPreviousDaysPage());
    }


    private async void OnMyDayBtnClicked(object sender, EventArgs e)
    {
        //TODO: B�da dessa saker kan h�nda n�r man trycker p� knappen. Hantera b�da samtidigt?
        //Man har inte gjort n�gon dagsbudget
        DailyBudget dailyBudget = null;
        try
        {
            string json = File.ReadAllText(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "MyDailyBudget.txt"));
            dailyBudget = JsonSerializer.Deserialize<DailyBudget>(json);
        }
        catch (Exception)
        {
            await DisplayAlert("Error", "Du m�ste g�ra en dagsbudget f�rst!", "OK");
        }
        if (dailyBudget != null)
        {
            await Navigation.PushAsync(new Views.MyDayPage());
        }

        //Man har redan sparat dagens aktiviteter
        int dayOfYear = PreviousDayManager.GetYesterDaysDayOfYear();
        if (dayOfYear == DateTime.Now.DayOfYear)
        {
            await DisplayAlert("Error", "Du har redan sparat dagens aktiviteter!", "OK");
        }
        else
        {
            await Navigation.PushAsync(new MyDayPage());
        }
    }

    private async void OnBackClicked(object sender, EventArgs e)
    {
        await Navigation.PopAsync();
    }
}
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
        //Om man har inte gjort n�gon dagsbudget f�r man ett felmeddelande och kommer inte in p� sidan:
        DailyBudget dailyBudget = null;
        string fileName = "MyDailyBudget.txt";
        try
        {
            dailyBudget = await FileManager.GetObjectFromTxt<DailyBudget>(fileName);
        }
        catch (Exception)
        {
            await DisplayAlert("Error", "Du m�ste g�ra en dagsbudget f�rst!", "OK");
        }
        //Om man redan har sparat dagens aktiviteter f�r man ocks� ett felmeddelande och kommer inte in p� sidan
        //TODO: Kommentera in detta n�r programmet k�rs p� riktigt
        //int dayOfYear = PreviousDayManager.GetYesterDaysDayOfYear();
        //if (dayOfYear == DateTime.Now.DayOfYear)
        //{
        //    await DisplayAlert("Error", "Du har redan sparat dagens aktiviteter!", "OK");
        //}
        //Om det finns b�de dagsbudget och man inte redan sparat n�got f�r dagen s� kommer man in p� sidan och kan fylla i aktiviteter
        /*else*/ if(/*dayOfYear != DateTime.Now.DayOfYear &&*/ dailyBudget != null) 
        {
            await Navigation.PushAsync(new MyDayPage());
        }
    }

    private async void OnBackClicked(object sender, EventArgs e)
    {
        await Navigation.PopAsync();
    }
}
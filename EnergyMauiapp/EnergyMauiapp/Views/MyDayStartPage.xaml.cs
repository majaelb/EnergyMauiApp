using EnergyMauiapp.Helpers;
using EnergyMauiapp.Models;
using EnergyMauiapp.ViewModels;
using System.Text.Json;
namespace EnergyMauiapp.Views;

public partial class MyDayStartPage : ContentPage
{
    MyDayPageViewModel vm = new();

    public MyDayStartPage()
    {
        InitializeComponent();
        BindingContext = vm;
    }

    private async void OnPrevDaysBtnClicked(object sender, EventArgs e)
    {
        string fileName = "DatePointsAndActivity.txt";
        bool existingFile = FileManager.FindExistingFile(fileName);
        if (existingFile)
        {
            await Navigation.PushAsync(new MyPreviousDaysPage());
        }
        else
        {
            await DisplayAlert("Error", "Det finns inga dagar att visa", "OK");
        }
    }


    private async void OnMyDayBtnClicked(object sender, EventArgs e)
    {
        //Om man har inte gjort någon dagsbudget får man ett felmeddelande och kommer inte in på sidan:
        DailyBudget dailyBudget = null;
        string fileName = "MyDailyBudget.txt";
        try
        {
            dailyBudget = await FileManager.GetObjectFromTxt<DailyBudget>(fileName);
        }
        catch (Exception)
        {
            await DisplayAlert("Error", "Du måste göra en dagsbudget först!", "OK");
        }
        //Om man redan har sparat dagens aktiviteter får man också ett felmeddelande och kommer inte in på sidan
        //TODO: Kommentera in detta när programmet körs på riktigt
        //int dayOfYear = 0;
        //try
        //{
        //    dayOfYear = await PreviousDayManager.GetYesterDaysDayOfYear();
        //}
        //catch
        //{

        //}
        //if (dayOfYear == DateTime.Now.DayOfYear)
        //{
        //    await DisplayAlert("Error", "Du har redan sparat dagens aktiviteter!", "OK");
        //}
        //Om det finns både dagsbudget och man inte redan sparat något för dagen så kommer man in på sidan och kan fylla i aktiviteter    
        if (/*dayOfYear != DateTime.Now.DayOfYear &&*/ dailyBudget != null)
        {
            await Navigation.PushAsync(new MyDayPage());
        }
    }

    private async void OnBackClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new MainPage());
    }
}
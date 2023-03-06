using EnergyMauiapp.Models;
using System.Text.Json;

namespace EnergyMauiapp;

public partial class MainPage : ContentPage
{
    ViewModels.MainPageViewModel vm = new();
    public MainPage()
    {
        InitializeComponent();
        BindingContext = vm;
    }

    //TODO: Använd shoppens metod för att lägga till produkt för att lägga till vad man gjort varje dag?
    private async void OnMyDayBtnClicked(object sender, EventArgs e)
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
        if(dailyBudget != null)
        {
            await Navigation.PushAsync(new Views.MyDayPage());
        }

    }
    private async void OnYouTubeBtnClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new Views.YouTubePage());
    }

    private async void OnEstimationBtnClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new Views.SelfEstimationPage());
    }

    private async void OnBudgetBtnClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new Views.DailyBudgetPage());
    }

    private async void OnFactLinkBtnClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new Views.FactsAndLinksPage());
    }
}


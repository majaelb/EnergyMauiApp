using EnergyMauiapp.Helpers;
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

    //TODO: kolla felhantering överallt! Kan man väva in felhantering av att läsa/skriva till fil i Facade?
    private async void OnMyDayBtnClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new Views.MyDayStartPage());
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


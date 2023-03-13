using EnergyMauiapp.Helpers;
using EnergyMauiapp.Models;
using EnergyMauiapp.ViewModels;
using System.Collections.ObjectModel;
using System.Text.Json;

namespace EnergyMauiapp.Views;

public partial class MakeNewSelfEstimationPage : ContentPage
{
    //TODO: Flytta över kod till ViewModel? Refaktorera ordentligt!
    
    MakeNewSelfEstimationPageViewModel vm = new();

    public MakeNewSelfEstimationPage()
    {
        InitializeComponent();
        BindingContext = vm;
        InfoText.Text = "Vi är intresserade av ditt nuvarande tillstånd, d.v.s. ungefär hur du har mått den senaste månaden.\r\nNär du ska jämföra med hur det var tidigare ska du göra det med hur det var innan du blev sjuk/skadades.\r\nI tabellen för varje fråga finns fyra påståenden som beskriver Inga (0), Lätta (1), Medelsvåra (2) och Svåra\r\nbesvär (3).\r\nVi vill att du skriver in den siffra som bäst beskriver dina besvär.\r\nOm du tycker att du hamnar mellan två påståenden finns det även siffror som motsvarar detta.";

    }

    private async void OnStartBtnClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new NewSelfEstPage());
    }

    private async void OnBackClicked(object sender, EventArgs e)
    {
        await Navigation.PopAsync();
    }
    //Facade där inparametrar är selftesttest och questioncount, en facade infotextcomponent, questioncomponent osv. I dessa bygger jag in felhanteringen. 
    //

}
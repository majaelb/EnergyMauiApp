using EnergyMauiapp.Helpers;
using EnergyMauiapp.Models;
using EnergyMauiapp.ViewModels;
using System.Collections.ObjectModel;
using System.Text.Json;

namespace EnergyMauiapp.Views;

public partial class MakeNewSelfEstimationPage : ContentPage
{
    //TODO: Flytta �ver kod till ViewModel? Refaktorera ordentligt!
    
    MakeNewSelfEstimationPageViewModel vm = new();

    public MakeNewSelfEstimationPage()
    {
        InitializeComponent();
        BindingContext = vm;
        InfoText.Text = "Vi �r intresserade av ditt nuvarande tillst�nd, d.v.s. ungef�r hur du har m�tt den senaste m�naden.\r\nN�r du ska j�mf�ra med hur det var tidigare ska du g�ra det med hur det var innan du blev sjuk/skadades.\r\nI tabellen f�r varje fr�ga finns fyra p�st�enden som beskriver Inga (0), L�tta (1), Medelsv�ra (2) och Sv�ra\r\nbesv�r (3).\r\nVi vill att du skriver in den siffra som b�st beskriver dina besv�r.\r\nOm du tycker att du hamnar mellan tv� p�st�enden finns det �ven siffror som motsvarar detta.";

    }

    private async void OnStartBtnClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new NewSelfEstPage());
    }

    private async void OnBackClicked(object sender, EventArgs e)
    {
        await Navigation.PopAsync();
    }
    //Facade d�r inparametrar �r selftesttest och questioncount, en facade infotextcomponent, questioncomponent osv. I dessa bygger jag in felhanteringen. 
    //

}
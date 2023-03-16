using EnergyMauiapp.Helpers;
using EnergyMauiapp.Models;
using EnergyMauiapp.ViewModels;
namespace EnergyMauiapp.Views;

public partial class MyDayPage : ContentPage
{
    ViewModels.MyDayPageViewModel vm = new();
    public MyDayPage()
    {
        InitializeComponent();
        BindingContext = vm;
    }


    //protected async override void OnAppearing()
    //{
    //    //Try catch så det inte kraschar om man inte lagt till någon aktivitet ännu
    //        base.OnAppearing();
    //    try
    //    {
    //        await (BindingContext as MyDayPageViewModel).GetSavedActivities();
    //    }
    //    catch (Exception)
    //    {
    //    }
    //}

    //OnAppearing körs inte asynkront, då dupliceras inte första posten i listan..
    protected override void OnAppearing()
    {
        //Try catch så det inte kraschar om man inte lagt till någon aktivitet ännu
        base.OnAppearing();
        try
        {
            (BindingContext as MyDayPageViewModel).GetSavedActivitiesNotAsync();

        }
        catch (Exception)
        {

        }
    }


    private async void OnAddBtnClicked(object sender, EventArgs e)
    {
        await DisplayAlert("Klart", "Aktiviteten är tillagd!", "OK");
    }

    private async void OnDeleteBtnClicked(object sender, EventArgs e)
    {
        await DisplayAlert("Klart", "Aktiviteten är borttagen!", "OK");
    }

    private async void OnBackClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new MainPage());
    }

}
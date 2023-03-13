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


    protected async override void OnAppearing()
    {
        //Try catch s� det inte kraschar om man inte lagt till n�gon aktivitet �nnu
        try
        {
            base.OnAppearing();
            //Task t = (BindingContext as MyDayPageViewModel).GetSavedActivities();
            await (BindingContext as MyDayPageViewModel).GetSavedActivities();

        }
        catch (Exception)
        {

        }
    }

    private async void OnAddBtnClicked(object sender, EventArgs e)
    {
        await DisplayAlert("Klart", "Aktiviteten �r tillagd!", "OK");
    }

    private async void OnDeleteBtnClicked(object sender, EventArgs e)
    {
        await DisplayAlert("Klart", "Aktiviteten �r borttagen!", "OK");
    }

    private async void OnBackClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new MainPage());
    }

}
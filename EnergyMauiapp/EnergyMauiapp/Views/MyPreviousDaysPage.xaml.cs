using EnergyMauiapp.Helpers;
using EnergyMauiapp.Models;
using EnergyMauiapp.ViewModels;

namespace EnergyMauiapp.Views;

public partial class MyPreviousDaysPage : ContentPage
{
    MyPreviousDaysPageViewModel vm = new();

    public MyPreviousDaysPage()
    {
        InitializeComponent();
        BindingContext = vm;
    }

    private async void OnListViewItemSelected(object sender, SelectedItemChangedEventArgs e)
    {
        //TODO: Kunna klicka p� resultatet flera g�nger i rad
        //Om vi klickat p� en av dagarna h�nder detta
        DailyEvent dailyEvent = ((ListView)sender).SelectedItem as DailyEvent;

        if (dailyEvent != null)
        {
            var page = new MyPreviousDaysDetailPage
            {
                BindingContext = dailyEvent
            };
            await Navigation.PushAsync(page);
        }
    }

    private async void OnBackClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new MyDayStartPage());
    }


}
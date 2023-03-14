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
        //TODO: Kunna klicka på resultatet flera gånger i rad
        //Om vi klickat på en av dagarna händer detta
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
using EnergyMauiapp.Helpers;
using EnergyMauiapp.Models;
using EnergyMauiapp.ViewModels;

namespace EnergyMauiapp.Views;

public partial class MyPreviousDaysPage : ContentPage
{
    ViewModels.MyPreviousDaysPageViewModel vm = new();



    public MyPreviousDaysPage()
	{
		InitializeComponent();
        BindingContext = vm;
	}

    private async void OnListViewItemSelected(object sender, SelectedItemChangedEventArgs e)
    {
        //Om vi klickat på en av produkterna händer detta
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
        await Navigation.PopAsync();
    }


}
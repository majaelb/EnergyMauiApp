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


    protected override async void OnAppearing()
    {
        //Try catch så det inte kraschar om man inte lagt till någon aktivitet ännu?
        try
        {
            base.OnAppearing();
            await (BindingContext as MyDayPageViewModel).GetSavedActivities();
        }
        catch (Exception)
        {

        }
    }

    private async void OnAddBtnClicked(object sender, EventArgs e)
    {
        await DisplayAlert("Klart", "Aktiviteten är tillagd!", "OK");
        await Navigation.PushAsync(new MyDayPage());
    }

    private async void OnDeleteBtnClicked(object sender, EventArgs e)
    {
        await DisplayAlert("Klart", "Aktiviteten är borttagen!", "OK");
        await Navigation.PushAsync(new MyDayPage());
    }

    private async void OnBackClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new MainPage());
    }

}
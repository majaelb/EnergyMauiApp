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

    //TODO: Två undersidor till denna, en för att lägga till dagens aktiviteter (går bara att trycka på om man inte redan sparat något på dagens datum) samt en för tidigare dagar som listas

    private async void OnSaveBtnClicked(object sender, EventArgs e)
    {
        //TODO: Avbrytknapp om man ångrar sig?
        await DisplayAlert("Klart", "Dagens aktiviteter är tillagda!", "OK");
        await Navigation.PushAsync(new MyDayPage());
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
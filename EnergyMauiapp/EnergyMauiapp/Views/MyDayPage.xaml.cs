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
        //Try catch s� det inte kraschar om man inte lagt till n�gon aktivitet �nnu?
        try
        {
            base.OnAppearing();
            await (BindingContext as MyDayPageViewModel).GetSavedActivities();
        }
        catch (Exception)
        {

        }
    }

    //TODO: Tv� undersidor till denna, en f�r att l�gga till dagens aktiviteter (g�r bara att trycka p� om man inte redan sparat n�got p� dagens datum) samt en f�r tidigare dagar som listas

    private async void OnSaveBtnClicked(object sender, EventArgs e)
    {
        //TODO: Avbrytknapp om man �ngrar sig?
        await DisplayAlert("Klart", "Dagens aktiviteter �r tillagda!", "OK");
        await Navigation.PushAsync(new MyDayPage());
    }

    private async void OnAddBtnClicked(object sender, EventArgs e)
    {
        await DisplayAlert("Klart", "Aktiviteten �r tillagd!", "OK");
        await Navigation.PushAsync(new MyDayPage());
    }

    private async void OnDeleteBtnClicked(object sender, EventArgs e)
    {
        await DisplayAlert("Klart", "Aktiviteten �r borttagen!", "OK");
        await Navigation.PushAsync(new MyDayPage());
    }

    private async void OnBackClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new MainPage());
    }

}
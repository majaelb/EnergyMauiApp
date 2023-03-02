namespace EnergyMauiapp.Views;

public partial class MyDayPage : ContentPage
{
    ViewModels.MyDayPageViewModel vm = new();
	public MyDayPage()
	{
		InitializeComponent();
        BindingContext = vm;

    }

    private async void OnBackClicked(object sender, EventArgs e)
    {
        await Navigation.PopAsync();
    }
}
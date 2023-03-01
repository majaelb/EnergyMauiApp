namespace EnergyMauiapp.Views;

public partial class MyDayPage : ContentPage
{
	public MyDayPage()
	{
		InitializeComponent();
	}

    private async void OnBackClicked(object sender, EventArgs e)
    {
        await Navigation.PopAsync();
    }
}
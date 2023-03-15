namespace EnergyMauiapp.Views;

public partial class MyPreviousDaysDetailPage : ContentPage
{
	public MyPreviousDaysDetailPage()
	{
		InitializeComponent();
	}

    private async void OnBackClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new MyPreviousDaysPage());
    }
}
namespace EnergyMauiapp;

public partial class MainPage : ContentPage
{
    ViewModels.MainPageViewModel vm = new();
	public MainPage()
	{
		InitializeComponent();
        BindingContext = vm;    
	}

    //protected override void OnAppearing()
    //{
    //    base.OnAppearing();
    //    vm.AddOneRandomTips();
    //}
    //TODO: Använd Onappearing för alla tips som ska rulla ? Samt länkar mm?
    
    //TODO: Använd shoppens metod för att lägga till produkt för att lägga till vad man gjort varje dag?
    //TODO: Button för dagens aktiviteter som sparas
    private async void OnMyDayBtnClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new Views.MyDayPage());
    }
    private async void OnYouTubeBtnClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new Views.YouTubePage());
    }

    private async void OnEstimationBtnClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new Views.SelfEstimationPage());
    }

    private async void OnBudgetBtnClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new Views.DailyBudgetPage());
    }

    private async void OnFactLinkBtnClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new Views.FactsAndLinksPage());
    }
}


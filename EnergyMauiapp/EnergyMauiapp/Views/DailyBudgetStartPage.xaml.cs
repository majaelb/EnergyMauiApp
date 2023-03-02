using EnergyMauiapp.ViewModels;

namespace EnergyMauiapp.Views;

public partial class DailyBudgetPage : ContentPage
{

    DailyBudgetStartPageViewModel vm = new();
    
    public DailyBudgetPage()
    {
        InitializeComponent();
        BindingContext = vm;
    }



    private async void OnNewBudgetBtnClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new MakeNewDailyBudgetPage());
    }


    private async void OnCurrentBudgetBtnClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new CurrentDailyBudgetPage());
    }

    private async void OnBackClicked(object sender, EventArgs e)
    {
        await Navigation.PopAsync();
    }

}

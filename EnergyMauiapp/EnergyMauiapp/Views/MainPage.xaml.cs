﻿namespace EnergyMauiapp;

public partial class MainPage : ContentPage
{
	//int count = 0;

	public MainPage()
	{
		InitializeComponent();
         
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

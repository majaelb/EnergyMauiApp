using EnergyMauiapp.Helpers;
using EnergyMauiapp.Models;
using EnergyMauiapp.ViewModels;
using Microsoft.Maui.Storage;
using System.Collections.ObjectModel;
using System.Text.Json;

namespace EnergyMauiapp.Views;

public partial class NewSelfEstPage : ContentPage
{
    NewSelfEstViewModel vm = new();

    static UserSingleton user = UserSingleton.GetUserSessionData();

    int questionCount = 0;

    public List<SelfEstTest> SelfEstTest = ListManager.MakeQuestionList();

    public NewSelfEstPage()
    {
        InitializeComponent();
        BindingContext = vm;
        Question.Text = SelfEstTest[0].Question;
        AnswerOptions.Text = SelfEstTest[0].AnswerOptions;
    }

    private async void OnNextBtnClicked(object sender, EventArgs e)
    {
        if (questionCount > SelfEstTest.Count - 3)
        {
            NextBtn.IsVisible = false;
            ResultBtn.IsVisible = true;
        }

        Answer.Text ??= "";

        bool isValidAnswer = InputManager.RegexCheck("^(0|0,5|1|1,5|2|2,5|3)$", Answer.Text);
        if (isValidAnswer)
        {
            user.EstResult += Convert.ToDouble(Answer.Text);
            questionCount++;
        }
        else
        {
            await DisplayAlert("Error", "Felaktig inmatning", "OK");
        }

        if (questionCount > 0)
        {
            Question.Text = SelfEstTest[questionCount].Question;
            AnswerOptions.Text = SelfEstTest[questionCount].AnswerOptions;
        }
        Answer.Text = string.Empty; //Nollställer textrutan mellan varje inmatning
        Result.Text = "Ditt resultat: " + user.EstResult.ToString();
    }

    private async void OnResultBtnClicked(object sender, EventArgs e)
    {
        bool isValidAnswer = InputManager.RegexCheck("^(0|0,5|1|1,5|2|2,5|3)$", Answer.Text);

        if (isValidAnswer)
        {
            user.EstResult += Convert.ToDouble(Answer.Text);

            Dictionary<DateTime, double> result = new()
            {
                { DateTime.Now, user.EstResult }
            };
            string fileName = "Skattningsresultaten.txt";
            string path = FileManager.GetFilePath(fileName);
            if (!File.Exists(path))
            {
                FileManager.WriteObjectToFile(path, result);
            }
            else
            {
                var dictionary = await FileManager.GetObjectFromTxt<Dictionary<DateTime, double>>(fileName);
                dictionary.Add(DateTime.Now, user.EstResult);
                FileManager.WriteObjectToFile(fileName, dictionary);
            }
            user.EstResult = 0;
            await DisplayAlert("Klart", "Resultatet är sparat", "OK");
            await Navigation.PushAsync(new PreviousSelfEstimationsPage());
        }
        else
        {
            await DisplayAlert("Error", "Felaktig inmatning", "OK");
        }

    }
    private async void OnBackClicked(object sender, EventArgs e)
    {
        user.EstResult = 0;
        await Navigation.PopAsync();
    }


}
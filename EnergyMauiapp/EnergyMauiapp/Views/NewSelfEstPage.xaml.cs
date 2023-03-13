using EnergyMauiapp.Helpers;
using EnergyMauiapp.Models;
using EnergyMauiapp.ViewModels;
using System.Collections.ObjectModel;
using System.Text.Json;

namespace EnergyMauiapp.Views;

public partial class NewSelfEstPage : ContentPage
{
    NewSelfEstViewModel vm = new();

    static UserSingleton user = UserSingleton.GetUserSessionData();

    int questionCount = 0;

   // public List<SelfEstTest> SelfEstTest = ListManager.MakeQuestionList();

    public ObservableCollection<SelfEstTest> SelfEstTest = ListManager.MakeQuestionList();

    public NewSelfEstPage()
    {
        InitializeComponent();
        BindingContext = vm;  
        Question.Text = SelfEstTest[0].Question;
        AnswerOptions.Text = SelfEstTest[0].AnswerOptions;
    }

    private async void OnNextBtnClicked(object sender, EventArgs e)
    {
        if (questionCount > SelfEstTest.Count -2)
        {
            NextBtn.IsVisible = false;
            ResultBtn.IsVisible = true;
        }

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
        Result.Text = "Ditt resultat: " + user.EstResult.ToString();
        Answer.Text = string.Empty; //Nollställer textrutan mellan varje inmatning
                                    // questionCount++;
    }

    private async void OnResultBtnClicked(object sender, EventArgs e)
    {
        bool isValidAnswer = InputManager.RegexCheck("^(0|0,5|1|1,5|2|2,5|3)$", Answer.Text);

        if (isValidAnswer)
        {
            User.EstResult += Convert.ToDouble(Answer.Text);
            User.DateAndEstimationResult.Add(DateTime.Now, User.EstResult); //Ska denna ligga i if-satsen?

            string fileName = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Skattningsresultaten.txt");//address
            if (!File.Exists(fileName))
            {
                string jsonString = JsonSerializer.Serialize(User.DateAndEstimationResult);
                File.WriteAllText(fileName, jsonString);
            }
            else
            {
                string text = File.ReadAllText(fileName);
                var dictionary = JsonSerializer.Deserialize<Dictionary<DateTime, double>>(text);
                dictionary.Add(DateTime.Now, User.EstResult);
                string jsonString = JsonSerializer.Serialize(dictionary);
                File.WriteAllText(fileName, jsonString);
            }
            User.EstResult = 0;
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
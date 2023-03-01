using EnergyMauiapp.Models;
using System.Text.Json;

namespace EnergyMauiapp.Views;

public partial class MakeNewSelfEstimationPage : ContentPage
{
    int questionCount = 0;
   
    public MakeNewSelfEstimationPage()
    {
        InitializeComponent();
    }
    private void OnNextBtnClicked(object sender, EventArgs e)
    {
        List<SelfEstTest> selfEstTest = SelfEstTest.MakeQuestionList();
        NextBtn.Text = "Nästa fråga";
        Answer.IsVisible = true;
        if (questionCount > selfEstTest.Count - 2)
        {
            NextBtn.IsVisible = false;
            ResultBtn.IsVisible = true;
        }

        InfoText.Text = "Vi är intresserade av ditt nuvarande tillstånd, d.v.s. ungefär hur du har mått den senaste månaden.\r\nNär du ska jämföra med hur det var tidigare ska du göra det med hur det var innan du blev sjuk/skadades.\r\nI tabellen för varje fråga finns fyra påståenden som beskriver Inga (0), Lätta (1), Medelsvåra (2) och Svåra\r\nbesvär (3).\r\nVi vill att du markerar den siffra som står bredvid det påstående som bäst beskriver dina besvär.\r\nOm du tycker att du hamnar mellan två påståenden finns det även siffror som motsvarar detta.";
        Question.Text = selfEstTest[questionCount].Question;
        AnswerOptions.Text = selfEstTest[questionCount].AnswerOptions;
        User.EstResult += Convert.ToDouble(Answer.Text);
        Result.Text = "Ditt resultat: " + User.EstResult.ToString();
        Answer.Text = string.Empty; //Nollställer textrutan mellan varje inmatning

        questionCount++;
    }

    private async void OnResultBtnClicked(object sender, EventArgs e)
    {
        User.EstResult += Convert.ToDouble(Answer.Text); //Räknar in även sista poängen när man trycker sig vidare

        User.DateAndResult.Add(DateTime.Now, User.EstResult); //Ska denna ligga i if-satsen?

        string fileName = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Skattningsresultaten.txt");//address
        if (!File.Exists(fileName))
        {
            string jsonString = JsonSerializer.Serialize(User.DateAndResult);
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


        //SelfEstimation selfEstimation = new()
        //{
        //    Date = DateTime.Now,
        //    Result = User.EstResult
        //};
        //string fileName = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "SkattningsresultatMedKlass.txt");//address
        //if (!File.Exists(fileName))
        //{
        //    string jsonString = JsonSerializer.Serialize(selfEstimation);
        //    File.WriteAllText(fileName, jsonString);
        //}
        //else
        //{
        //    string text = File.ReadAllText(fileName);
        //    List<SelfEstimation> selfEstimations = JsonSerializer.Deserialize<List<SelfEstimation>>(text); //+options?
        //    selfEstimations.Add(selfEstimation);
        //    string jsonString = JsonSerializer.Serialize(selfEstimations);
        //    File.WriteAllText(fileName, jsonString);
        //}

        await Navigation.PushAsync(new PreviousSelfEstimationsPage());

    }
    private async void OnBackClicked(object sender, EventArgs e)
    {
        await Navigation.PopAsync();
    }
}
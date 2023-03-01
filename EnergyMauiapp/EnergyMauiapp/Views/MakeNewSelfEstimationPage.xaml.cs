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
        NextBtn.Text = "N�sta fr�ga";
        Answer.IsVisible = true;
        if (questionCount > selfEstTest.Count - 2)
        {
            NextBtn.IsVisible = false;
            ResultBtn.IsVisible = true;
        }

        InfoText.Text = "Vi �r intresserade av ditt nuvarande tillst�nd, d.v.s. ungef�r hur du har m�tt den senaste m�naden.\r\nN�r du ska j�mf�ra med hur det var tidigare ska du g�ra det med hur det var innan du blev sjuk/skadades.\r\nI tabellen f�r varje fr�ga finns fyra p�st�enden som beskriver Inga (0), L�tta (1), Medelsv�ra (2) och Sv�ra\r\nbesv�r (3).\r\nVi vill att du markerar den siffra som st�r bredvid det p�st�ende som b�st beskriver dina besv�r.\r\nOm du tycker att du hamnar mellan tv� p�st�enden finns det �ven siffror som motsvarar detta.";
        Question.Text = selfEstTest[questionCount].Question;
        AnswerOptions.Text = selfEstTest[questionCount].AnswerOptions;
        User.EstResult += Convert.ToDouble(Answer.Text);
        Result.Text = "Ditt resultat: " + User.EstResult.ToString();
        Answer.Text = string.Empty; //Nollst�ller textrutan mellan varje inmatning

        questionCount++;
    }

    private async void OnResultBtnClicked(object sender, EventArgs e)
    {
        User.EstResult += Convert.ToDouble(Answer.Text); //R�knar in �ven sista po�ngen n�r man trycker sig vidare

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
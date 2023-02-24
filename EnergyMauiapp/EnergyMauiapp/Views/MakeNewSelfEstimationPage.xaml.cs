using EnergyMauiapp.Models;
using static System.Net.Mime.MediaTypeNames;

namespace EnergyMauiapp.Views;

public partial class MakeNewSelfEstimationPage : ContentPage
{
    int questionCount = 0;
    private readonly List<string> answers = new();
    //string fileName = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "skattningsresultat.txt");//address
    //    if (!File.Exists(fileName))
    //    File.WriteAllText(fileName, "");
    //Tom textfil skapas här eller när skattningen. Första gången en skattning görs så sparas resultatet i en lista i Json-format. List.serialize eller liknande. Strängen från det sparas
    //TODO när personen svarat på skattningen sparas datum och points i Json/list. Läs in allt, serialisera osv
    public MakeNewSelfEstimationPage()
    {
        InitializeComponent();
        //BindingContext = new ViewModels.SelfEstimationViewModel();

    }


    private void CountResult(object sender, EventArgs e)
    {
        string text = ((Entry)sender).Text;
        answers.Add(text);
        double totalresult = 0;
        foreach (var answer in answers)
        {
            totalresult += Convert.ToDouble(answer);
        }
        Result.Text = "Ditt resultat: " + totalresult.ToString() + Environment.NewLine +
            "En summa på 10,5 poäng eller över visar problem med hjärntrötthet och bör utredas vidare.";

        //TODO: visa med for-loop istället för listview, counter med questions som räknar upp för varje fråga som är besvarad
        //SelfEstimation selfEst = new();
        //selfEst.Result = totalresult;
        //Spara resultat och dagens datum till personens konto/db/fil/liknande
    }

    private async void OnBackClicked(object sender, EventArgs e)
    {
        await Navigation.PopAsync();
    }

    private void OnNextBtnClicked(object sender, EventArgs e)
    {
        List<SelfEstTest> selfEstTest = SelfEstTest.MakeQuestionList();
        NextBtn.Text = "Nästa fråga";
        Answer.IsVisible = true;
        //TODO: Försök nollställa texten i entryn mellan varje tryckning
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
        
        questionCount++;
    }

    private async void OnResultBtnClicked(object sender, EventArgs e)
    {
        //Spara resultat och skicka till resultatsidan?
        await Navigation.PushAsync(new PreviousSelfEstimationsPage());
    }
}
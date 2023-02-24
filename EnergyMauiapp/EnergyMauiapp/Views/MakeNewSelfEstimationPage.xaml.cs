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
    //Tom textfil skapas h�r eller n�r skattningen. F�rsta g�ngen en skattning g�rs s� sparas resultatet i en lista i Json-format. List.serialize eller liknande. Str�ngen fr�n det sparas
    //TODO n�r personen svarat p� skattningen sparas datum och points i Json/list. L�s in allt, serialisera osv
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
            "En summa p� 10,5 po�ng eller �ver visar problem med hj�rntr�tthet och b�r utredas vidare.";

        //TODO: visa med for-loop ist�llet f�r listview, counter med questions som r�knar upp f�r varje fr�ga som �r besvarad
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
        NextBtn.Text = "N�sta fr�ga";
        Answer.IsVisible = true;
        //TODO: F�rs�k nollst�lla texten i entryn mellan varje tryckning
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
        
        questionCount++;
    }

    private async void OnResultBtnClicked(object sender, EventArgs e)
    {
        //Spara resultat och skicka till resultatsidan?
        await Navigation.PushAsync(new PreviousSelfEstimationsPage());
    }
}
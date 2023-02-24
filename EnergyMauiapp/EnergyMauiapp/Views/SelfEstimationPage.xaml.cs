namespace EnergyMauiapp.Views;

public partial class SelfEstimationPage : ContentPage
{
    private readonly List<string> answers = new();

    public SelfEstimationPage()
    {
        InitializeComponent();
        BindingContext = new ViewModels.SelfEstimationViewModel();
    }

    private async void OnBackClicked(object sender, EventArgs e)
    {
        await Navigation.PopAsync();
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
}
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
            "En summa på 10,5 poäng eller över visar problem med hjärntrötthet och bör utredas vidare.";

        //TODO: visa med for-loop istället för listview, counter med questions som räknar upp för varje fråga som är besvarad
        //SelfEstimation selfEst = new();
        //selfEst.Result = totalresult;
        //Spara resultat och dagens datum till personens konto/db/fil/liknande
    }
}
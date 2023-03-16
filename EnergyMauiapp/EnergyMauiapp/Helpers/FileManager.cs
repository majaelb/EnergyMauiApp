using EnergyMauiapp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using Microsoft.Maui.Storage;

namespace EnergyMauiapp.Helpers
{
    //Metoderna i denna klass motsvarar en "facade" i mitt program.
    //Jag letade länge efter ett designpattern utan att hitta något som jag tyckte passade för att läsa och skriva till fil, som mitt program är uppbyggt av
    //och där ett design pattern kunde ha varit till hjälp. Jag förstår samtidigt att det kanske visst finns något som kunde ha passat, men med de kunskaper 
    //jag besitter i området idag så kunde jag inte hitta något som jag kunde se framför mig användas i mitt projekt. Jag tror dessutom att om jag hittat ett
    //pattern hade behövt bestämma mig för ett pattern att följa från start, och inte försöka lägga till något så pass sent i projektets gång då jag hade behövt
    //bygga om så stora delar av koden att tiden inte hade räckt till.
    //Om jag förstått tanken med facade rätt, så är det att koka ner bakomliggande funktioner till en enda enkel sådan och då jag läser och skriver till fil
    //på så pass många ställen i programmet så hade jag inte kunnat ha en enda sida för detta, utan det hade blivit flera Facader varpå det känns som att idén
    //med designmönstret går förlorad. Singleton använder jag däremot och har stor nytta av för att hålla reda på data under programmets gång.
    //Tanken med min app är ju att den ska användas av och vara ett fungerande hjälpmedel för hjärntrötta. Av den anledningen valde jag bort inloggning, id:n
    //och anslutning till databaser, så att användaren bara ska kunna fokusera på att använda själva appen utan att registrera sig och hålla rätt på inloggnings-
    //uppgifter. Hade jag haft någon form av registrering hade dock en implementering av Facade känts som ett bra alternativ. Men återigen så är tanken med appen
    //att den ska vara så enkel det bara går att använda. Användaren ska navigera enbart med hjälp av knapptryckningar för att minimera riskerna för att göra fel
    //och tappa bort sig i programmet. 
    //Metoderna i denna klass sköter all typ av filhantering som jag behöver. Jag har gjort de flesta metoderna asynkrona och generiska för att de ska vara smidiga att
    //använda till alla typer av object som behöver hämtas eller skrivas. Metoden som hämtar en lista OnAppearing fick jag dock se mig besegrad av pga buggen som
    //duplicerade första posten i listan, och fick göra en synkron metod för att kringgå problemet. 

    internal class FileManager
    {
        public static bool FindExistingFile(string fileName)
        {
            string path = GetFilePath(fileName);
            if (File.Exists(path))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static async Task<T> GetFoundExistingFile<T>(string fileName, string errorMsg)
        {
            bool existingFile = FileManager.FindExistingFile(fileName);
            if (existingFile)
            {
                T dailyActivities = await FileManager.GetObjectFromTxt<T>(fileName);
                return dailyActivities;
            }
            else
            {
                await Application.Current.MainPage.DisplayAlert("Error", errorMsg, "OK");
                return default;
            }
        }

        public static string GetFilePath(string fileName)
        {
            string path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), fileName);

            return path;
        }
      
        public static async Task<T> GetObjectFromTxt<T>(string fileName)
        {
            string path = GetFilePath(fileName);
            string json = await File.ReadAllTextAsync(path);
            T obj = JsonSerializer.Deserialize<T>(json);

            return obj;
        }

        public static async void WriteObjectToFile<T>(string fileName, T obj)
        {
            string path = GetFilePath(fileName);
            string jsonString = JsonSerializer.Serialize(obj);

            await File.WriteAllTextAsync(path, jsonString);
        }


        public static T GetObjectFromTxtNotAsync<T>(string fileName)
        {
            string path = GetFilePath(fileName);
            string json =  File.ReadAllText(path);
            T obj = JsonSerializer.Deserialize<T>(json);

            return obj;
        }
        public static async void SaveDailyActivitiesToFile(List<Budget> dailyActivities)
        {
            string fileName2 = "MyDailyBudget.txt";
            DailyBudget dailyBudget = await FileManager.GetObjectFromTxt<DailyBudget>(fileName2);
            int diff = await ViewModels.MyDayPageViewModel.CountTodaysBudget();
            int totalBudget = dailyBudget.TotalDailyBudget - diff;

            //Skapar nytt daily event med datum, dagens totalbudget med ev avdrag, summa av poängen av dagens aktiviteter samt en lista med alla aktiviteterna(Med namn och poäng).
            DailyEvent dailyEvent = new() { Date = DateTime.Now/*.AddDays(-1)*/, DailyBudget = totalBudget, UsedBudgetPoints = dailyActivities.Sum(p => p.Points), MyActivities = dailyActivities };
            var dateAndUsedPoints = new List<DailyEvent>()
                {
                    dailyEvent
                };
            //Skapar ny textfil att skriva datum och summa i
            string fileName3 = "DatePointsAndActivity.txt";
            string path = FileManager.GetFilePath(fileName3);
            if (!File.Exists(path))
            {
                FileManager.WriteObjectToFile(path, dateAndUsedPoints);
            }
            else
            {
                List<DailyEvent> dailyEvents = await FileManager.GetObjectFromTxt<List<DailyEvent>>(path);
                dailyEvents.Add(dailyEvent);
                FileManager.WriteObjectToFile(path, dailyEvents);
            }
        }

        public static async void DeleteFileWhenSaved(string fileName)
        {
            string path2 = FileManager.GetFilePath(fileName);
            File.Delete(path2);
            await Application.Current.MainPage.DisplayAlert("Klart", "Dagens aktiviteter är sparade!", "OK");
            await Application.Current.MainPage.Navigation.PushAsync(new Views.MyDayStartPage());
        }

        public static async void SaveSelfEstimationResult(SelfEstimation selfEst)
        {         
            var selfEstimations = new List<SelfEstimation>
            {
                selfEst
            };
            string fileName = "minaSkattningsResultat.txt";

            string path = FileManager.GetFilePath(fileName);
            if (!File.Exists(path))
            {
                FileManager.WriteObjectToFile(path, selfEstimations);
            }
            else
            {
                List<SelfEstimation> selfEstResults = await FileManager.GetObjectFromTxt<List<SelfEstimation>>(path);
                selfEstResults.Add(selfEst);
                FileManager.WriteObjectToFile(path, selfEstResults);
            }
        }

    }
}

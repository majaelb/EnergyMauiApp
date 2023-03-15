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
      
        //TODO: Denna klass och metoder motsvarar min facade?
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
            DailyEvent dailyEvent = new() { Date = DateTime.Now.AddDays(-1), DailyBudget = totalBudget, UsedBudgetPoints = dailyActivities.Sum(p => p.Points), MyActivities = dailyActivities };
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

    }
}

using CommunityToolkit.Mvvm.ComponentModel;
using EnergyMauiapp.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Maui.Storage;
using AngleSharp.Common;
using EnergyMauiapp.Helpers;
using EnergyMauiapp.Views;

namespace EnergyMauiapp.ViewModels
{
    internal partial class MyDayPageViewModel : ObservableObject
    {

        [ObservableProperty]
        string tips;

        [ObservableProperty]
        string name;

        [ObservableProperty]
        int points;

        [ObservableProperty]
        int totalBudget;

        [ObservableProperty]
        ObservableCollection<Budget> activityList; //Visar hela listan med valbara aktiviteter

        [ObservableProperty]
        public ObservableCollection<Budget> myDailyActivitiesList; //Visar de aktiviteter man valt för dagen

        public Header Header { get; set; }

        public MyDayPageViewModel()
        {
            string fileName = "MyDailyBudget.txt";
            var dailyBudget = Task.Run(() => FileManager.GetObjectFromTxt<DailyBudget>(fileName));
            dailyBudget.Wait();

            var diff = Task.Run(CountTodaysBudget);
            diff.Wait();
            TotalBudget = dailyBudget.Result.TotalDailyBudget - diff.Result;

            ActivityList = ListManager.MakeBudgetList();

            MyDailyActivitiesList = new ObservableCollection<Budget>();

            Tips = ListManager.AddOneRandomTips();
            Header = new Header()
            {
                Title = "Min dag",
                HeaderImageSource = "flowersheader.jpg"
            };
        }

        //TODO: Button för "har du sovit dåligt eller är sjuk?" som också drar av x antal poäng
        public static async Task<int> CountTodaysBudget()
        {
            string fileName = "MyDailyBudget.txt";
            DailyBudget dailyBudget = await FileManager.GetObjectFromTxt<DailyBudget>(fileName);
            int yesterDaysUsedPoints = 0;
            int yesterDaysDayOfYear = 0;
            try
            {
                yesterDaysUsedPoints = await PreviousDayManager.GetYesterDaysUsedBudgetPoints();
                yesterDaysDayOfYear = await PreviousDayManager.GetYesterDaysDayOfYear();
            }
            catch
            {

            }

            if (yesterDaysUsedPoints > dailyBudget.TotalDailyBudget && yesterDaysDayOfYear + 1 == DateTime.Now.DayOfYear)
            {
                int diff = yesterDaysUsedPoints - dailyBudget.TotalDailyBudget;
                return diff;
            }
            else
            {
                return 0;
            }
        }
   
        //Visas OnAppearing 
        public async Task GetSavedActivities()
        {
            string fileName = "Activities.txt";
            List<Budget> activitiesFromTxt = await FileManager.GetObjectFromTxt<List<Budget>>(fileName);
            activitiesFromTxt.ForEach(MyDailyActivitiesList.Add);
        }


        [RelayCommand]
        public async void Add(object b)
        {
            var budget = (Budget)b;

            List<Budget> activityList = new()
            {
                budget
            };
            string fileName = "Activities.txt";
            string path = FileManager.GetFilePath(fileName);
            if (!File.Exists(path))
            {
                FileManager.WriteObjectToFile(path, activityList);
            }
            else
            {
                List<Budget> dailyActivities = await FileManager.GetObjectFromTxt<List<Budget>>(fileName);
                dailyActivities.Add(budget);
                FileManager.WriteObjectToFile(fileName, dailyActivities);
            }
            MyDailyActivitiesList.Add(budget);
        }

        [RelayCommand]
        public  async void Delete(object b)
        {
            var budget = (Budget)b;

            string fileName = "Activities.txt";
            List<Budget> dailyActivities = await FileManager.GetObjectFromTxt<List<Budget>>(fileName);

            int removeIndex = dailyActivities.FindIndex(b => b.Name == budget.Name);
            dailyActivities.RemoveAt(removeIndex);
            FileManager.WriteObjectToFile(fileName, dailyActivities);
            MyDailyActivitiesList.Remove(budget);
        }

        //TODO: Facade: Save daily event? 
        [RelayCommand]
        public async static void Save()
        {
            //Försöker hämta sparade aktiviter och poäng från fil
            string fileName = "Activities.txt";
            List<Budget> dailyActivities = null;
            try
            {
                dailyActivities = await FileManager.GetObjectFromTxt<List<Budget>>(fileName);
            }
            //Om ingen fil finns sparad får man ett felmeddelande
            catch (Exception)
            {
                await Application.Current.MainPage.DisplayAlert("Error", "Du har inte lagt till några aktiviteter", "OK");
            }
            bool answer = false;
            //Kontrollerar om det finns något innehåll i filen (Om man lagt till en aktivitet och sen tagit bort den, så att listan blivit tom, men filen ändå skapats)
            if (dailyActivities != null && dailyActivities.Any())
            {
                answer = await Application.Current.MainPage.DisplayAlert("Confirm", "Är du säker på att du vill spara alla dagens aktiviteter? Du kan inte spara något mer för denna dag.", "OK", "Avbryt");
            }
            else if(dailyActivities != null && !dailyActivities.Any())
            {
                await Application.Current.MainPage.DisplayAlert("Error", "Du har inte lagt till några aktiviteter", "OK");
            }

            if (answer == true)
            {
                string fileName2 = "MyDailyBudget.txt";
                DailyBudget dailyBudget = await FileManager.GetObjectFromTxt<DailyBudget>(fileName2);
                int diff = await CountTodaysBudget();
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

                //Tar bort filen med sparade aktiviteter när datum och summa är sparat  
                string path2 = FileManager.GetFilePath(fileName);
                File.Delete(path2);
                await Application.Current.MainPage.DisplayAlert("Klart", "Dagens aktiviteter är sparade!", "OK");
                await Application.Current.MainPage.Navigation.PushAsync(new MyDayStartPage());
            }
            else
            {
                return;
            }
        }

    }
}

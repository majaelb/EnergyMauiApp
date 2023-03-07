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
        ObservableCollection<Budget> myDailyActivitiesList; //Visar de aktiviteter man valt för dagen


        public Header Header { get; set; }

        public MyDayPageViewModel()
        {
            string fileName = "MyDailyBudget.txt";
            DailyBudget dailyBudget = FileManager.GetObjectFromTxt<DailyBudget>(fileName);
            int diff = CountTodaysBudget();
            TotalBudget = dailyBudget.TotalDailyBudget - diff;

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
        public static int CountTodaysBudget()
        {
            string fileName = "MyDailyBudget.txt";
            DailyBudget dailyBudget = FileManager.GetObjectFromTxt<DailyBudget>(fileName);

            int yesterDaysUsedPoints = PreviousDayManager.GetYesterDaysUsedBudgetPoints();
            int yesterDaysDayOfYear = PreviousDayManager.GetYesterDaysDayOfYear();

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

        //Visas OnAppearing //TODO: Hur göra asyncron på riktigt?
        public async Task GetSavedActivities()
        {
            string fileName = "Activities.txt";
            List<Budget> activitiesFromTxt = FileManager.GetObjectFromTxt<List<Budget>>(fileName);
            await Task.Delay(100);
            activitiesFromTxt.ForEach(MyDailyActivitiesList.Add);
        }


        //TODO: Facade: Save daily event? 
        [RelayCommand]
        public static void Add(object b)
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
                List<Budget> dailyActivities = FileManager.GetObjectFromTxt<List<Budget>>(fileName);
                dailyActivities.Add(budget);
                FileManager.WriteObjectToFile(fileName, dailyActivities);
            }
        }

        [RelayCommand]
        public static void Delete(object b)
        {
            var budget = (Budget)b;

            string fileName = "Activities.txt";
            List<Budget> dailyActivities = FileManager.GetObjectFromTxt<List<Budget>>(fileName);

            int removeIndex = dailyActivities.FindIndex(b => b.Name == budget.Name);
            dailyActivities.RemoveAt(removeIndex);

            FileManager.WriteObjectToFile(fileName, dailyActivities);
        }

        [RelayCommand]
        public void Save()
        {
            //TODO: Ska inte gå att trycka på spara om inga aktiviteter finns tillagda
            //Hämta sparade aktiviter och poäng från fil
            string fileName = "Activities.txt";
            List<Budget> dailyActivities = FileManager.GetObjectFromTxt<List<Budget>>(fileName);

            //TODO: Lägg till lista av aktiviteter i dailyevent också? Så att de kan visas på separat sida av tidigare dagars aktivitet
            //Skapa nytt daily event med datum och summa av dagens aktiviteter
            DailyEvent dailyEvent = new() { Date = DateTime.Now, BudgetPoints = dailyActivities.Sum(p => p.Points) };
            var dateAndUsedPoints = new List<DailyEvent>()
            {
                dailyEvent
            };
            //Skapa ny textfil att skriva datum och summa i
            string fileName2 = "DateAndUsedPoints.txt";
            string path = FileManager.GetFilePath(fileName2);
            if (!File.Exists(path))
            {
                FileManager.WriteObjectToFile(path, dateAndUsedPoints);
            }
            else
            {
                List<DailyEvent> dailyEvents = FileManager.GetObjectFromTxt<List<DailyEvent>>(path);
                dailyEvents.Add(dailyEvent);
                FileManager.WriteObjectToFile(path, dailyEvents);
            }

            //Tar bort mydailyactivities (både obs.collection och filen) när datum och summa är sparat  
            string path2 = FileManager.GetFilePath(fileName);
            File.Delete(path2);
            MyDailyActivitiesList.Clear();         
        }
    }
}

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
        int usedPoints;

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

            var usedPoints = Task.Run(() => CountUsedPoints());
            usedPoints.Wait();
            UsedPoints = usedPoints.Result;

            ActivityList = ListManager.MakeBudgetList();

            MyDailyActivitiesList = new ObservableCollection<Budget>();

            Tips = ListManager.AddOneRandomTips();
            Header = new Header()
            {
                Title = "Min dag",
                HeaderImageSource = "flowersheader.jpg"
            };
        }

        public static async Task<int> CountUsedPoints()
        {
            string fileName = "Activities.txt";
            bool existingFile = FileManager.FindExistingFile(fileName);

            if (existingFile)
            {
                List<Budget> activitiesFromxTxt = await FileManager.GetObjectFromTxt<List<Budget>>(fileName);
                int usedPoints = activitiesFromxTxt.Sum(x => x.Points);
                return usedPoints;
            }
            else
            {
                return 0;
            }
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
        //public async Task GetSavedActivities()
        //{
        //    string fileName = "Activities.txt";
        //    List<Budget> activitiesFromTxt = await FileManager.GetObjectFromTxt<List<Budget>>(fileName);
        //    activitiesFromTxt.ForEach(MyDailyActivitiesList.Add);
        //}

        //Kör den icke-asynkrona metoden för att komma bort från problemet att första posten i listan dupliceras
        public void GetSavedActivitiesNotAsync()
        {
            string fileName = "Activities.txt";
            List<Budget> activitiesFromTxt = FileManager.GetObjectFromTxtNotAsync<List<Budget>>(fileName);
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
            UsedPoints += budget.Points;
        }

        [RelayCommand]
        public async void Delete(object b)
        {
            var budget = (Budget)b;

            string fileName = "Activities.txt";
            List<Budget> dailyActivities = await FileManager.GetObjectFromTxt<List<Budget>>(fileName);

            int removeIndex = dailyActivities.FindIndex(b => b.Name == budget.Name);
            dailyActivities.RemoveAt(removeIndex);
            FileManager.WriteObjectToFile(fileName, dailyActivities);
            MyDailyActivitiesList.Remove(budget);
            UsedPoints -= budget.Points;
            string path = FileManager.GetFilePath(fileName);
            if (!MyDailyActivitiesList.Any())
            {
                File.Delete(path);
            }
        }

        [RelayCommand]
        public async static void Save()
        {
            string fileName = "Activities.txt";
            List<Budget> dailyActivities = await FileManager.GetFoundExistingFile<List<Budget>>(fileName, "Du har inte lagt till några aktiviteter");

            bool answer = await InputManager.ConfirmSave(dailyActivities);
        
            if (answer == true)
            {
                FileManager.SaveDailyActivitiesToFile(dailyActivities);
 
                FileManager.DeleteFileWhenSaved(fileName);
            }
            else
            {
                return;
            }
        }

    }
}

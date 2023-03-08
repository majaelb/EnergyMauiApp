using CommunityToolkit.Mvvm.ComponentModel;
using EnergyMauiapp.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using static System.Net.Mime.MediaTypeNames;
using EnergyMauiapp.Helpers;

namespace EnergyMauiapp.ViewModels
{
    internal partial class CurrentDailyBudgetPageViewModel : ObservableObject
    {
        [ObservableProperty]
        string tips;

        [ObservableProperty]
        string name;

        [ObservableProperty]
        int totalBudget;

        [ObservableProperty]
        ObservableCollection<Budget> myChosenActivities;


        public Header Header { get; set; }
        public CurrentDailyBudgetPageViewModel()
        {
            string fileName = "MyDailyBudget.txt";
            var task = Task.Run(() =>  FileManager.GetObjectFromTxt<DailyBudget>(fileName));
            task.Wait();
            TotalBudget = task.Result.TotalDailyBudget;
            MyChosenActivities = task.Result.ChosenActivities;
            

            Tips = ListManager.AddOneRandomTips();
            Header = new Header()
            {
                Title = "Nuvarande dagsbudget",
                HeaderImageSource = "flowersheader.jpg"
            };
        }
    }
}

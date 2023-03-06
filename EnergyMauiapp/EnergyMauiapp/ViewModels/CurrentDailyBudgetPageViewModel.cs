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
            string json = File.ReadAllText(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "MyDailyBudget.txt"));
            DailyBudget dailyBudget = JsonSerializer.Deserialize<DailyBudget>(json);

            TotalBudget = dailyBudget.TotalDailyBudget;
            MyChosenActivities = dailyBudget.ChosenActivities;

            Tips = Helpers.ListManager.AddOneRandomTips();
            Header = new Header()
            {
                Title = "Nuvarande dagsbudget",
                HeaderImageSource = "flowersheader.jpg"
            };
        }
    }
}

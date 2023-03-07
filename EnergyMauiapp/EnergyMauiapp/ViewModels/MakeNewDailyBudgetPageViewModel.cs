using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using EnergyMauiapp.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;
using System.Text.Json;
using EnergyMauiapp.Helpers;

namespace EnergyMauiapp.ViewModels
{
    internal partial class MakeNewDailyBudgetPageViewModel : ObservableObject
    {
        static UserSingleton user = UserSingleton.GetUserSessionData();


        [ObservableProperty]
        string tips;

        [ObservableProperty]
        string name;

        [ObservableProperty]
        int points;

        [ObservableProperty]
        ObservableCollection<Budget> budgetList;

        [ObservableProperty]
        ObservableCollection<Budget> myBudgetList;

        public Header Header { get; set; }
        public MakeNewDailyBudgetPageViewModel()
        {
            BudgetList = ListManager.MakeBudgetList();

            MyBudgetList = new ObservableCollection<Budget>();

            Tips = ListManager.AddOneRandomTips();

            Header = new Header()
            {
                Title = "Ny dagsbudget",
                HeaderImageSource = "flowersheader.jpg"
            };
        }

        [RelayCommand]
        public void Add(object b)
        {
            var budget = (Budget)b;
            MyBudgetList.Add(budget);
            user.MyBudget += budget.Points; //Använder Singleton-instansen
        }

        [RelayCommand]
        public void Delete(object b)
        {
            var budget = (Budget)b;
            MyBudgetList.Remove(budget);
            user.MyBudget -= budget.Points; //Använder Singleton-instansen
        }

        [RelayCommand]
        public void Save()
        {
            var myDailyBudget = new DailyBudget()
            {
                TotalDailyBudget = user.MyBudget, //Använder Singleton-instansen
                ChosenActivities = MyBudgetList
            };
            string fileName = "MyDailyBudget.txt";
            string path = FileManager.GetFilePath(fileName);
            FileManager.WriteObjectToFile(path, myDailyBudget);
        }
    }
}

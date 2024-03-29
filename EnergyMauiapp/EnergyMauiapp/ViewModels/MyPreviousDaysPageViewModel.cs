﻿using CommunityToolkit.Mvvm.ComponentModel;
using EnergyMauiapp.Helpers;
using EnergyMauiapp.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnergyMauiapp.ViewModels
{
    internal partial class MyPreviousDaysPageViewModel : ObservableObject
    {
        [ObservableProperty]
        public ObservableCollection<DailyEvent> myDailyActivitiesList; //Visar alla sparade dagar med date, dailybudget, usedbudgetpoints, samt lista med aktiviteterna för den dagen

        [ObservableProperty]
        DateTime date;

        [ObservableProperty]
        int dailyBudget;

        [ObservableProperty]
        int usedBudgetPoints;

        [ObservableProperty]
        ObservableCollection<Budget> myActivities; //Lista med sparade aktiviteter per dag (detaljerad vy)

        [ObservableProperty] //Hör ihop med listan ovan
        string name;

        [ObservableProperty] //Hör ihop med listan ovan
        int points;

        [ObservableProperty]
        string tips;

        [ObservableProperty]
        Header header;


        public MyPreviousDaysPageViewModel()
        {
            var task = Task.Run(() => GetSavedActivities());
            task.Wait();

            MyDailyActivitiesList = new ObservableCollection<DailyEvent>();
            foreach (var activity in task.Result.AsEnumerable().OrderByDescending(x => x.Date)) 
            {
                MyDailyActivitiesList.Add(activity);
            }

            Tips = ListManager.AddOneRandomTips();
            Header = new Header()
            {
                Title = "Mina tidigare dagar",
                HeaderImageSource = "flowersheader.jpg"
            };
        }

        public static async Task<List<DailyEvent>> GetSavedActivities()
        {
            string fileName = "DatePointsAndActivity.txt";
            List<DailyEvent> activitiesFromTxt = await FileManager.GetObjectFromTxt<List<DailyEvent>>(fileName);
            return activitiesFromTxt;
        }  
    }
}

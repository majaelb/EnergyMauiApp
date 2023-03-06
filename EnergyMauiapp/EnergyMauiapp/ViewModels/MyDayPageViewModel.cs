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
        ObservableCollection<Budget> myDailyActivitiesList;


        public Header Header { get; set; }

        public MyDayPageViewModel()
        {
            //TODO: Metod för att räkna ut dagens budget i förhållande till gårdagens aktiviteter
            //Hämtar json med all info för att kunna visa min dagsbudget. 
            //string json = File.ReadAllText(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "DailyBudget.txt"));
            //DailyBudget dailyBudget = JsonSerializer.Deserialize<DailyBudget>(json);
            //TotalBudget = dailyBudget.TotalDailyBudget;

            ActivityList = Helpers.ListManager.MakeBudgetList();

            MyDailyActivitiesList = new ObservableCollection<Budget>();
            //TODO: Listan som visas ska inte vara new obs.coll. utan deserialiseras från listan som sparats via add nedan
            //productsFromDb.ForEach(x => Products.Add(x)); Kolla i codealongen från shoppen när vi la till nya
            //activitiesFromJson.ForEach(myDailyActivitiesList.Add); OnAppearing? Hämta från j-sonfilen med sparade aktiviteter för dagen och lägg till i obesrvablecollection


            Tips = Helpers.ListManager.AddOneRandomTips();
            Header = new Header()
            {
                Title = "Min dag",
                HeaderImageSource = "flowersheader.jpg"
            };
        }


     

        public List<Budget> GetSavedActivitiesFromTxt()
        {
            string json = File.ReadAllText(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Activities.txt"));
            List<Budget> activitiesFromTxt = JsonSerializer.Deserialize<List<Budget>>(json);

            return activitiesFromTxt;
        }

        public async Task GetSavedActivities()
        {
            List<Budget> activitiesFromTxt = GetSavedActivitiesFromTxt();
            await Task.Delay(100);
            activitiesFromTxt.ForEach(MyDailyActivitiesList.Add);
        }


        //TODO: Facade: Save daily event? 
        [RelayCommand]
        public void Add(object b)
        {
            var budget = (Budget)b;

            List<Budget> activityList = new()
            {
                budget
            };
            string fileName = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Activities.txt");//address
            if (!File.Exists(fileName))
            {
                string jsonString = JsonSerializer.Serialize(activityList);
                File.WriteAllText(fileName, jsonString);
            }
            else
            {
                string text = File.ReadAllText(fileName);
                var dailyActivities = JsonSerializer.Deserialize<List<Budget>>(text);
                dailyActivities.Add(budget);
                string jsonString = JsonSerializer.Serialize(dailyActivities);
                File.WriteAllText(fileName, jsonString);
            }
        }

        [RelayCommand]
        public void Delete(object b)
        {
            var budget = (Budget)b;
            string fileName = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Activities.txt");
            string text = File.ReadAllText(fileName);
            var dailyActivities = JsonSerializer.Deserialize<List<Budget>>(text);
            int removeIndex = dailyActivities.FindIndex(b => b.Name == budget.Name);
            dailyActivities.RemoveAt(removeIndex);
            string jsonString = JsonSerializer.Serialize(dailyActivities);
            File.WriteAllText(fileName, jsonString);
        }

        [RelayCommand]
        public void Save()
        {
            //Deserialisera hela mydailyactivities-json-textfil, lägg ihop poängen, spara dagens datum samt totalpoängen som json i textfil
            //När det är gjort, töm mydailyactivities och ta bort tillhörande textfil så att inget ligger kvar till nästa dag
            //TODO: Clicked = displayalert "dina aktiviteter för dagen är sparade"

        }
    }
}

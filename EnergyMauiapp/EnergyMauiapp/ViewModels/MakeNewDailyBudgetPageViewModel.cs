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

namespace EnergyMauiapp.ViewModels
{
    internal partial class MakeNewDailyBudgetPageViewModel : ObservableObject
    {
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
            BudgetList = new ObservableCollection<Budget>()
            {
                new Budget{ Name = "Ta på kläder", Points = 1 },
                new Budget{ Name = "Ta mediciner", Points = 1 },
                new Budget{ Name = "Titta på TV", Points = 1 },
                new Budget{ Name = "Duscha", Points = 1 },
                new Budget{ Name = "Fixa hår/smink", Points = 2 },
                new Budget{ Name = "Surfa på internet", Points = 2 },
                new Budget{ Name = "Läsa/studera", Points = 2 },
                new Budget{ Name = "Tillaga och äta mat", Points = 2 }

            };

            MyBudgetList = new ObservableCollection<Budget>();

            Tips = Helpers.ListManager.AddOneRandomTips();

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
            User.MyBudget += budget.Points;    
        }
        //Spara till en icke-statisk lista när man trycker på spara? samt totalresultatet så att det finns tillgängligt även nästa gång appen öppnas

        //{1, new EnergyBudget("Get out of bed", _getOutOfBed) },
        //        {2, new EnergyBudget("Get dressed", _getDressed) },
        //        { 3, new EnergyBudget("Take pills", _takePills) },
        //        { 4, new EnergyBudget("Watch TV", _watchTV) },
        //        { 5, new EnergyBudget("Shower", _shower) },
        //        { 6, new EnergyBudget("Make up and hair", _makeupHair) },
        //        { 7, new EnergyBudget("Surf the internet", _surfInternet) },
        //        { 8, new EnergyBudget("Read or study", _readStudy) },
        //        { 9, new EnergyBudget("Make and eat meal", _makeEatMeal) },
        //        { 10, new EnergyBudget("Plan and socialize", _planAndSocialize) },
        //        { 11, new EnergyBudget("Light housework", _lightHousework) },
        //        { 12, new EnergyBudget("Drive car", _driveCar) },
        //        { 13, new EnergyBudget("Work", _work) },
        //        { 14, new EnergyBudget("Go shopping", _goShopping) },
        //        { 15, new EnergyBudget("Go to doctor", _goToDoctor) },
        //        { 16, new EnergyBudget("Exercise", _exercise) },

        
    }
}

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
                new Budget{ Name = "Gå upp ur sängen", Points = 1 },
                new Budget{ Name = "Ta på kläder", Points = 1 },
                new Budget{ Name = "Ta mediciner", Points = 1 },
                new Budget{ Name = "Titta på TV", Points = 1 },
                new Budget{ Name = "Duscha", Points = 2 },
                new Budget{ Name = "Fixa hår/smink", Points = 2 },
                new Budget{ Name = "Surfa på internet", Points = 2 },
                new Budget{ Name = "Läsa/studera", Points = 2 },
                new Budget{ Name = "Tillaga och äta mat", Points = 3 },
                new Budget{ Name = "Planera och socialisera", Points = 3 },
                new Budget{ Name = "Lätt hushållsarbete", Points = 3 },
                new Budget{ Name = "Köra bil", Points = 3 },
                new Budget{ Name = "Arbeta", Points = 4 },
                new Budget{ Name = "Shoppa", Points = 4 },
                new Budget{ Name = "Vårdbesök", Points = 4 },
                new Budget{ Name = "Lättare träning", Points = 4 }
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

        [RelayCommand]
        public void Delete(object b)
        {
            var budget = (Budget)b;
            MyBudgetList.Remove(budget);
            User.MyBudget -= budget.Points;
        }

        [RelayCommand]
        public void Save()
        {
            //TODO: Spara som Json i txt-fil med en parameter för resultatet(nuvarande budget) och en parameter(lista budget.Name) för alla valda
            //aktiviteter för att komma åt den aktuella dagsbudgeten även nästa gång?
            //Nästa gång en ny budget görs så skrivs denna över så att bara den senaste finns tillgänglig?  
        }



    }
}

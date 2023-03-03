using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnergyMauiapp.Models
{

    //TODO: Använd singleton med en instans istället för detta?
    //TODO: Implementera Facade eller annat mönster nånstans?
    internal static class User
    {
        public static double EstResult;
        public static Dictionary<DateTime, double> DateAndEstimationResult = new();
        public static List<SelfEstimation> SelfEstimations = new();
        public static int MyBudget;
        public static Dictionary<int, ObservableCollection<Budget>> BudgetAndChosenActivities = new();
    }
}

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnergyMauiapp.Models
{
    internal class DailyBudget
    {
        public int TotalDailyBudget { get; set; }
        public ObservableCollection<Budget> ChosenActivities { get; set; }
    }
}

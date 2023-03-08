using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnergyMauiapp.Models
{
    class DailyEvent
    {
        public DateTime Date { get; set; } 
        public int DailyBudget { get; set; } //totalbudgeten för dagen, med eventuella avdrag borträknade
        public int UsedBudgetPoints { get; set; } //så många poäng man gjorde av med denna dag
        public List<Budget> MyActivities { get; set; } //lista av aktiviteter, med namn och poäng
    }
}

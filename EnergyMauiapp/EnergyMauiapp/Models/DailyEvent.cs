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
        //public ObservableCollection<Budget> ChosenActivities;

        private static readonly DailyEvent _instance = new();

        public static DailyEvent GetDailyEventData()
        {
            return _instance;
        }

    }
}

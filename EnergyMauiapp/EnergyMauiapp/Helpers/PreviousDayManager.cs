using EnergyMauiapp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnergyMauiapp.Helpers
{
    internal class PreviousDayManager
    {
        public static int GetYesterDaysUsedBudgetPoints()
        {
            string fileName = "DateAndUsedPoints.txt";
            List<DailyEvent> datesAndUsedPoints = FileManager.GetObjectFromTxt<List<DailyEvent>>(fileName);
            int yesterDaysUsedPoints = datesAndUsedPoints.Last().BudgetPoints;

            return yesterDaysUsedPoints;
        }

        public static int GetYesterDaysDayOfYear()
        {
            string fileName = "DateAndUsedPoints.txt";
            List<DailyEvent> datesAndUsedPoints = FileManager.GetObjectFromTxt<List<DailyEvent>>(fileName);
            int yesterDaysDayOfYear = datesAndUsedPoints.Last().Date.DayOfYear;

            return yesterDaysDayOfYear;
        }
    }
}

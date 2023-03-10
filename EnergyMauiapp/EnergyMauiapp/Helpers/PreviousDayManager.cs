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
        public static async Task<int> GetYesterDaysUsedBudgetPoints()
        {
            string fileName = "DatePointsAndActivity.txt";
            List<DailyEvent> datesAndUsedPoints = await FileManager.GetObjectFromTxt<List<DailyEvent>>(fileName);
            int yesterDaysUsedPoints = datesAndUsedPoints.Last().UsedBudgetPoints;

            return yesterDaysUsedPoints;
        }

        public static async Task<int> GetYesterDaysDayOfYear()
        {
            string fileName = "DatePointsAndActivity.txt";
            List<DailyEvent> datesAndUsedPoints = await FileManager.GetObjectFromTxt<List<DailyEvent>>(fileName);
            int yesterDaysDayOfYear = datesAndUsedPoints.Last().Date.DayOfYear;

            return yesterDaysDayOfYear;
        }
    }
}

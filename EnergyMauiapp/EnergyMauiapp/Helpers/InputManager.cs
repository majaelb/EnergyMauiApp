using EnergyMauiapp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace EnergyMauiapp.Helpers
{
    class InputManager
    {
        public static bool RegexCheck(string pattern, string text)
        {
            Regex regex = new(pattern);

            MatchCollection matches = regex.Matches(text);

            if (matches.Any())
            {
                return true;
            }
            return false;
        }

        public static string GetTextResult(double result)
        {
            string text = "";
            if (result <= 10)
                text = "Inga problem";
            else if (result > 10 && result <= 14.5)
                text = "Mild mental trötthet";
            else if (result > 14.5 && result <= 20)
                text = "Måttlig mental trötthet";
            else if (result > 20)
                text = "Svår mental trötthet";

            return text;
        }

        public static async Task<bool> ConfirmSave(List<Budget> dailyActivities)
        {
            bool answer = false;

            if (dailyActivities != null)
            {
                answer = await Application.Current.MainPage.DisplayAlert("Confirm", "Är du säker på att du vill spara alla dagens aktiviteter? Du kan inte spara något mer för denna dag.", "OK", "Avbryt");
            }
            if (answer == true)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}

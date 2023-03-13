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
    }
}

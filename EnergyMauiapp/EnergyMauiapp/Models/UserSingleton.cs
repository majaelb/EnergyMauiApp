using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnergyMauiapp.Models
{
    internal class UserSingleton
    {
        public int MyBudget = 0;
        public double EstResult = 0;

        private static readonly UserSingleton _instance = new();

        public static UserSingleton GetUserSessionData()
        {
            return _instance;
        }


    }
}

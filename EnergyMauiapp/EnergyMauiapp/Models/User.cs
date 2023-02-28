using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnergyMauiapp.Models
{
    internal static class User
    {
        public static double EstResult;
        public static Dictionary<DateTime, double> DateAndResult = new();
        public static List<SelfEstimation> SelfEstimations = new();
    }
}

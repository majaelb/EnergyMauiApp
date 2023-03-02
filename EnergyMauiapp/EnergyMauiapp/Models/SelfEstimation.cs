using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnergyMauiapp.Models
{
    internal class SelfEstimation
    {
        //TODO: Använda denna klass och de/serialisera lista ist för Dictionary i resultat?
        public DateTime Date { get; set; }

        public double Result { get; set; }

        public string Text { get; set; }
    }
}

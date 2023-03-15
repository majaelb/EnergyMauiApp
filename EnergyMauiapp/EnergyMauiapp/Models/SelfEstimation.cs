using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Color = Microsoft.Maui.Graphics.Color;

namespace EnergyMauiapp.Models
{
    internal class SelfEstimation
    {
        public DateTime Date { get; set; }

        public double Result { get; set; }
        public string Text { get; set; }
        //public Microsoft.Maui.Graphics.Color Color { get; set; }
        public Color Color { get; set; }
    }
}

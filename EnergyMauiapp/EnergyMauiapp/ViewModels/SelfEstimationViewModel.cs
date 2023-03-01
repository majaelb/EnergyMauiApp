using EnergyMauiapp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnergyMauiapp.ViewModels
{
    internal class SelfEstimationViewModel
    {
        public List<SelfEstimation> SelfEstimationQuestions { get; set; }
        public Header Header { get; set; }
        public SelfEstimationViewModel()
        {
            Header = new Header()
            {
                Title = "Självskattning",
                HeaderImageSource = "flowersheader.jpg"
            };
        }

    }
}

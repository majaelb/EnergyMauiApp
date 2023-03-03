using EnergyMauiapp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using static System.Net.Mime.MediaTypeNames;
using CommunityToolkit.Mvvm.ComponentModel;

namespace EnergyMauiapp.ViewModels
{
    internal partial class PreviousSelfEstimationPageViewModel : ObservableObject
    {
        [ObservableProperty]
        string tips;

        public Header Header { get; set; }
        public Dictionary<DateTime, double> SelfEstimationResults { get; set; }
        //public List<SelfEstimation> SelfEstimations { get; set; }

        public PreviousSelfEstimationPageViewModel()
        {
            string json = File.ReadAllText(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Skattningsresultaten.txt"));
            SelfEstimationResults = JsonSerializer.Deserialize<Dictionary<DateTime, double>>(json);
            //SelfEstimations = JsonSerializer.Deserialize<List<SelfEstimation>>(json);
            //TODO: Ändra till klass med lista att serialisera?
            Tips = Helpers.ListManager.AddOneRandomTips();

            Header = new Header()
            {
                Title = "Resultat självskattningar",
                HeaderImageSource = "flowersheader.jpg"
            };
        }
    }
}

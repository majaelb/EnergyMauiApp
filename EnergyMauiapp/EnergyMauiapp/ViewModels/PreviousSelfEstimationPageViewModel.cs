using EnergyMauiapp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using static System.Net.Mime.MediaTypeNames;

namespace EnergyMauiapp.ViewModels
{
    internal class PreviousSelfEstimationPageViewModel
    {
        public Dictionary<DateTime, double> SelfEstimationResults { get; set; }
        //public List<SelfEstimation> SelfEstimations { get; set; }

        public PreviousSelfEstimationPageViewModel()
        {
            string json = File.ReadAllText(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Skattningsresultaten.txt"));
            SelfEstimationResults = JsonSerializer.Deserialize<Dictionary<DateTime, double>>(json);
            //SelfEstimations = JsonSerializer.Deserialize<List<SelfEstimation>>(json);
            //foreach(var item in SelfEstimationResults)
            //{
            //    if(item.Value <= 10)
                    
            //}
        }
    }
}

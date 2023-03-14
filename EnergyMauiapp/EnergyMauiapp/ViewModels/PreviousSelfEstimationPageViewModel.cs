using EnergyMauiapp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using static System.Net.Mime.MediaTypeNames;
using CommunityToolkit.Mvvm.ComponentModel;
using EnergyMauiapp.Helpers;

namespace EnergyMauiapp.ViewModels
{
    internal partial class PreviousSelfEstimationPageViewModel : ObservableObject
    {
        [ObservableProperty]
        string tips;

        public Header Header { get; set; }
        public Dictionary<DateTime, double> SelfEstimationResults { get; set; }

        public PreviousSelfEstimationPageViewModel()
        {
            string fileName = "Skattningsresultaten.txt";
            var selfEstResults = Task.Run(() => FileManager.GetObjectFromTxt<Dictionary<DateTime, double>>(fileName));
            selfEstResults.Wait();
            SelfEstimationResults = selfEstResults.Result;
            //foreach (KeyValuePair<DateTime, double> kvp in selfEstResults.Result.OrderByDescending(kvp => kvp.Key))
            //{
            //    SelfEstimationResults.Add(kvp.Key, kvp.Value);
            //}

            //SelfEstimationResults = (KeyValuePair<DateTime, double>)selfEstResults.Result.AsEnumerable().OrderByDescending(p => p.Key);
            //TODO: Hur sortera resultaten?
            
            Tips = Helpers.ListManager.AddOneRandomTips();

            Header = new Header()
            {
                Title = "Resultat självskattningar",
                HeaderImageSource = "flowersheader.jpg"
            };
        }
    }
}

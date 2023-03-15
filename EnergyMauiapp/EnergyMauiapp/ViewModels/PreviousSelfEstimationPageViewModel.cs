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
using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Maui.Graphics;

namespace EnergyMauiapp.ViewModels
{
    internal partial class PreviousSelfEstimationPageViewModel : ObservableObject
    {
        [ObservableProperty]
        string tips;

        public Header Header { get; set; }
        public Dictionary<DateTime, double> SelfEstimationResults { get; set; }

        [ObservableProperty]
        ObservableCollection<SelfEstimation> selfEstimations;

        [ObservableProperty]
        DateTime date;

        [ObservableProperty]
        double result;

        [ObservableProperty]
        string text;

        [ObservableProperty]
        Color color;

        public PreviousSelfEstimationPageViewModel()
        {
            SelfEstimations = new ObservableCollection<SelfEstimation>();

            string fileName = "testmedsystem.txt";
            var selfEstResults = Task.Run(() => FileManager.GetObjectFromTxt<List<SelfEstimation>>(fileName));
            selfEstResults.Wait();
            foreach (var activity in selfEstResults.Result.AsEnumerable().OrderByDescending(x => x.Date))
            {
                SelfEstimations.Add(activity);
            }
            //Fullösning för att sätta rätt färg på resultaten
            foreach (var item in SelfEstimations)
            {
                if (item.Result <= 10)
                    item.Color = Color.FromArgb("#3CB371");
                else if (item.Result > 10 && item.Result <= 14.5)
                    item.Color = Color.FromArgb("#6495ED");
                else if (item.Result > 14.5 && item.Result <= 20)
                    item.Color = Color.FromArgb("#FFFF00");
                else if (item.Result > 20)
                    item.Color = Color.FromArgb("#DB7093");
            }

            Tips = ListManager.AddOneRandomTips();

            Header = new Header()
            {
                Title = "Resultat självskattningar",
                HeaderImageSource = "flowersheader.jpg"
            };
        }

        

        [RelayCommand]
        public async void Delete(object b)
        {
            var selfEst = (SelfEstimation)b;

            string fileName = "testmedsystem.txt";
            List<SelfEstimation> selfEstimations = await FileManager.GetObjectFromTxt<List<SelfEstimation>>(fileName);
            int removeIndex = selfEstimations.FindIndex(b => b.Date == selfEst.Date);
            selfEstimations.RemoveAt(removeIndex);
            FileManager.WriteObjectToFile(fileName, selfEstimations);
            SelfEstimations.Remove(selfEst);
            
        }
    }
}

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

            var task = Task.Run(() => ListManager.GetOrderedAndColoredList());
            task.Wait();
            task.Result.ForEach(SelfEstimations.Add);
     
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

            string fileName = "minaSkattningsResultat.txt";
            List<SelfEstimation> selfEstimations = await FileManager.GetObjectFromTxt<List<SelfEstimation>>(fileName);
            int removeIndex = selfEstimations.FindIndex(b => b.Date == selfEst.Date);
            selfEstimations.RemoveAt(removeIndex);
            FileManager.WriteObjectToFile(fileName, selfEstimations);
            SelfEstimations.Remove(selfEst);

        }
    }
}

﻿using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using EnergyMauiapp.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;


namespace EnergyMauiapp.ViewModels
{
    internal partial class FactsAndLinksPageViewModel : ObservableObject
    {
        public IRelayCommand OpenUrlCommand => new RelayCommand<string>(LaunchBrowser);


        [ObservableProperty]
        string tips;

        [ObservableProperty]
        ObservableCollection<string> links;
        public Header Header { get; set; }

        public FactsAndLinksPageViewModel()
        {
            Tips = Helpers.ListManager.AddOneRandomTips();
            Links = MakeLinkList();
            Header = new Header()
            {
                Title = "Fakta och länkar",
                HeaderImageSource = "flowersheader.jpg"
            };
        }

        private async void LaunchBrowser(string url)
        {
            //Debug.WriteLine($"*** Tap: {url}");

            await Browser.OpenAsync(url);
        }

        public static ObservableCollection<string> MakeLinkList()
        {
            ObservableCollection<string> links = new()
            {
            "https://brainfatigue.se/behandling-mindfulness/",
            "https://www.gu.se/forskning/mental-trotthet-hjarntrotthet"
            };
            return links;
        }

    }
}

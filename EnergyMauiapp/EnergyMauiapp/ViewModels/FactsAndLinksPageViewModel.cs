using CommunityToolkit.Mvvm.ComponentModel;
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


        public FactsAndLinksPageViewModel()
        {
            Tips = Helpers.ListManager.AddOneRandomTips();
        }

        private async void LaunchBrowser(String url)
        {
            Debug.WriteLine($"*** Tap: {url}");

            await Browser.OpenAsync(url);
        }

    }
}

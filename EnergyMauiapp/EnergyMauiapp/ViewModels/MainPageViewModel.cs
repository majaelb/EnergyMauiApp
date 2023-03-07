using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using EnergyMauiapp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EnergyMauiapp.Helpers;

namespace EnergyMauiapp.ViewModels
{
    internal partial class MainPageViewModel : ObservableObject
    {
        [ObservableProperty]
        string tips;

        public Header Header { get; set; }

        public MainPageViewModel()
        {
            Tips = ListManager.AddOneRandomTips();
            Header = new Header()
            {
                Title = "Energiappen",
                HeaderImageSource = "flowersheader.jpg"
            };
        }
    }
}

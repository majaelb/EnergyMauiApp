using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EnergyMauiapp.Models;
using System.Collections.ObjectModel;
using EnergyMauiapp.Helpers;
using CommunityToolkit.Mvvm.Input;
using AngleSharp.Text;

namespace EnergyMauiapp.ViewModels
{
    internal partial class NewSelfEstViewModel : ObservableObject
    {
        [ObservableProperty]
        string tips;

        public Header Header { get; set; }
        public NewSelfEstViewModel()
        {
            Tips = ListManager.AddOneRandomTips();
            Header = new Header()
            {
                Title = "Ny självskattning",
                HeaderImageSource = "flowersheader.jpg"
            };
        }

    }
}

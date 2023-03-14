using CommunityToolkit.Mvvm.ComponentModel;
using EnergyMauiapp.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EnergyMauiapp.Models;

namespace EnergyMauiapp.ViewModels
{
    internal partial class MyDayStartPageViewModel : ObservableObject
    {
        [ObservableProperty]
        string tips;

        public Header Header { get; set; }

        public MyDayStartPageViewModel()
        {
            Tips = ListManager.AddOneRandomTips();
            Header = new Header()
            {
                Title = "Min dag",
                HeaderImageSource = "flowersheader.jpg"
            };
        }
    }
}

using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EnergyMauiapp.Models;

namespace EnergyMauiapp.ViewModels
{
    internal partial class YouTubePageViewModel : ObservableObject
    {
        [ObservableProperty]
        string tips;

        public Header Header { get; set; }
        public YouTubePageViewModel()
        {
            Tips = Helpers.ListManager.AddOneRandomTips();
            Header = new Header()
            {
                Title = "Meditationer",
                HeaderImageSource = "flowersheader.jpg"
            };
        }
    }
}

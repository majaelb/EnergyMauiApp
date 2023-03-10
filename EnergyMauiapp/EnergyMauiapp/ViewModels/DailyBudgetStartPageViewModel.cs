using CommunityToolkit.Mvvm.ComponentModel;
using EnergyMauiapp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EnergyMauiapp.Helpers;

namespace EnergyMauiapp.ViewModels
{
    internal partial class DailyBudgetStartPageViewModel : ObservableObject
    {
        [ObservableProperty]
        string tips;
        public Header Header { get; set; }
        public DailyBudgetStartPageViewModel()
        {
            Tips = ListManager.AddOneRandomTips();
            Header = new Header()
            {
                Title = "Dagsbudget",
                HeaderImageSource = "flowersheader.jpg"
            };
        }
    }
}

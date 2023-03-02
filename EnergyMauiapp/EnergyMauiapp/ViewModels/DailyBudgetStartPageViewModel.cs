using CommunityToolkit.Mvvm.ComponentModel;
using EnergyMauiapp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnergyMauiapp.ViewModels
{
    internal partial class DailyBudgetStartPageViewModel : ObservableObject
    {
        [ObservableProperty]
        string tips;
        public Header Header { get; set; }
        public DailyBudgetStartPageViewModel()
        {
            Tips = Helpers.ListManager.AddOneRandomTips();
            Header = new Header()
            {
                Title = "Dagsbudget",
                HeaderImageSource = "flowersheader.jpg"
            };
        }
    }
}

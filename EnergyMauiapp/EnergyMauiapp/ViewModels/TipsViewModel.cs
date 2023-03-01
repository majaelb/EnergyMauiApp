using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using EnergyMauiapp.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnergyMauiapp.ViewModels
{
    internal partial class TipsViewModel : ObservableObject
    {
        [ObservableProperty]
        ObservableCollection<string> tipsList;

        public TipsViewModel()
        {
            TipsList = new ObservableCollection<string>();
        }

        public void AddOneRandomTips()
        {
            Random rnd = new();
            List<string> list = MakeTipsList();
            int index = rnd.Next(list.Count);
            if (TipsList.Any())
            {
                TipsList.Clear();
            }
            TipsList.Add(list[index]);
        }

        public static List<string> MakeTipsList()
        {
            List<string> tips = new()
            {
            "Använd öronproppar och solglasögon om ljud och ljus tar energi.",
            "Se till att ha blåljusfilter aktiverat på dina skärmar. Speciella glasögon finns också för behovet.",
            "Kom ihåg att vila små stunder även under roliga aktiviteter.",
            "Handla via nätet istället för i affären om mycket intryck gör dig trött",
            "Om du kan jobba hemifrån - gör det så slipper du bli av med energin det tar att resa." ,
            "Ät regelbundet under dagen." ,
            "Lagom mängd fysisk aktivitet är bra. Känn efter vad som är lagom för just dig." ,
            "Planera dina dagar och veckor, så att aktiviteten blir jämnt fördelad efter din ork." ,
            "Om du är sjuk eller har sovit dåligt så har du mindre energi, begär inte lika mycket av dig själv dessa dagar."
            };
            return tips;
        }
    }
}

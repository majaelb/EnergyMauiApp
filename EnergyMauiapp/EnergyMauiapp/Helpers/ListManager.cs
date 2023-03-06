using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EnergyMauiapp.Models;

namespace EnergyMauiapp.Helpers
{
    internal class ListManager
    {

        public static string AddOneRandomTips()
        {
            Random rnd = new();
            List<string> list = MakeTipsList();
            int index = rnd.Next(list.Count);

            return list[index];
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

        public static ObservableCollection<Budget> MakeBudgetList()
        {
            var budgetList = new ObservableCollection<Budget>()
            {
                new Budget{ Name = "Gå upp ur sängen", Points = 1 },
                new Budget{ Name = "Ta på kläder", Points = 1 },
                new Budget{ Name = "Ta mediciner", Points = 1 },
                new Budget{ Name = "Titta på TV", Points = 1 },
                new Budget{ Name = "Duscha", Points = 2 },
                new Budget{ Name = "Fixa hår/smink", Points = 2 },
                new Budget{ Name = "Surfa på internet", Points = 2 },
                new Budget{ Name = "Läsa/studera", Points = 2 },
                new Budget{ Name = "Tillaga och äta mat", Points = 3 },
                new Budget{ Name = "Planera och socialisera", Points = 3 },
                new Budget{ Name = "Lätt hushållsarbete", Points = 3 },
                new Budget{ Name = "Köra bil", Points = 3 },
                new Budget{ Name = "Arbeta", Points = 4 },
                new Budget{ Name = "Shoppa", Points = 4 },
                new Budget{ Name = "Vårdbesök", Points = 4 },
                new Budget{ Name = "Lättare träning", Points = 4 }
            };

            return budgetList;
        }


        public static List<string> MakeLinkList()
        {
            List<string> links = new()
            {
            "https://brainfatigue.se/behandling-mindfulness/",
            "https://www.gu.se/forskning/mental-trotthet-hjarntrotthet"
            };
            return links;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnergyMauiapp.Models
{
    internal class Tips
    {
        public string Tip { get; set; }

        public static List<Tips> MakeTipsList()
        {
            List<Tips> tips = new()
        {
            new Tips() { Tip = "Använd öronproppar och solglasögon om ljud och ljus tar energi." },
            new Tips() { Tip = "Se till att ha blåljusfilter aktiverat på dina skärmar. Speciella glasögon finns också för behovet." },
            new Tips() { Tip = "Kom ihåg att vila små stunder även under roliga aktiviteter." },
            new Tips() { Tip = "Handla via nätet istället för i affären om mycket intryck gör dig trött" },
            new Tips() { Tip = "Om du kan jobba hemifrån - gör det så slipper du bli av med energin det tar att resa." },
            new Tips() { Tip = "Ät regelbundet under dagen." },
            new Tips() { Tip = "Lagom mängd fysisk aktivitet är bra. Känn efter vad som är lagom för just dig." },
            new Tips() { Tip = "Planera dina dagar och veckor, så att aktiviteten blir jämnt fördelad efter din ork." },
            new Tips() { Tip = "Om du är sjuk eller har sovit dåligt så har du mindre energi, begär inte lika mycket av dig själv dessa dagar."}
        };
            return tips;
        }
    }
}

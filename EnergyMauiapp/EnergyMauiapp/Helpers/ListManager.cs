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

        public static List<SelfEstTest> MakeQuestionList()
        {
            List<SelfEstTest> questionsAndOptions = new()
            {
                new SelfEstTest
                {
                    Question = "[1] TRÖTTHET\r\nHar du känt dig trött den senaste månaden? Det spelar ingen roll om det är fysisk (muskulär trötthet)\r\neller trött i huvudet. Om det nyligen hänt något ovanligt (t.ex. en olycka eller tillfällig sjukdom) skall du\r\nförsöka bortse från det.",
                    AnswerOptions = "\r\n0 Jag har inte alls känt mig trött (aldrig onormalt trött, inte behövt vila mer än vanligt).\r\n0.5\r\n1 Jag har varit trött flera gånger per dag, men jag blir klart piggare av att vila.\r\n1.5\r\n2 Jag har känt mig trött större delen av dagen, och vila har ingen eller liten effekt.\r\n2.5\r\n3 Jag har känt mig trött all vaken tid, och vila har ingen effekt."
                },
                 new SelfEstTest
                {
                    Question = "[2] OFÖRETAGSAMHET\r\nHar du svårt att sätta igång med saker? Känner du dig oföretagsam och tar det emot när du skall sätta\r\nigång med något, oavsett om det är en ny uppgift eller om det gäller saker du gör varje dag.",
                    AnswerOptions = "0 Jag har inga svårigheter med att ta itu med saker.\r\n0.5\r\n1 Jag har svårare än tidigare för att sätta igång med aktiviteter. Jag skjuter gärna på det.\r\n1.5\r\n2 Det krävs en stor ansträngning för att jag skall ta itu med saker. Detta gäller även vardagliga ting\r\nsom att stiga ur sängen, tvätta mig, äta.\r\n2.5\r\n3 Jag kan inte få de enklaste vardagliga saker (äta, klä på mig) gjorda. Jag måste ha hjälp med allt."
                },
                 new SelfEstTest
                {
                    Question = "[3] MENTAL UTTRÖTTBARHET\r\nBlir du snabbt trött ”i huvudet” när hjärnan måste arbeta? Blir du mentalt trött av saker som att läsa,\r\ntitta på TV eller delta i samtal med flera personer. Måste du ta pauser eller byta aktivitet?\r\n",
                    AnswerOptions = "0 Jag kan hålla på lika länge som vanligt. Min uthållighet för ”hjärnarbete” har inte minskat.\r\n0.5\r\n1 Jag blir lättare trött men kan utföra lika mycket ”hjärnarbete” som är normalt för mig.\r\n1.5\r\n2 Jag blir lätt trött och måste ta pauser eller göra något annat oftare än vanligt.\r\n2.5\r\n3 Jag har så lätt för att bli trött att jag inte kan göra någonting, eller måste avbryta alla aktiviteter\r\nefter en kort stund (ca 5 minuter)."
                },
                  new SelfEstTest
                {
                    Question = "[4] MENTAL ÅTERHÄMTNING\r\nHur lång tid tar det för dig att återhämta dig efter att du har arbetat tills du fullständigt tappat förmågan\r\natt kunna koncentrera dig på det du gör.",
                    AnswerOptions = "\r\n0 Jag behöver mindre än en timmes vila för att kunna fortsätta arbeta.\r\n0.5\r\n1 Jag måste vila mer än en timme, men behöver inte en natts sömn.\r\n1.5\r\n2 Jag behöver en natts sömn för att kunna fortsätta arbeta.\r\n2.5\r\n3 Jag behöver flera dagars vila för att återhämta mig."
                },
                   new SelfEstTest
                {
                    Question = "[5] KONCENTRATIONSSVÅRIGHETER\r\nHar du svårt att samla tankarna och koncentrera dig?",
                    AnswerOptions = "0 Jag har lika lätt som vanligt för att samla tankarna.\r\n0.5\r\n1 Jag kan ibland tappa bort mig, t.ex. när jag läser eller tittar på TV.\r\n1.5\r\n2 Jag har så svårt att koncentrera mig så att det besvärar mig när jag t.ex. läser en dagstidning eller\r\ndeltar i samtal med flera personer.\r\n2.5\r\n3 Jag har alltid så svårt att koncentrera mig att det är nästan omöjligt att göra någonting."
                },
                    new SelfEstTest
                {
                    Question = "[6] MINNESSTÖRNINGAR\r\nGlömmer du oftare än tidigare och behöver du minneslappar, eller måste leta mer hemma eller på\r\narbetet?",
                    AnswerOptions = "0 Jag har inga problem med minnet.\r\n0.5\r\n1 Jag glömmer saker lite oftare än vad jag tycker att jag borde, men kan klara mig om jag använder\r\nminneslappar.\r\n1.5\r\n2 Mitt dåliga minne orsakar regelbundet besvär (t.ex. genom att jag glömmer viktiga möten eller\r\nspisen).\r\n2.5\r\n3 Jag kan nästan inte komma ihåg någonting.\r\n"
                },
                     new SelfEstTest
                {
                    Question = "[7] TANKETRÖGHET\r\nKänner du dig trög eller långsam i tankearbetet? Detta gäller känslan av att det tar ovanligt lång tid för\r\natt avsluta en tankegång eller för att lösa en uppgift som kräver tankearbete.",
                    AnswerOptions = "0 Jag känner mig inte trög eller långsam i mina tankar vid ”hjärnarbete”.\r\n0.5\r\n1 Jag kan känna en viss tröghet någon eller några gånger om dagen vid krävande tankearbete.\r\n1.5\r\n2 Jag känner mig ofta trög och långsam i tanken även vid vardagliga sysslor t.ex. i samtal med en\r\nperson eller vid läsning av dagstidningen.\r\n2.5\r\n3 Jag känner mig alltid väldigt trög och långsam i tanken."
                },
                      new SelfEstTest
                {
                    Question = "[8] STRESSKÄNSLIGHET\r\nHar du haft svårt att hantera stress, alltså att göra många saker samtidigt och under tidspress?",
                    AnswerOptions = "\r\n0 Jag klarar stress lika bra som vanligt.\r\n0.5\r\n1 Jag är mer lättstressad, men bara i krävande situationer som jag tidigare klarade av.\r\n1.5\r\n2 Jag blir stressad lättare än vanligt. Det krävs mindre stressade situationer än tidigare för att jag\r\nskall känna av det.\r\n2.5\r\n3 Jag har väldigt lätt för att bli stressad. Så fort som situationen är ovan eller påfrestande känner\r\njag mig stressad."
                },
                       new SelfEstTest
                {
                    Question = "[9] ÖKAD KÄNSLOSAMHET\r\nHar du ovanligt lätt för att gråta? Faller du lätt i gråt när du t.ex. ser en sorglig film eller när du pratar\r\nmed dina anhöriga. Om det nyligen hänt något ovanligt (t.ex. en olycka eller sjukdom) skall du försöka\r\nbortse från det.",
                    AnswerOptions = "0 Jag är inte mera känslig än tidigare.\r\n0.5\r\n1 Jag har en ökad känslighet som fortfarande är naturlig för mig. Jag har lätt att börja gråta eller\r\nfår tårar i ögonen, men det händer bara för ting som engagerar mig starkt.\r\n1.5\r\n2 Min känslighet är besvärande eller generande. Det händer att jag börjar gråta även för saker jag\r\negentligen inte bryr mig om. Jag försöker undvika vissa situationer på grund av detta.\r\n2.5\r\n3 Min känslighet orsakar stora problem för mig. Den stör min dagliga relation även i den nära\r\nfamiljen och gör att jag har svårt att klara mig utanför hemmet.\r\n"
                },
                        new SelfEstTest
                {
                    Question = "[10] IRRITABILITET ELLER ”KORT STUBIN”\r\nÄr du ovanligt lättretad eller lättirriterad för saker som du tidigare tyckte var bagateller.",
                    AnswerOptions = "0 Jag är inte mer lättretad eller irritabel än tidigare.\r\n0.5\r\n1 Jag blir lätt irriterad men det går fort över.\r\n1.5\r\n2 Jag blir väldigt fort irriterad för bagateller eller för saker som andra inte bryr sig om.\r\n2.5\r\n3 Jag reagerar med en intensiv ilska, eller känsla av raseri. Jag har svårt att behärska den.\r\n"
                },
                         new SelfEstTest
                {
                    Question = "[11] ÖVERKÄNSLIGHET FÖR LJUS\r\nÄr du känslig för starkt ljus?",
                    AnswerOptions = "0 Jag har ingen ökad känslighet för ljus.\r\n0.5\r\n1 Ibland kan jag ha svårt för starkt ljussom t.ex. solljus, reflexer från snö eller vatten eller glasrutor,\r\nstarka lampor inomhus, men det kan lätt avhjälpas, t.ex. med solglasögon.\r\n1.5\r\n2 Jag är så känslig för ljus att jag föredrar att uträtta mina dagliga aktiviteter i dämpad belysning.\r\nJag har svårt att gå ut utan solglasögon.\r\n2.5\r\n3 Min ljuskänslighet är så svår att jag inte kan gå ut utan solglasögon. Jag har ständigt neddragna\r\ngardiner (eller motsvarande)."
                },
                          new SelfEstTest
                {
                    Question = "[12] ÖVERKÄNSLIGHET FÖR LJUD\r\nÄr du känslig för ljud?",
                    AnswerOptions = "0 Jag besväras inte av någon ökad känslighet för ljud.\r\n0.5\r\n1 Ibland kan jag ha svårt för starka ljud (t.ex. musik, ljud från TV eller radion, eller plötsliga\r\noväntade ljud), men det kan lätt åtgärdas genom att jag sänker ljudnivån. Min ljudkänslighet stör\r\nmig inte i mitt dagliga liv.\r\n1.5\r\n2 Jag är klart ljudöverkänslig. Jag måste undvika starka ljud eller dämpa (t ex med öronproppar)\r\ndem för att klara mitt dagliga liv.\r\n2.5\r\n3 Min ljudkänslighet är så svår att jag har svårt att klara mig hemma trots ljuddämpning."
                },
                           new SelfEstTest
                {
                    Question = "[13] MINSKAD NATTSÖMN\r\nSover du dåligt om nätterna? Om din nattsömn har ökat, skattas detta som ”0”. Om du tar\r\nsömntabletter och sover normalt, skattas detta som 0.\r\n",
                    AnswerOptions = "0 Jag sover inte sämre än vanligt.\r\n0.5\r\n1 Jag har lite svårt att somna eller min sömn är kortare, ytligare eller oroligare än normalt.\r\n1.5\r\n2 Jag sover minst två timmar mindre än vanligt, och vaknar ofta på natten även utan yttre\r\nstörningar.\r\n2.5\r\n3 Jag sover mindre än två till tre timmar per natt."
                },
                            new SelfEstTest
                {
                    Question = "[14] ÖKAD SÖMN\r\nSover du mer och/eller djupare än vanligt? Om din sömn har minskat markeras detta som ”0”.\r\nObs! Räkna in även sömn dagtid.",
                    AnswerOptions = "0 Jag sover inte mer än vanligt.\r\n0.5\r\n1 Jag sover längre eller tyngre, men inte så mycket som två timmar mer än vanligt, inklusive\r\ntupplurar.\r\n1.5\r\n2 Jag sover längre eller tyngre. Minst två timmar längre än vanligt, inklusive tupplurar.\r\n2.5\r\n3 Jag sover längre eller tyngre. Minst 4 timmar längre än vanligt och behöver dessutom sova\r\ndagtid."
                }

            };
            return questionsAndOptions;
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

using EnergyMauiapp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnergyMauiapp.Helpers
{
    internal class FileManager
    {
        //Ta bort files och ha bara txt-filen på datorn, använd sedan endast filename
        //private static readonly string path = "..\\..\\..\\Files\\";
        //Objekt som heter frågeenkät, med frågor, svar osv (props) Gör lista av det, serialisera till Json. Spara den i textfilen. För att få tillbaka, deserialisera
        private static readonly string path1 = "C:\\Users\\majal\\OneDrive\\Dokument\\System22\\Arkitektur av applikationer i .NET C#\\V 7 Fjärde veckan\\MauiApp1\\MauiApp1\\Files\\";

        public static async Task<List<SelfEstimation>> SplitFileToStringListAsync(string fileName)
        {
            List<SelfEstimation> list = new();
            string text = await File.ReadAllTextAsync(path1 + fileName);
            string[] splitText = text.Split("|");

            foreach (var item in splitText)
            {
                list.Add(new SelfEstimation()
                {
                    Question = item
                });
            }
            return list;
        }
    }
}

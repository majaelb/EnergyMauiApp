using EnergyMauiapp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;

namespace EnergyMauiapp.Helpers
{
    internal class FileManager
    {
        public static List<T> GetListFromTxt<T>(string fileName)
        {
            string json = File.ReadAllText(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), fileName));
            List<T> activitiesFromTxt = JsonSerializer.Deserialize<List<T>>(json);

            return activitiesFromTxt;
        }

        public static void WriteToFile<T>(string fileName, List<T> list)
        {
            string path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), fileName);
            string jsonString = JsonSerializer.Serialize(list);

            File.WriteAllText(path, jsonString);
        }
    }
}

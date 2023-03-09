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

        public static string GetFilePath(string fileName)
        {
            string path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), fileName);

            return path;
        }
      
        public static async Task<T> GetObjectFromTxt<T>(string fileName)
        {
            string path = GetFilePath(fileName);
            string json = await File.ReadAllTextAsync(path);
            T obj = JsonSerializer.Deserialize<T>(json);

            return obj;
        }

        public static async void WriteObjectToFile<T>(string fileName, T obj)
        {
            string path = GetFilePath(fileName);
            string jsonString = JsonSerializer.Serialize(obj);

            await File.WriteAllTextAsync(path, jsonString);
        }

        
    }
}

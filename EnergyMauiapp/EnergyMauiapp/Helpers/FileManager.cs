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
      
        //TODO: ändra allt till async, som anropar denna
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

        //public static void WriteListToFile<T>(string fileName, List<T> list)
        //{
        //    string path = GetFilePath(fileName);
        //    string jsonString = JsonSerializer.Serialize(list);

        //    File.WriteAllText(path, jsonString);
        //}


        //public static List<T> GetListFromTxt<T>(string fileName)
        //{
        //    string path = GetFilePath(fileName);
        //    string json = File.ReadAllText(path);
        //    List<T> list = JsonSerializer.Deserialize<List<T>>(json);

        //    return list;
        //}
    }
}

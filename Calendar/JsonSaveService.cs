using System;
using System.IO;
using System.Text.Json;
using DriversLicense.Calendar;

namespace DriversLicense.Save
{
    public class JsonSaveService : ISaveService
    {
        private readonly string _mainDirectory =
            Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "SaveData");

        public JsonSaveService()
        {
            if (!Directory.Exists(_mainDirectory))
            {
                Directory.CreateDirectory(_mainDirectory);
            }
            Console.WriteLine("Save directory: " + _mainDirectory);
        }

        public bool Serialize<T>(T obj) where T : ISaveObject
        {
            try
            {
                string json = JsonSerializer.Serialize(obj);
                string path = Path.Combine(_mainDirectory, obj.FileName + ".json");
                File.WriteAllText(path, json);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public T Deserialize<T>(string fileName) where T : ISaveObject, new()
        {
            string path = Path.Combine(_mainDirectory, fileName + ".json");

            if (!File.Exists(path))
            {
                return new T();
            }

            string json = File.ReadAllText(path);
            T result = JsonSerializer.Deserialize<T>(json);
            return result;
        }

        public bool Delete(string fileName)
        {
            string path = Path.Combine(_mainDirectory, fileName + ".json");

            if (!File.Exists(path))
            {
                return false;
            }

            File.Delete(path);
            return true;
        }
    }
}
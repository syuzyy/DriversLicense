using DriversLicense.Save;
using System.Collections.Generic;


namespace DriversLicense.Calendar
{
    public interface ISaveService
    {
        bool Serialize<T>(T obj) where T : ISaveObject;
        T Deserialize<T>(string fileName) where T : ISaveObject, new();
        bool Delete(string fileName);

    }


    /*public class JsonSaveService : ISaveService
    {
        
        private readonly string _mainDirectory = Path.Combine(App)
        public bool Serialize<T>(T obj) where T : ISaveObject
        {
            try
            {
                var json :string = 
            }
        }
    }*/
}

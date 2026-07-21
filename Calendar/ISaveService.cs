using System.Collections.Generic;


namespace DriversLicense.Calendar
{
    public interface ISaveService
    {
        void Save(List<ReserveInfo> reservedDays);
        List<ReserveInfo> Load();


        //bool Serialize<T>(T obj);
        //T Deseialize<T>();

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

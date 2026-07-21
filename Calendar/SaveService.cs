using System;
using System.Collections.Generic;
using System.IO;

namespace DriversLicense.Calendar
{
    public class SaveService : ISaveService
    {
        private string filePath = "reserved_days.txt";

        public void Save(List<ReserveInfo> reservedDays)
        {
            List<string> lines = new List<string>();

            foreach (ReserveInfo info in reservedDays)
            {
                lines.Add(info.UserId + ";" + info.Day.ToString("yyyy-MM-dd"));
            }

            File.WriteAllLines(filePath, lines);
        }

        public List<ReserveInfo> Load()
        {
            List<ReserveInfo> reservedDays = new List<ReserveInfo>();

            if (!File.Exists(filePath))
            {
                return reservedDays;
            }

            string[] lines = File.ReadAllLines(filePath);

            foreach (string line in lines)
            {
                string[] parts = line.Split(';');

                int userId = int.Parse(parts[0]);

                DateTime day = DateTime.Parse(parts[1]);

                reservedDays.Add(new ReserveInfo { UserId = userId, Day = day });
            }

            return reservedDays;
        }
    }
}
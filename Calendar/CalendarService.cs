using System;
using System.Collections.Generic;
using DriversLicense.Save;

namespace DriversLicense.Calendar
{
    public class CalendarService : ICalendarService
    {
        private ReservationsData data;
        private ISaveService saveService;

        public CalendarService(ISaveService saveService)
        {
            this.saveService = saveService;
            data = saveService.Deserialize<ReservationsData>("reservations");
        }

        public void ReserveDays(string userName, DateTime day)
        {
            ReserveInfo info = new ReserveInfo();
            info.UserName = userName;
            info.Day = day.Date;
            data.Reservations.Add(info);
            saveService.Serialize(data);
        }

        public bool IsFree(DateTime day)
        {
            foreach (ReserveInfo info in data.Reservations)
            {
                if (info.Day == day.Date)
                {
                    return false;
                }
            }
            return true;
        }

        public List<DateTime> GetAvailableDays(int year, int month)
        {
            int daysInMonth = DateTime.DaysInMonth(year, month);
            List<DateTime> freeDays = new List<DateTime>();

            for (int day = 1; day <= daysInMonth; day++)
            {
                DateTime current = new DateTime(year, month, day);
                if (IsFree(current))
                {
                    freeDays.Add(current);
                }
            }

            return freeDays;
        }

        public void ClearAll()
        {
            saveService.Delete("reservations");

            data = new ReservationsData();
        }
    }
}
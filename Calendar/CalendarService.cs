using System;

namespace DriversLicense.Calendar
{
    public class CalendarService : ICalendarService
    {
        private List<ReserveInfo> reservedDays = new List<ReserveInfo>();
        private ISaveService saveService;

        public CalendarService(ISaveService saveService)
        {
            this.saveService = saveService;
            reservedDays = saveService.Load();
        }

        public void ReserveDays(int UserId, DateTime day)
        {
            ReserveInfo info = new ReserveInfo();
            info.UserId = UserId;
            info.Day = day;
            reservedDays.Add(info);

            saveService.Save(reservedDays);

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

        public bool IsFree(DateTime day)
        {
            foreach (ReserveInfo info in reservedDays)
            {
                if (info.Day == day.Date)
                {
                    return false;
                }
            }
            return true;
        }
    }
}
using System;

namespace DriversLicense.Calendar
{
    public interface ICalendarService
    {
        public List<DateTime> GetAvailableDays(int year, int month);
        public void ReserveDays(int UserId, DateTime day);
        public bool IsFree(DateTime day);
    }
}

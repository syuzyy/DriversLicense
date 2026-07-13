using System;

namespace DriversLicense
{
    public class CalendarService
    {
        private List<DateTime> bookedDays = new List<DateTime>();


        public List<DateTime> GetFreeDays(int year, int month)
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
            return !bookedDays.Contains(day.Date);
        }

        public void Book(DateTime day)
        {
            bookedDays.Add(day.Date);
        }
    }
}
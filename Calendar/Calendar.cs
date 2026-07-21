using DriversLicense.Service;
using System;
using System.Collections.Generic;

namespace DriversLicense.Calendar
{
    public class Calendar : BaseView
    {
        private int year;
        private int month;
        private List<DateTime> freeDays;

        public override void Setup(IViewService navigator)
        {
            year = DateTime.Now.Year;
            month = DateTime.Now.Month;
            freeDays = ServiceContainer.Instance.calendarService.GetAvailableDays(year, month);
        }

        public override void Show(IViewService navigator)
        {
            Console.WriteLine($"Calendar: {year}-{month:00} --");
            Console.WriteLine("Free days:");

            for (int i = 0; i < freeDays.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {freeDays[i]:dddd, MMMM d}");
            }

            Console.Write("Pick a free day: ");
            string input = Console.ReadLine();

            if (!int.TryParse(input, out int choice) || choice < 1 || choice > freeDays.Count)
            {
                Console.WriteLine("Invalid choice");
            }
            else
            {
                DateTime selected = freeDays[choice - 1];
                ServiceContainer.Instance.calendarService.ReserveDays(userId, selected); //-----------
                Console.WriteLine($"Booked: {selected:dddd, MMMM d, yyyy}");
            }

            Console.WriteLine("1. Next");
            Console.WriteLine("2. Back");
            Console.Write("Choose: ");
            string next = Console.ReadLine();

            if (next == "1") navigator.Show<UserInformation>();
            else if (next == "2") navigator.Show<Reg>();
        }
    }
}
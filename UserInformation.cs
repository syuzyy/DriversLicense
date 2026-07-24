using DriversLicense.Calendar;
using DriversLicense.Service;
using System;
namespace DriversLicense
{
    public class UserInformation : BaseView
    {
        public override void Show(IViewService navigator)
        {
            Console.WriteLine("User Information");
            Console.Write("What's your name? ");

            string name = Console.ReadLine();

            Console.WriteLine($"Hello, {name}!");

            CalendarViewData data = new CalendarViewData
            {
                UserName = name
            };

            navigator.Show<CalendarView>(data);
        }
    }
}
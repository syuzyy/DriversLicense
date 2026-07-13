using System;

namespace DriversLicense
{
    public class Reg : BaseView
    {

        public override void Show(IViewService navigator)
        {
            Console.WriteLine("Register Page (HQB)");
            Console.WriteLine("1. Next ");
            Console.WriteLine("2. Back ");
            Console.Write("Choose: ");

            string choice = Console.ReadLine();

            if (choice == "1") navigator.Show<Calendar>();
            else if (choice == "2") navigator.Show<MainView>();
        }


    }
}

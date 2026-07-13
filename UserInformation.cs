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

            Console.WriteLine("2. Back ");
            Console.WriteLine("0. Exit");
            Console.Write("yiu can choose ");
            string choice = Console.ReadLine();

            if (choice == "1")
            {
                navigator.Show<Calendar>();
            }
            else if (choice == "0")
            {
                Console.WriteLine("exit");
            }
        }
        public override void Hide(IViewService navigator)
        {
            Console.WriteLine("Leave user info");
        }
    }
}

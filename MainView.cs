using DriversLicense.Service;
using System;
namespace DriversLicense
{
    public class MainView : BaseView
    {
        private InputService input = new InputService();
        private IViewService navigator;
        private string choice;

        public override void Show(IViewService navigator)
        {
            this.navigator = navigator;

            Console.WriteLine("This is Main Page");
            Console.WriteLine("1. Register");
            Console.WriteLine("2. Clear all reservations");
            Console.Write("Choose: ");
            choice = Console.ReadLine();

            Console.WriteLine("Press Enter to confirm...");

            input.OnConfirm += HandleChoice;
            input.OnConfirm += Confirmation;
            input.WaitForConfirm();
            input.OnConfirm -= HandleChoice;
            input.OnConfirm -= Confirmation;
        }

        private void HandleChoice()
        {
            if (choice == "1")
            {
                navigator.Show<Reg>();
            }
            else if (choice == "2")
            {
                ServiceContainer.Instance.calendarService.ClearAll();
                Console.WriteLine("All reservations cleared.");
                navigator.Show<MainView>();
            }
        }

        private void Confirmation()
        {
            Console.WriteLine("User confirmed choice");
        }
    }
}
using System;

namespace DriversLicense
{
    public class MainView : BaseView
    {
        private InputService input = new InputService();
        private IViewService navigator;
        public override void Show(IViewService navigator)
        {
            this.navigator = navigator;
            Console.WriteLine("This is Main Page");
            Console.WriteLine("Press Enter to continue to Register...");

            input.OnConfirm += Reg;
            input.OnConfirm += Confirmation;

            input.WaitForConfirm();

            input.OnConfirm -= Reg;
            input.OnConfirm -= Confirmation;


        }
        private void Reg()
        {
            navigator.Show<Reg>();
        }
        private void Confirmation()
        {
            Console.WriteLine("User confirmed choice");
        }

    }
}

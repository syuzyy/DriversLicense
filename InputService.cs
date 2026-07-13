using System;
namespace DriversLicense
{
    public class InputService
    {
        public event Action OnConfirm;

        public void WaitForConfirm()
        {
            while (true)
            {
                ConsoleKeyInfo key = Console.ReadKey(true);
                if (key.Key == ConsoleKey.Enter)
                {
                    OnConfirm?.Invoke();
                    break;
                }
            }
        }
    }
}
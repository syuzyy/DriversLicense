using DriversLicense.Service;
using System;

namespace DriversLicense
{
    public class Program
    {
        static void Main(string[] args)
        {
            IViewService navigator = new ViewService();
            navigator.Show<MainView>();
        }
    }
}

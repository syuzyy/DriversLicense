using DriversLicense.Calendar;
using System;

namespace DriversLicense.Service
{
    public class ViewService : IViewService
    {
        public T Show<T>() where T : BaseView, new()
        {
            T view = new T();
            view.Setup(this);
            view.Show(this);
            view.Hide(this);
            view.Dispose();
            return view;
        }
    }
}

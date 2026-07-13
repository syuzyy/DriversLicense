using System;

namespace DriversLicense
{
    public class ViewService : IViewService
    {
        public CalendarService CalendarService { get; } = new CalendarService();
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

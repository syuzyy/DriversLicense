using System;

namespace DriversLicense
{
    public interface IViewService
    {
        CalendarService CalendarService { get; }
        T Show<T>() where T : BaseView, new();
    }
}
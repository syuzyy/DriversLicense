using DriversLicense.Calendar;
using System;

namespace DriversLicense.Service
{
    public interface IViewService
    {
        T Show<T>() where T : BaseView, new();
    }
}
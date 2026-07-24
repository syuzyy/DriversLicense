using DriversLicense.Calendar;
using System;

namespace DriversLicense.Service
{
    public interface IViewService
    {
        T Show<T>() where T : BaseView, new();
        T Show<T>(IViewData data) where T : BaseView, new();
    }
}
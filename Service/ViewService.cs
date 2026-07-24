using DriversLicense.Service;
using System;
namespace DriversLicense
{
    public class ViewService : IViewService
    {
        public T Show<T>() where T : BaseView, new()
        {
            T view = new T();
            return RunLifecycle(view);
        }

        public T Show<T>(IViewData data) where T : BaseView, new()
        {
            T view = new T();
            view.SetData(data);
            return RunLifecycle(view);
        }

        private T RunLifecycle<T>(T view) where T : BaseView
        {
            using (view)
            {
                view.Setup(this);
                view.Show(this);
                view.Hide(this);
            }
            return view;
        }
    }
}
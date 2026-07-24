using DriversLicense.Service;
using System;

namespace DriversLicense
{
    public class BaseView : IDisposable
    {
        protected IViewData ViewData;
        public virtual void SetData(IViewData data)
        {
            ViewData = data;
        }

        public virtual void Setup(IViewService navigator)
        {
            
        }
        public virtual void Show(IViewService navigator)
        {

        }
        public virtual void Hide(IViewService navigator)
        {
            
        }
        public virtual void Dispose()
        {
            
        }
    }
}

using DriversLicense.Calendar;
using System;
using System.Collections.Generic;
using System.IO;

namespace DriversLicense.Service
{
    public sealed class ServiceContainer
    {
        private static ServiceContainer instance = null;
        public ICalendarService calendarService;
        public ISaveService saveService;

        public static ServiceContainer Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new ServiceContainer();
                }
                return instance;
            }
        }
        public ServiceContainer()
        {
            saveService = new SaveService();
            calendarService = new CalendarService(saveService);
        }
    }
}

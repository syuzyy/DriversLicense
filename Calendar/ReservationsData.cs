using DriversLicense.Save;
using System.Collections.Generic;
namespace DriversLicense.Calendar
{
    public class ReservationsData : ISaveObject
    {
        public List<ReserveInfo> Reservations { get; set; } = new List<ReserveInfo>();
        public string FileName => "reservations";
    }
}
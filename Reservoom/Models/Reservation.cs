using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reservoom.Models
{
    public class Reservation
    {
        public RoomID RoomID { get;}
        public string UserName { get;}
        public DateTime StartDate { get;}
        public DateTime EndDate { get; }
        public TimeSpan Lenght => EndDate.Subtract(StartDate);

        public Reservation(RoomID roomID, string userName, DateTime startTime, DateTime endTime)
        {
            RoomID = roomID;
            StartDate = startTime;
            EndDate = endTime;
            UserName = userName;
        }

        internal bool Conflicts(Reservation reservation)
        {
            if(reservation.RoomID != RoomID)
            {
                return false;
            }
            return reservation.StartDate<EndDate || reservation.EndDate > StartDate;
        }
    }
}

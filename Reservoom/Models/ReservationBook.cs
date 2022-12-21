using Reservoom.Exeptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reservoom.Models
{
    public class ReservationBook
    {
        private readonly List<Reservation> _reservations;

        public ReservationBook()
        {
            _reservations = new List<Reservation>();
        }
            
        public IEnumerable<Reservation> GetReservationsForUser(string userName)
        {
            return _reservations.Where(x => x.UserName == userName);
        }

        public void AddReservation(Reservation reservation)
        {
            foreach (Reservation existingReservation in _reservations)
            {
                if (existingReservation.Conflicts(reservation))
                {
                    throw new ReservationConflictExeption(existingReservation, reservation);
                }
            }
            _reservations.Add(reservation);
        }
    }
}

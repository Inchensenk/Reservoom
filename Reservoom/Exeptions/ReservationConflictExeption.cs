using Reservoom.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Reservoom.Exeptions
{
    public class ReservationConflictExeption : Exception
    {
        public Reservation ExistingReservation { get; }
        public Reservation IncomingReservation { get; }
        public ReservationConflictExeption(Reservation existingReservation, Reservation incomingReservation)
        {
            ExistingReservation = existingReservation;
            IncomingReservation = incomingReservation;
        }

        public ReservationConflictExeption(string? message, Reservation existingReservation, Reservation incomingReservation) : base(message)
        {
            ExistingReservation = existingReservation;
            IncomingReservation = incomingReservation;
        }

        public ReservationConflictExeption(string? message, Exception? innerException, Reservation existingReservation, Reservation incomingReservation) : base(message, innerException)
        {
            ExistingReservation = existingReservation;
            IncomingReservation = incomingReservation;
        }

    }
}

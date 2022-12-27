using Reservoom.Exeptions;
using Reservoom.Services.ReservationCreators;
using Reservoom.Services.ReservationProviders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reservoom.Models
{
    public class ReservationBook
    {
        private readonly IReservationProvider _reservationProvider;
        private readonly IReservationCreator _reservationCreator;

        public ReservationBook(IReservationCreator reservationCreator, IReservationProvider reservationProvider)
        {
            _reservationCreator = reservationCreator;
            _reservationProvider = reservationProvider;
        }

        /// <summary>
        /// Get all reservations.
        /// </summary>
        /// <returns>All reservation in the reservation book.</returns>
        public async IEnumerable<Reservation> GetAllReservations()
        {
            return await _reservationProvider.GetAllReservations();
        }

        /// <summary>
        /// Add a reservation to the reservation book.
        /// </summary>
        /// <param name="reservation">The incoming reservation.</param>
        /// <exception cref="ReservationConflictExeption">Throw if incoming reservation conflicts with existing reservation.</exception>
        public async Task AddReservation(Reservation reservation)
        {
            foreach (Reservation existingReservation in _reservations)
            {
                if (existingReservation.Conflicts(reservation))
                {
                    throw new ReservationConflictExeption(existingReservation, reservation);
                }
            }
            await _reservationCreator.CreateReservation(reservation);
        }
    }
}

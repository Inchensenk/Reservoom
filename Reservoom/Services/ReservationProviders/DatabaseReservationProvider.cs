using Reservoom.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reservoom.Services.ReservationProviders
{
    class DatabaseReservationProvider : IReservationProvider
    {
        public Task<IEnumerable<Reservation>> GetAllReservations()
        {
            throw new NotImplementedException();
        }
    }
}

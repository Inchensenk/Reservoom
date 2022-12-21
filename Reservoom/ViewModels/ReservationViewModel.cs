using Reservoom.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reservoom.ViewModels
{
    public class ReservationViewModel : ViewModelBase
    {
        private readonly Reservation _reservation;

        public string RoomID => _reservation.RoomID?.ToString();
        public string UserName => _reservation.UserName;
        public string StartDate => _reservation.StartDate.ToString("d");//d-краткий формат даты
        public string EndDate => _reservation.EndDate.ToString("d");//d-краткий формат даты

        public ReservationViewModel(Reservation reservation)
        {
            _reservation=reservation;
        }
    }
}

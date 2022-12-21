using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Reservoom.ViewModels
{
    public class MakeReservationViewModel : ViewModelBase
    {
        /// <summary>
        /// Имя пользователя
        /// </summary>
        private string _userName=null!;
        public string UserName
        {
            get => _userName;

            set
            {
                _userName = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// Номер комнаты
        /// </summary>
        private int _roomNumber;
        public int RoomNumber
        {
            get=> _roomNumber;

            set
            {
                _roomNumber = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// Номер этажа
        /// </summary>
        private int _floorNumber;
        public int FloorNumber
        {
            get => _floorNumber;

            set
            {
                _floorNumber = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// Дата вьезда
        /// </summary>
        private DateTime _startDate;
        public DateTime StartDate
        {
            get => _startDate;

            set
            {
                _startDate = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        /// Дата Выезда
        /// </summary>
        private DateTime _endDate;
        public DateTime EndDate
        {
            get => _endDate;

            set
            {
                _endDate = value;
                OnPropertyChanged();
            }
        }


        public ICommand SubmitCommand { get; }
        public ICommand CancelCommand { get; }

        public MakeReservationViewModel()
        {

        }
    }
}

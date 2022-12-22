using Reservoom.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reservoom.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        public ViewModelBase CurrentViewModel { get;}

        public MainWindowViewModel(Hotel hotel)
        {
            //Инициализируем окно которое будет отброжаться при запуске программы
            //CurrentViewModel = new MakeReservationViewModel(hotel);
            CurrentViewModel = new ReservationListingViewModel();
        }
    }
}

using Reservoom.Exeptions;
using Reservoom.Models;
using Reservoom.ViewModels;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace Reservoom
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        /// <summary>
        /// Экземпляр отеля который будет использоваться во всем приложении
        /// </summary>
        private readonly Hotel _hotel;

        public App()
        {
            //Инициализируем отель
            _hotel = new Hotel("Kur Haus");
        }


        //Переопределить при запуске
        protected override void OnStartup(StartupEventArgs e)
        {
            
            /*Заглушка
             * Hotel hotel = new Hotel("Singleton Suites");
            try
            {
                //Бронируем номер
                hotel.MakeReservation(new Reservation(
                    //первый этаж третий номер
                    new RoomID(1, 3),
                    //имя
                    "SingletonSean",
                    //Время вьезда
                    new DateTime(2000, 1, 1),
                    //Время выезда
                    new DateTime(2000, 1, 2)));

                hotel.MakeReservation(new Reservation(
                    //первый этаж третий номер
                    new RoomID(1, 3),
                    //имя
                    "SingletonSean",
                    //Время вьезда
                    new DateTime(2000, 1, 1),
                    //Время выезда
                    new DateTime(2000, 1, 4)));
            }
            catch (ReservationConflictExeption ex)
            {

            }


            IEnumerable<Reservation> reservations = hotel.GetAllReservations("SingletonSean");*/

            MainWindow = new MainWindow()
            {
                DataContext = new MainWindowViewModel(_hotel)
            };

            MainWindow.Show();

            base.OnStartup(e);
        }
    }
}

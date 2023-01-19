using Microsoft.EntityFrameworkCore;
using Reservoom.DbContexts;
using Reservoom.Exeptions;
using Reservoom.Models;
using Reservoom.Services;
using Reservoom.Stores;
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
        private const string CONNECTION_STRING = "Data Source=reservoom.db";
        /// <summary>
        /// Экземпляр отеля который будет использоваться во всем приложении
        /// </summary>
        private readonly Hotel _hotel;
        /// <summary>
        /// Единый навигационный магазин для всего приложения
        /// </summary>
        private readonly NavigationStore _navigationStore;


        public App()
        {
            //Инициализируем отель
            _hotel = new Hotel("Kur Haus");
            _navigationStore=new NavigationStore();

        }


        //Переопределить при запуске
        protected override void OnStartup(StartupEventArgs e)
        {
            DbContextOptions options = new DbContextOptionsBuilder().UseSqlite(CONNECTION_STRING).Options;
            using (ReservoomDbContext dbContext = new ReservoomDbContext(options))
            {
                dbContext.Database.Migrate();
            }

            

            _navigationStore.CurrentViewModel = CreateMakeReservationViewModel();

            MainWindow = new MainWindow()
            {
                DataContext = new MainWindowViewModel(_navigationStore)
            };

            MainWindow.Show();

            base.OnStartup(e);
        }

        private MakeReservationViewModel CreateMakeReservationViewModel()
        {
            return new MakeReservationViewModel(_hotel, new NavigationService( _navigationStore, CreateReservationViewModel));
        }

        private ReservationListingViewModel CreateReservationViewModel()
        {
            return new ReservationListingViewModel(_hotel, new NavigationService(_navigationStore, CreateReservationViewModel));
        }
    }
}

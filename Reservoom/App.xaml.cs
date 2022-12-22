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
            MainWindow = new MainWindow()
            {
                DataContext = new MainWindowViewModel(_hotel)
            };

            MainWindow.Show();

            base.OnStartup(e);
        }
    }
}

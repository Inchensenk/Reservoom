using Reservoom.DbContexts;
using Reservoom.DTOs;
using Reservoom.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reservoom.Services.ReservationCreators
{
    public class DatabaseReservationCreator : IReservationCreator
    {
        private readonly ReservoomDbContextFactory _dbContextFactory = null!;
        public DatabaseReservationCreator(ReservoomDbContextFactory dbContextFactory)
        {
            _dbContextFactory = dbContextFactory;
        }
        public async Task CreateReservation(Reservation reservation)
        {
            using (ReservoomDbContext context = _dbContextFactory.CreateDbContext())
            {
                ReservationDTO reservationDTO = ToReservationDTO(reservation);
                
                //добавление обьекта в бд
                context.Reservations.Add(reservationDTO);
                //сохранение изменений и запись в бд
                await context.SaveChangesAsync();
            }
        }

        /// <summary>
        /// Сопоставление объектов вручную
        /// </summary>
        /// <param name="reservation"></param>
        /// <returns></returns>
        private ReservationDTO ToReservationDTO(Reservation reservation)
        {
            return new ReservationDTO()
            {
                FloorNumber = reservation.RoomID?.FloorNumber ?? 0,
                RoomNumber = reservation.RoomID?.RoomNumber ?? 0,
                UserName = reservation.UserName,
                StartTime = reservation.StartDate,
                EndTime = reservation.EndDate,
            };
        }
    }
}

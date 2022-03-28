using System.Collections.Generic;
using System.Threading.Tasks;
using Hotel.Models;
using Microsoft.EntityFrameworkCore;

namespace Hotel.Data
{
    public class Rooms
    {
        /// <summary>
        /// Асинхронно считаем из базы данных сведения о комнатах
        /// </summary>
        /// <returns>Список комнат</returns>
        public static async Task<List<Room>> GetRooms()
        {
            var rooms = new List<Room>();

            await Task.Run(async () =>
            {
                using (var context = new HotelContext())
                {
                    rooms = await context.Room.AsNoTracking().ToListAsync();
                }
            });

            return rooms;
        }
    }
}

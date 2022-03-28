using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hotel.Models;

namespace Hotel.Extensions
{
    public static class Room
    {
        public static string Values(this Models.Room room)
        {
            return $"Key: {room.RoomIdentifier}\nNumber: " +
                   $"{room.Identifier}\nDate: {room.StartDate:d}\nTime: {room.StartTime:T}";
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel.Extensions
{
    public static class BindingList
    {
        /// <summary>
        /// Get primary key for current row
        /// </summary>
        /// <param name="list"></param>
        /// <param name="position">Current DataGridView row</param>
        /// <returns></returns>
        public static int Identifier(this BindingList<Models.Room> list, int position) => list[position].RoomIdentifier;
        /// <summary>
        /// Get start date for current row
        /// </summary>
        /// <param name="list"></param>
        /// <param name="position">Current DataGridView row</param>
        /// <returns></returns>
        public static DateTime? StartDate(this BindingList<Models.Room> list, int position) => list[position].StartDate;
        /// <summary>
        /// Get start time for current row
        /// </summary>
        /// <param name="list"></param>
        /// <param name="position">Current DataGridView row</param>
        /// <returns></returns>
        public static DateTime? StartTime(this BindingList<Models.Room> list, int position) => list[position].StartTime;
        /// <summary>
        /// Shows values for current row for debug purposes
        /// </summary>
        /// <param name="list"></param>
        /// <param name="position">Current DataGridView row</param>
        /// <returns></returns>
        public static string Values(this BindingList<Models.Room> list, int position)
        {
            var room = list[position];

            return $"Key: {room.RoomIdentifier}\nNumber: " +
                   $"{room.Identifier}\nDate: {room.StartDate:d}\nTime: {room.StartTime:T}";
        }
    }
}

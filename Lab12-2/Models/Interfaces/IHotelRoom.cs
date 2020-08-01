using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lab12_2.Models.Interfaces
{
    public interface IHotelRoom
    {
        /// <summary>
        /// Creates a HotelRoom that is a Room associated with a specific Hotel
        /// </summary>
        /// <param name="hotelRoom">The object to be created</param>
        /// <param name="hotelId">The Hotel that the Room is to be added to</param>
        /// <returns>No Return</returns>
        Task<HotelRoom> Create(HotelRoom hotelRoom, int hotelId);
        /// <summary>
        /// Gets all the Rooms associated with a Hotel
        /// </summary>
        /// <param name="hotelId">The Hotel in which you want to query</param>
        /// <returns>No Return</returns>
        Task<List<HotelRoom>> GetHotelRooms(int hotelId);
        /// <summary>
        /// A Specific Room associated with a Specific hotel that you want to query
        /// </summary>
        /// <param name="hotelId">The Hotel you are querying</param>
        /// <param name="roomNumber">The Room you are querying</param>
        /// <returns>No Return</returns>
        Task<HotelRoom> GetHotelRoom(int hotelId, int roomNumber);
        /// <summary>
        /// Updates the HotelRoom in the database
        /// </summary>
        /// <param name="hotelRoom">The modified HotelRoom that is to replace the current HotelRoom</param>
        /// <returns>No Return</returns>
        Task<HotelRoom> Update(HotelRoom hotelRoom);
        /// <summary>
        /// Deletes the Room attached to the Hotel
        /// </summary>
        /// <param name="hotelId">The Hotel that the room is attached to</param>
        /// <param name="roomNumber">The RoomNumber of the room to be deleted</param>
        /// <returns>No Return</returns>
        Task<HotelRoom> Delete(int hotelId, int roomNumber);
    }
}

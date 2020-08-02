using Lab12_2.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lab12_2.Models.Interfaces
{
    public interface IRoom
    {
        /// <summary>
        /// Creates a Room to be added to the database
        /// </summary>
        /// <param name="room">The Room to be added</param>
        /// <returns>The Room that was added</returns>
        Task<RoomDTO> Create(RoomDTO room);
        /// <summary>
        /// Queries the database for all Rooms
        /// </summary>
        /// <returns>List of all the Rooms in the database</returns>
        Task<List<RoomDTO>> GetRooms();
        /// <summary>
        /// Queries the database to find the Room matching the ID input
        /// </summary>
        /// <param name="id">The ID of the room</param>
        /// <returns>The Room from the database</returns>
        Task<RoomDTO> GetRoom(int id);
        /// <summary>
        /// Updates the Room in the database
        /// </summary>
        /// <param name="room">The object of the Room to be updated</param>
        /// <returns>The updated Room</returns>
        Task<RoomDTO> Update(RoomDTO room);
        /// <summary>
        /// Deletes the Room matching the ID input from the database
        /// </summary>
        /// <param name="id">The ID of the Room to be deleted</param>
        /// <returns>The Deleted Room</returns>
        Task Delete(int id);
        /// <summary>
        /// Adds an Amenity that matches the input ID of Amenity to the Room that matches the input ID of the Room
        /// </summary>
        /// <param name="roomid">The Room that the Amenity is to be added to</param>
        /// <param name="amenityid">The Amenity that is to be added to the Room</param>
        /// <returns>No Return</returns>
        Task AddAmenity(int roomid, int amenityid);
        /// <summary>
        /// Removes an Amenity from a room
        /// </summary>
        /// <param name="roomId">The Room the Amenity is to be removed from</param>
        /// <param name="amenityId">The Amenity that is to be removed</param>
        /// <returns>No Return</returns>
        Task RemoveAmenityFromRoom(int roomId, int amenityId);
    }
}

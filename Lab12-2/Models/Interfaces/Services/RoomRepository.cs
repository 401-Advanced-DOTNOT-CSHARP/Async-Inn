using Lab12_2.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lab12_2.Models.Interfaces.Services
{
    public class RoomRepository : IRoom
    {
        private ASynceInnDbContext _context;

        public RoomRepository(ASynceInnDbContext context)
        {
            _context = context;
        }
        /// <summary>
        /// Creates a Room to be added to the database
        /// </summary>
        /// <param name="room">The Room to be added</param>
        /// <returns>The Room that was added</returns>
        public async Task<Room> Create(Room room)
        {
            _context.Entry(room).State = Microsoft.EntityFrameworkCore.EntityState.Added;
            await _context.SaveChangesAsync();

            return room;
        }
        /// <summary>
        /// Deletes the Room matching the ID input from the database
        /// </summary>
        /// <param name="id">The ID of the Room to be deleted</param>
        /// <returns>The Deleted Room</returns>
        public async Task Delete(int id)
        {
            Room room = await GetRoom(id);
            _context.Entry(room).State = Microsoft.EntityFrameworkCore.EntityState.Deleted;
            await _context.SaveChangesAsync();
        }
        /// <summary>
        /// Queries the database for all Rooms
        /// </summary>
        /// <returns>List of all the Rooms in the database</returns>
        public async Task<List<Room>> GetRooms()
        {
            var rooms = await _context.Rooms
                .Include(x => x.RoomAmenities)
                .ThenInclude(x => x.Amenity)
                .Include(x => x.HotelRoom)
                .ThenInclude(x => x.Hotel)
                .ToListAsync();

            return rooms;
        }
        /// <summary>
        /// Queries the database to find the Room matching the ID input
        /// </summary>
        /// <param name="id">The ID of the room</param>
        /// <returns>The Room from the database</returns>
        public async Task<Room> GetRoom(int id)
        {
            Room room = await _context.Rooms
                .Where(x => x.Id == id)
                .Include(x => x.HotelRoom)
                .ThenInclude(x => x.Hotel)
                .FirstOrDefaultAsync();

            var roomAmenities = await _context.RoomAmenity.Where(x => x.RoomID == id)
                .Include(x => x.Amenity)
                .ToListAsync();
            room.RoomAmenities = roomAmenities;

            return room;
        }
        /// <summary>
        /// Updates the Room in the database
        /// </summary>
        /// <param name="room">The object of the Room to be updated</param>
        /// <returns>The updated Room</returns>
        public async Task<Room> Update(Room room)
        {
            _context.Entry(room).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return room;
        }
        /// <summary>
        /// Adds an Amenity that matches the input ID of Amenity to the Room that matches the input ID of the Room
        /// </summary>
        /// <param name="roomid">The Room that the Amenity is to be added to</param>
        /// <param name="amenityid">The Amenity that is to be added to the Room</param>
        /// <returns>No Return</returns>
        public async Task AddAmenity(int roomid, int amenityid)
        {
            RoomAmenities roomAmenity = new RoomAmenities()
            {
                RoomID = roomid,
                AmenitiesID = amenityid
            };
            _context.Entry(roomAmenity).State = EntityState.Added;
            await _context.SaveChangesAsync();
        }
        /// <summary>
        /// Removes an Amenity from a room
        /// </summary>
        /// <param name="roomId">The Room the Amenity is to be removed from</param>
        /// <param name="amenityId">The Amenity that is to be removed</param>
        /// <returns>No Return</returns>
        public async Task RemoveAmenityFromRoom(int roomId, int amenityId)
        {
            var result = await _context.RoomAmenity.FirstOrDefaultAsync(x => x.RoomID == roomId && x.AmenitiesID == amenityId);
            _context.Entry(result).State = EntityState.Deleted;
            await _context.SaveChangesAsync();
        }
    }
}

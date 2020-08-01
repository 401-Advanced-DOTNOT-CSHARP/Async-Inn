using Lab12_2.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lab12_2.Models.Interfaces.Services
{
    public class HotelRoomRepository : IHotelRoom
    {
            private ASynceInnDbContext _context;

            public HotelRoomRepository(ASynceInnDbContext context)
            {
                _context = context;
            }
        /// <summary>
        /// Creates a HotelRoom that is a Room associated with a specific Hotel
        /// </summary>
        /// <param name="hotelRoom">The object to be created</param>
        /// <param name="hotelId">The Hotel that the Room is to be added to</param>
        /// <returns>No Return</returns>
        public async Task<HotelRoom> Create(HotelRoom hotelRoom, int hotelId)
            {
            hotelRoom.HotelID = hotelId;
                _context.Entry(hotelRoom).State = EntityState.Added;
                await _context.SaveChangesAsync();

                return hotelRoom;
            }
        /// <summary>
        /// Deletes the Room attached to the Hotel
        /// </summary>
        /// <param name="hotelId">The Hotel that the room is attached to</param>
        /// <param name="roomNumber">The RoomNumber of the room to be deleted</param>
        /// <returns>No Return</returns>
        public async Task<HotelRoom> Delete(int hotelId, int roomNumber)
            {
                HotelRoom hotelRoom = await GetHotelRoom(hotelId, roomNumber);
                _context.Entry(hotelRoom).State = EntityState.Deleted;
                await _context.SaveChangesAsync();
            return hotelRoom;
            }
        /// <summary>
        /// Gets all the Rooms associated with a Hotel
        /// </summary>
        /// <param name="hotelId">The Hotel in which you want to query</param>
        /// <returns>No Return</returns>
        public async Task<List<HotelRoom>> GetHotelRooms(int hotelid)
            {
                List<HotelRoom> hotelRoom = await _context.HotelRooms.Where(x => x.HotelID == hotelid)
                .Include(x => x.Room)
                .ThenInclude(x => x.RoomAmenities)
                .ThenInclude(x => x.Amenity)
                .ToListAsync();

                return hotelRoom;
            }
        /// <summary>
        /// A Specific Room associated with a Specific hotel that you want to query
        /// </summary>
        /// <param name="hotelId">The Hotel you are querying</param>
        /// <param name="roomNumber">The Room you are querying</param>
        /// <returns>No Return</returns>
        public async Task<HotelRoom> GetHotelRoom(int hotelId, int roomNumber)
            {
            var result = await _context.HotelRooms
            .Where(x => x.HotelID == hotelId && x.RoomNumber == roomNumber)
            .Include(x => x.Room)
            .ThenInclude(x => x.RoomAmenities)
            .ThenInclude(x => x.Amenity)
            .FirstOrDefaultAsync();
               

                return result;
            }
        /// <summary>
        /// Updates the HotelRoom in the database
        /// </summary>
        /// <param name="hotelRoom">The modified HotelRoom that is to replace the current HotelRoom</param>
        /// <returns>No Return</returns>
        public async Task<HotelRoom> Update(HotelRoom hotelRoom)
            {
                
                _context.Entry(hotelRoom).State = EntityState.Modified;
                await _context.SaveChangesAsync();
                return hotelRoom;
            }
        }
}

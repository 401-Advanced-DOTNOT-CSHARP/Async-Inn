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
        public async Task<Room> Create(Room room)
        {
            _context.Entry(room).State = Microsoft.EntityFrameworkCore.EntityState.Added;
            await _context.SaveChangesAsync();

            return room;
        }

        public async Task Delete(int id)
        {
            Room room = await GetRoom(id);
            _context.Entry(room).State = Microsoft.EntityFrameworkCore.EntityState.Deleted;
            await _context.SaveChangesAsync();
        }

        public async Task<List<Room>> GetRooms()
        {
            var rooms = await _context.Rooms.ToListAsync();

            return rooms;
        }

        public async Task<Room> GetRoom(int id)
        {
            Room room = await _context.Rooms.FindAsync(id);

            var roomAmenities = await _context.RoomAmenity.Where(x => x.RoomID == id).ToListAsync();
            room.RoomAmenities = roomAmenities;

            return room;
        }

        public async Task<Room> Update(Room room)
        {
            _context.Entry(room).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return room;
        }
        /// <summary>
        /// Adds an Amenity to a room
        /// </summary>
        /// <param name="roomid">The room that the amenity that is being added to</param>
        /// <param name="amenityid">The amenity to be added</param>
        /// <returns>nothing</returns>
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

        public async Task RemoveAmenityFromRoom(int roomId, int amenityId)
        {
            var result = await _context.RoomAmenity.FirstOrDefaultAsync(x => x.RoomID == roomId && x.AmenitiesID == amenityId);
            _context.Entry(result).State = EntityState.Deleted;
            await _context.SaveChangesAsync();
        }
    }
}

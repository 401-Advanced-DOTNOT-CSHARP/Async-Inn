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
            public async Task<HotelRoom> Create(HotelRoom hotelRoom, int hotelId)
            {
            hotelRoom.HotelID = hotelId;
                _context.Entry(hotelRoom).State = EntityState.Added;
                await _context.SaveChangesAsync();

                return hotelRoom;
            }

            public async Task<HotelRoom> Delete(int hotelId, int roomNumber)
            {
                HotelRoom hotelRoom = await GetHotelRoom(hotelId, roomNumber);
                _context.Entry(hotelRoom).State = EntityState.Deleted;
                await _context.SaveChangesAsync();
            return hotelRoom;
            }

            public async Task<List<HotelRoom>> GetHotelRooms(int hotelid)
            {
                List<HotelRoom> hotelRoom = await _context.HotelRooms.Where(x => x.HotelID == hotelid)
                .Include(x => x.Room)
                .ThenInclude(x => x.RoomAmenities)
                .ThenInclude(x => x.Amenity)
                .ToListAsync();

                return hotelRoom;
            }

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

            public async Task<HotelRoom> Update(HotelRoom hotelRoom)
            {
                
                _context.Entry(hotelRoom).State = EntityState.Modified;
                await _context.SaveChangesAsync();
                return hotelRoom;
            }
        }
}

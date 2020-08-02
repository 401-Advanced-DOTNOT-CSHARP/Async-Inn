using Lab12_2.Data;
using Lab12_2.Models.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Lab12_2.Models.Interfaces;

namespace Lab12_2.Models.Interfaces.Services
{
    public class HotelRepository : IHotel
    {
        private IHotelRoom _HotelRoom;
        private ASynceInnDbContext _context;

        public HotelRepository(ASynceInnDbContext context, IHotelRoom hotelRoom)
        {
            _context = context;
            _HotelRoom = hotelRoom;
        }
        /// <summary>
        /// Creates a Hotel(POST Route)
        /// </summary>
        /// <param name="hotel">The Hotel to be created</param>
        /// <returns>The Hotel that was created</returns>
        public async Task<HotelDTO> Create(HotelDTO hotelDTO)
        {
            Hotel hotel = new Hotel()
            {
             Name = hotelDTO.Name,
              City = hotelDTO.City,
               Id = hotelDTO.ID,
                PhoneNumber = hotelDTO.Phone,
                 State = hotelDTO.State,
                  StretAddress = hotelDTO.StreetAddress
            };
            _context.Entry(hotel).State = Microsoft.EntityFrameworkCore.EntityState.Added;
            await _context.SaveChangesAsync();

            return hotelDTO;
        }
        /// <summary>
        /// Deletes the Hotel in the database that matches the inputted ID
        /// </summary>
        /// <param name="id">The ID of the Hotel to be deleted</param>
        /// <returns>Deleted Hotel</returns>
        public async Task Delete(int id)
        {
            Hotel hotel = await _context.Hotels.FirstOrDefaultAsync(x => x.Id == id);
            _context.Entry(hotel).State = Microsoft.EntityFrameworkCore.EntityState.Deleted;
            await _context.SaveChangesAsync();
        }
        /// <summary>
        /// Receives all the Hotels in the database
        /// </summary>
        /// <returns>All Hotels in the database</returns>
        public async Task<List<HotelDTO>> GetHotels()
        {
            var hotels = await _context.Hotels.ToListAsync();

            List<HotelDTO> hotelDTO = new List<HotelDTO>();
            foreach(var hotel in hotels)
            {
                hotelDTO.Add(await GetHotel(hotel.Id));
            }

            return hotelDTO;
        }
        /// <summary>
        /// Finds the Hotel that matches the ID
        /// </summary>
        /// <param name="id">The ID of the Hotel to be found</param>
        /// <returns>The requested Hotel</returns>
        public async Task<HotelDTO> GetHotel(int id)
        {
           Hotel hotel = await _context.Hotels.FindAsync(id);
            var hotelRoomDTO = await _HotelRoom.GetHotelRooms(hotel.Id);
            HotelDTO hotelDTO = new HotelDTO()
            {
                ID = hotel.Id,
                Name = hotel.Name,
                StreetAddress = hotel.StretAddress,
                City = hotel.City,
                State = hotel.State,
                Phone = hotel.PhoneNumber,
                 Rooms = hotelRoomDTO
            };
            // TODO: Need to add Navigation properties to HotelDTO
            return hotelDTO;
        }
        /// <summary>
        /// Updates the Hotel with the inputted information
        /// </summary>
        /// <param name="hotel">The Hotel to be updated</param>
        /// <returns>The updated Hotel</returns>
        public async Task<HotelDTO> Update(HotelDTO hotel)
        {
            _context.Entry(hotel).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return hotel;
        }
    }
}

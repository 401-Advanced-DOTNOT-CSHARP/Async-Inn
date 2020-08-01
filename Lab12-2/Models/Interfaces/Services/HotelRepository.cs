using Lab12_2.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lab12_2.Models.Interfaces.Services
{
    public class HotelRepository : IHotel
    {
        private ASynceInnDbContext _context;

        public HotelRepository(ASynceInnDbContext context)
        {
            _context = context;
        }
        /// <summary>
        /// Creates a Hotel(POST Route)
        /// </summary>
        /// <param name="hotel">The Hotel to be created</param>
        /// <returns>The Hotel that was created</returns>
        public async Task<Hotel> Create(Hotel hotel)
        {
            _context.Entry(hotel).State = Microsoft.EntityFrameworkCore.EntityState.Added;
            await _context.SaveChangesAsync();

            return hotel;
        }
        /// <summary>
        /// Deletes the Hotel in the database that matches the inputted ID
        /// </summary>
        /// <param name="id">The ID of the Hotel to be deleted</param>
        /// <returns>Deleted Hotel</returns>
        public async Task Delete(int id)
        {
            Hotel hotel = await GetHotel(id);
            _context.Entry(hotel).State = Microsoft.EntityFrameworkCore.EntityState.Deleted;
            await _context.SaveChangesAsync();
        }
        /// <summary>
        /// Receives all the Hotels in the database
        /// </summary>
        /// <returns>All Hotels in the database</returns>
        public async Task<List<Hotel>> GetHotels()
        {
            var hotels = await _context.Hotels.ToListAsync();

            return hotels;
        }
        /// <summary>
        /// Finds the Hotel that matches the ID
        /// </summary>
        /// <param name="id">The ID of the Hotel to be found</param>
        /// <returns>The requested Hotel</returns>
        public async Task<Hotel> GetHotel(int id)
        {
           Hotel hotel = await _context.Hotels.FindAsync(id);

            return hotel;
        }
        /// <summary>
        /// Updates the Hotel with the inputted information
        /// </summary>
        /// <param name="hotel">The Hotel to be updated</param>
        /// <returns>The updated Hotel</returns>
        public async Task<Hotel> Update(Hotel hotel)
        {
            _context.Entry(hotel).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return hotel;
        }
    }
}

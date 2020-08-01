using Lab12_2.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lab12_2.Models.Interfaces.Services
{
    public class AmenityRepository : IAmenity
    {
        private ASynceInnDbContext _context;

        public AmenityRepository(ASynceInnDbContext context)
        {
            _context = context;
        }
        /// <summary>
        /// Creates an Amenity called by the POST route
        /// </summary>
        /// <param name="amenity">One of the Amenities for the hotel that can be applied to a room</param>
        /// <returns>Amenity</returns>
        public async Task<Amenity> Create(Amenity amenity)
        {
            _context.Entry(amenity).State = Microsoft.EntityFrameworkCore.EntityState.Added;
            await _context.SaveChangesAsync();

            return amenity;
        }
        /// <summary>
        /// Deletes the Amenity that matches the ID given(DELETE Route)
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task Delete(int id)
        {
            Amenity amenity = await GetAmenity(id);
            _context.Entry(amenity).State = Microsoft.EntityFrameworkCore.EntityState.Deleted;
            await _context.SaveChangesAsync();
        }
        /// <summary>
        /// Gets all the Amenities assigned to this hotel in a List(GET Route)
        /// </summary>
        /// <returns>List of Amenities</returns>
        public async Task<List<Amenity>> GetAmenities()
        {
            var amenities = await _context.Amenities
                .Include(x => x.RoomAmenities)
                .ToListAsync();

            return amenities;
        }
        /// <summary>
        /// Gets an Amenity based on the id(GET Route)
        /// </summary>
        /// <param name="id">The unique identifier of the Amenity to be returned</param>
        /// <returns>Amenity</returns>
        public async Task<Amenity> GetAmenity(int id)
        {
            Amenity amenity = await _context.Amenities
                .Where(x => x.Id == id)
                .Include(x => x.RoomAmenities)
                .FirstOrDefaultAsync();

            return amenity;
        }
        /// <summary>
        /// Updates the Amenity with the information provided(PUT Route)
        /// </summary>
        /// <param name="amenity">The Amenity to be updated</param>
        /// <returns>Updated Amenity</returns>
        public async Task<Amenity> Update(Amenity amenity)
        {
            _context.Entry(amenity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return amenity;
        }


    }
}

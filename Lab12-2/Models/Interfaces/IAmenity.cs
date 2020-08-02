using Lab12_2.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lab12_2.Models.Interfaces
{
    public interface IAmenity
    {
        /// <summary>
        /// Creates an Amenity called by the POST route
        /// </summary>
        /// <param name="amenity">One of the Amenities for the hotel that can be applied to a room</param>
        /// <returns>Amenity</returns>
        Task<AmenityDTO> Create(AmenityDTO amenity);
        /// <summary>
        /// Gets all the Amenities assigned to this hotel in a List(GET Route)
        /// </summary>
        /// <returns>List of Amenities</returns>
        Task<List<AmenityDTO>> GetAmenities();
        /// <summary>
        /// Gets an Amenity based on the id(GET Route)
        /// </summary>
        /// <param name="id">The unique identifier of the Amenity to be returned</param>
        /// <returns>Amenity</returns>
        Task<AmenityDTO> GetAmenity(int id);
        /// <summary>
        /// Updates the Amenity with the information provided(PUT Route)
        /// </summary>
        /// <param name="amenity">The Amenity to be updated</param>
        /// <returns>Updated Amenity</returns>
        Task<AmenityDTO> Update(AmenityDTO amenity);
        /// <summary>
        /// Deletes the Amenity that matches the ID given(DELETE Route)
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task Delete(int id);
    }
}

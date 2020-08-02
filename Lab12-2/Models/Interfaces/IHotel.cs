using Lab12_2.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lab12_2.Models.Interfaces
{
    public interface IHotel
    {
        /// <summary>
        /// Creates a Hotel(POST Route)
        /// </summary>
        /// <param name="hotel">The Hotel to be created</param>
        /// <returns>The Hotel that was created</returns>
        Task<HotelDTO> Create(HotelDTO hotel);
       /// <summary>
       /// Receives all the Hotels in the database
       /// </summary>
       /// <returns>All Hotels in the database</returns>
        Task<List<HotelDTO>> GetHotels();
        /// <summary>
        /// Finds the Hotel that matches the ID
        /// </summary>
        /// <param name="id">The ID of the Hotel to be found</param>
        /// <returns>The requested Hotel</returns>
        Task<HotelDTO> GetHotel(int id);
        /// <summary>
        /// Updates the Hotel with the inputted information
        /// </summary>
        /// <param name="hotel">The Hotel to be updated</param>
        /// <returns>The updated Hotel</returns>
        Task<HotelDTO> Update(HotelDTO hotel);
        /// <summary>
        /// Deletes the Hotel in the database that matches the inputted ID
        /// </summary>
        /// <param name="id">The ID of the Hotel to be deleted</param>
        /// <returns>Deleted Hotel</returns>
        Task Delete(int id);
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lab12_2.Models.Interfaces
{
    public interface IHotelRoom
    {
        Task<HotelRoom> Create(HotelRoom hotelRoom, int hotelId);
        Task<List<HotelRoom>> GetHotelRooms(int hotelId);
        Task<HotelRoom> GetHotelRoom(int hotelId, int roomNumber);
        Task<HotelRoom> Update(HotelRoom hotelRoom);
        Task<HotelRoom> Delete(int hotelId, int roomNumber);
    }
}

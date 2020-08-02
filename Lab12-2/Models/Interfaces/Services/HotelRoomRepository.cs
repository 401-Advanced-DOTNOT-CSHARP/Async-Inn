using Lab12_2.Data;
using Lab12_2.Models.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lab12_2.Models.Interfaces.Services
{
    public class HotelRoomRepository : IHotelRoom
    {
        private IAmenity _amenity;
            private ASynceInnDbContext _context;
        private IRoom _room;

            public HotelRoomRepository(ASynceInnDbContext context, IRoom room, IAmenity amenity)
            {
                _context = context;
            _room = room;
            _amenity = amenity;
            }
        /// <summary>
        /// Creates a HotelRoom that is a Room associated with a specific Hotel
        /// </summary>
        /// <param name="hotelRoom">The object to be created</param>
        /// <param name="hotelId">The Hotel that the Room is to be added to</param>
        /// <returns>No Return</returns>
        public async Task<HotelRoomDTO> Create(HotelRoomDTO hotelRoomDTO, int hotelId)
            {
            HotelRoom hotelRoom = new HotelRoom()
            {
                HotelID = hotelRoomDTO.HotelID,
                PetFriendly = hotelRoomDTO.PetFriendly,
                Rate = hotelRoomDTO.Rate,
                RoomNumber = hotelRoomDTO.RoomNumber,
                RoomId = hotelRoomDTO.RoomID
            };
            _context.Entry(hotelRoom).State = EntityState.Added;
            await _context.SaveChangesAsync();

            return hotelRoomDTO;
        }
        /// <summary>
        /// Deletes the Room attached to the Hotel
        /// </summary>
        /// <param name="hotelId">The Hotel that the room is attached to</param>
        /// <param name="roomNumber">The RoomNumber of the room to be deleted</param>
        /// <returns>No Return</returns>
        public async Task<HotelRoomDTO> Delete(int hotelId, int roomNumber)
            {
            HotelRoom hotelRoom = await _context.HotelRooms.FirstOrDefaultAsync(x => x.HotelID == hotelId);
            _context.Entry(hotelRoom).State = EntityState.Deleted;
                await _context.SaveChangesAsync();
            HotelRoomDTO hotelRoomDTO = await TranslateToDTO(hotelRoom);

            return hotelRoomDTO;
            }
        /// <summary>
        /// Gets all the Rooms associated with a Hotel
        /// </summary>
        /// <param name="hotelId">The Hotel in which you want to query</param>
        /// <returns>No Return</returns>
        public async Task<List<HotelRoomDTO>> GetHotelRooms(int hotelid)
            {
                var hotelRoom = await _context.HotelRooms.Where(x => x.HotelID == hotelid)
                .Include(x => x.Room)
                .ThenInclude(x => x.RoomAmenities)
                .ThenInclude(x => x.Amenity)
                .ToListAsync();

            List<HotelRoomDTO> hotelRoomDTO = new List<HotelRoomDTO>();

            foreach(var room in hotelRoom)
            {
                hotelRoomDTO.Add(await GetHotelRoom(room.HotelID, room.RoomNumber));
            }

                return hotelRoomDTO;
            }
        /// <summary>
        /// A Specific Room associated with a Specific hotel that you want to query
        /// </summary>
        /// <param name="hotelId">The Hotel you are querying</param>
        /// <param name="roomNumber">The Room you are querying</param>
        /// <returns>No Return</returns>
        public async Task<HotelRoomDTO> GetHotelRoom(int hotelId, int roomNumber)
            {
            var result = await _context.HotelRooms
            .Where(x => x.HotelID == hotelId && x.RoomNumber == roomNumber)
            .Include(x => x.Room)
            .ThenInclude(x => x.RoomAmenities)
            .ThenInclude(x => x.Amenity)
            .FirstOrDefaultAsync();

            List<AmenityDTO> amenityDTO = new List<AmenityDTO>();

            foreach(var amenity in result.Room.RoomAmenities)
            {
                amenityDTO.Add(await _amenity.GetAmenity(amenity.AmenitiesID));
            }

            RoomDTO roomDTO = new RoomDTO()
            {
                ID = result.Room.Id,
                Name = result.Room.Name,
                Layout = result.Room.Layout,
                Amenities = amenityDTO
            };

            HotelRoomDTO hotelRoomDTO = new HotelRoomDTO()
            {
                HotelID = result.HotelID,
                RoomNumber = result.RoomNumber,
                PetFriendly = result.PetFriendly,
                Rate = result.Rate,
                RoomID = result.RoomId,
                Room = roomDTO
            };
               

                return hotelRoomDTO;
            }
        /// <summary>
        /// Updates the HotelRoom in the database
        /// </summary>
        /// <param name="hotelRoom">The modified HotelRoom that is to replace the current HotelRoom</param>
        /// <returns>No Return</returns>
        public async Task<HotelRoomDTO> Update(HotelRoomDTO hotelRoomDTO)
            {
            HotelRoom hotelRoom = TranslateFromDTO(hotelRoomDTO);
                _context.Entry(hotelRoom).State = EntityState.Modified;
                await _context.SaveChangesAsync();
                return hotelRoomDTO;
            }

        public HotelRoom TranslateFromDTO(HotelRoomDTO hotelRoomDTO)
        {



            HotelRoom hotelRoom = new HotelRoom()
            {
                HotelID = hotelRoomDTO.HotelID,
                PetFriendly = hotelRoomDTO.PetFriendly,
                Rate = hotelRoomDTO.Rate,
                RoomId = hotelRoomDTO.RoomID,
                RoomNumber = hotelRoomDTO.RoomNumber,
            };

            return hotelRoom;
           
        }

        public async Task<HotelRoomDTO> TranslateToDTO(HotelRoom hotelRoom)
        {
            List<AmenityDTO> amenityDTO = new List<AmenityDTO>();

            foreach (var amenity in hotelRoom.Room.RoomAmenities)
            {
                amenityDTO.Add(await _amenity.GetAmenity(amenity.AmenitiesID));
            }

            RoomDTO roomDTO = new RoomDTO()
            {
                ID = hotelRoom.Room.Id,
                Name = hotelRoom.Room.Name,
                Layout = hotelRoom.Room.Layout,
                Amenities = amenityDTO
            };

            HotelRoomDTO hotelRoomDTO = new HotelRoomDTO()
            {
                HotelID = hotelRoom.HotelID,
                RoomNumber = hotelRoom.RoomNumber,
                PetFriendly = hotelRoom.PetFriendly,
                Rate = hotelRoom.Rate,
                RoomID = hotelRoom.RoomId,
                Room = roomDTO
            };




            return hotelRoomDTO;

        }
    }
}

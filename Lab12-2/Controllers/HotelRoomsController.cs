using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Lab12_2.Data;
using Lab12_2.Models;
using Lab12_2.Models.Interfaces;

namespace Lab12_2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HotelRoomsController : ControllerBase
    {
        private readonly IHotelRoom _hotelRoom;

        public HotelRoomsController(IHotelRoom hotelRoom)
        {
            _hotelRoom = hotelRoom;
        }

        // GET: api/HotelRooms
        [HttpGet("/api/Hotels/{hotelId}/Rooms")]
        // /api/Hotels/{hotelId}/Rooms
        public async Task<ActionResult<IEnumerable<HotelRoom>>> GetHotelRooms(int hotelId)
        {
            return await _hotelRoom.GetHotelRooms(hotelId);
        }

        // GET: api/HotelRooms/5
        // /api/Hotels/{hotelId}/Rooms/{roomNumber}
        [HttpGet("/api/Hotels/{hotelId}/Rooms/{roomNumber}")]
        public async Task<ActionResult<HotelRoom>> GetHotelRoom(int hotelId, int roomNumber)
        {
            var hotelRoom = await _hotelRoom.GetHotelRoom(hotelId, roomNumber);

            if (hotelRoom == null)
            {
                return NotFound();
            }

            return hotelRoom;
        }

        // PUT: api/HotelRooms/5
        // /api/Hotels/{hotelId}/Rooms/{roomNumber}
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("/api/Hotels/{hotelId}/Rooms/{roomNumber}")]
        public async Task<IActionResult> PutHotelRoom(int hotelId, int roomNumber, HotelRoom hotelRoom)
        {
            if (hotelId != hotelRoom.HotelID || roomNumber != hotelRoom.RoomNumber)
            {
                return BadRequest();
            }

            await _hotelRoom.Update(hotelRoom);

            return NoContent();
        }

        // POST: api/HotelRooms
        // /api/Hotels/{hotelId}/Rooms
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost("/api/Hotels/{hotelId}/Rooms")]
        public async Task<ActionResult<HotelRoom>> PostHotelRoom(HotelRoom hotelRoom, int hotelId)
        {
            await _hotelRoom.Create(hotelRoom, hotelId);

            return CreatedAtAction("GetHotelRoom", new { id = hotelRoom.HotelID }, hotelRoom);
        }

        // DELETE: api/HotelRooms/5
        // /api/Hotels/{hotelId}/Rooms/{roomNumber}
        [HttpDelete("/api/Hotels/{hotelId}/Rooms/{roomNumber}")]
        public async Task<ActionResult<HotelRoom>> DeleteHotelRoom(int hotelId, int roomNumber)
        {
           HotelRoom hotelRoom = await _hotelRoom.Delete(hotelId, roomNumber);

            if (hotelRoom == null)
            {
                return NotFound();
            }

            return hotelRoom;
        }
    }
}

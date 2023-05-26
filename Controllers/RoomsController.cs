using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClassLibrary1.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using pracapiapp.DB;
using pracapiapp.DTO;
using pracapiapp.Repositories;

namespace pracapiapp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoomsController : ControllerBase
    {
        private readonly IRoomRepository _roomRepository;

        public RoomsController(IRoomRepository roomRepository)
        {
            _roomRepository = roomRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Room>>> GetRooms()
        {
            try
            {
                return await _roomRepository.GetRooms();
            }
            catch (Exception ex)
            {
                return BadRequest("Failed to get rooms. Error message: " + ex.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Room>> GetRoom(int id)
        {
            try
            {

                var room = await _roomRepository.GetRoom(id);


                return room;


            }
            catch (Exception ex)
            {
                return BadRequest("Failed to get room with ID " + id + ". Error message: " + ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutRoom(int id, Room room)
        {
            try
            {
                var result = await _roomRepository.PutRoom(id, room);
                if (result == null)
                {
                    return NotFound("Room not found with ID " + id);
                }
                return Ok("Room with ID " + id + " has been updated successfully");
            }
            catch (Exception ex)
            {
                return BadRequest("Failed to update room with ID " + id + ". Error message: " + ex.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult<Room>> PostRoom(Room room)
        {
            try
            {
                var result = await _roomRepository.PostRoom(room);
                if (result == null)
                {
                    return BadRequest("Failed to create new room");
                }
                return Ok("New room has been created successfully");
            }
            catch (Exception ex)
            {
                return BadRequest("Failed to create new room. Error message: " + ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRoom(int id)
        {
            try
            {
                var result = await _roomRepository.DeleteRoom(id);
                if (result == null)
                {
                    return NotFound("Room not found with ID " + id);
                }
                return Ok("Room with ID " + id + " has been deleted successfully");
            }
            catch (Exception ex)
            {
                return BadRequest("Failed to delete room with ID " + id + ". Error message: " + ex.Message);
            }
        }

        [HttpGet("hotels/available-rooms")]
        public async Task<ActionResult<IEnumerable<AvailableRoomsDTO>>> GetHotelsWithAvailableRooms(string availability)
        {
            try
            {
                return await _roomRepository.GetHotelsWithAvailableRooms(availability);
            }
            catch (Exception ex)
            {
                return BadRequest("Failed to get hotels with available rooms. Error message: " + ex.Message);
            }
        }

        [HttpGet("hotels/rooms-count")]
        public async Task<ActionResult<IEnumerable<RoomCountDTO>>> GetHotelsWithRoomsCount(string availability)
        {
            try
            {
                return await _roomRepository.GetHotelsWithRoomsCount(availability);
            }
            catch (Exception ex)
            {
                return BadRequest("Failed to get hotels with room counts. Error message: " + ex.Message);
            }
        }

    }
}

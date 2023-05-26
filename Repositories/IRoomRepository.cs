using ClassLibrary1.Models;
using Microsoft.AspNetCore.Mvc;
using pracapiapp.DTO;

namespace pracapiapp.Repositories
{
    public interface IRoomRepository
    {
        Task<ActionResult<IEnumerable<Room>>> GetRooms();
        Task<ActionResult<Room>> GetRoom(int id);
        Task<IActionResult> PutRoom(int id, Room room);
        Task<ActionResult<Room>> PostRoom(Room room);
        Task<IActionResult> DeleteRoom(int id);
        Task<ActionResult<IEnumerable<AvailableRoomsDTO>>> GetHotelsWithAvailableRooms(string availability = null);
        Task<ActionResult<IEnumerable<RoomCountDTO>>> GetHotelsWithRoomsCount(string availability = null);
    }
}

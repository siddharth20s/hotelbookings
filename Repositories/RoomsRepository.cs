using ClassLibrary1.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using pracapiapp.DB;
using pracapiapp.DTO;

namespace pracapiapp.Repositories
{
    public class RoomRepository : IRoomRepository
    {
        private readonly HotelResDbContext contextt;

        public RoomRepository(HotelResDbContext context)
        {
            contextt = context;
        }

        public async Task<ActionResult<IEnumerable<Room>>> GetRooms()
        {
            return await contextt.Rooms.Include(x => x.Hotel).ToListAsync();
        }

        public async Task<ActionResult<Room>> GetRoom(int id)
        {

            var room = await contextt.Rooms.FindAsync(id);
            return room;



        }

        public async Task<IActionResult> PutRoom(int id, Room room)
        {
            contextt.Entry(room).State = EntityState.Modified;
            await contextt.SaveChangesAsync();
            return new NoContentResult();
        }

        public async Task<ActionResult<Room>> PostRoom(Room room)
        {
            contextt.Rooms.Add(room);
            await contextt.SaveChangesAsync();
            return new CreatedAtActionResult("GetRoom", "Rooms", new { id = room.Id }, room);
        }

        public async Task<IActionResult> DeleteRoom(int id)
        {
            var room = await contextt.Rooms.FindAsync(id);
            contextt.Rooms.Remove(room);
            await contextt.SaveChangesAsync();
            return new NoContentResult();
        }

        public async Task<ActionResult<IEnumerable<AvailableRoomsDTO>>> GetHotelsWithAvailableRooms(string availability)
        {
            IQueryable<Hotel> query = contextt.Hotels.Include(h => h.Rooms);

            if (!string.IsNullOrEmpty(availability))
            {
                query = query.Where(h => h.Rooms.Any(r => r.Availability == availability));
            }

            var hotels = await query.ToListAsync();

            var result = hotels.Select(h => new AvailableRoomsDTO
            {
                HotelId = h.Id,
                HotelName = h.Name,
                Address = h.Address,
                City = h.City,
                Ratings = h.Ratings,
                Phone = h.Phone,
                AvailableRooms = h.Rooms.Where(r => r.Availability == availability)
                                        .Select(r => new RoomDto
                                        {
                                            RoomId = r.Id,
                                            RoomNumber = r.Number,
                                            Type = r.Type,
                                            Availability = r.Availability,
                                            Price = r.PricePerNight
                                        })
                                        .ToList()
            });

            return new OkObjectResult(new { Hotels = result });
        }



        public async Task<ActionResult<IEnumerable<RoomCountDTO>>> GetHotelsWithRoomsCount(string availability)
        {
            IQueryable<Hotel> query = contextt.Hotels.Include(h => h.Rooms);

            if (!string.IsNullOrEmpty(availability))
            {
                query = query.Where(h => h.Rooms.Any(r => r.Availability == availability));
            }

            var hotels = await query.ToListAsync();

            var result = hotels.Select(h => new RoomCountDTO
            {
                Id = h.Id,
                Name = h.Name,
                Address = h.Address,
                City = h.City,
                Ratings = h.Ratings,
                Phone = h.Phone,
                TotalAvailableRooms = h.Rooms.Count(r => r.Availability == availability)
            });

            return new OkObjectResult(new { Hotels = result });
        }


        private bool RoomExists(int id)
        {
            return (contextt.Rooms?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }


}

using ClassLibrary1.Models;
using Microsoft.EntityFrameworkCore;
using pracapiapp.DTO;

namespace pracapiapp.DB
{
    public class HotelResDbContext : DbContext
    {
        public DbSet<Hotel>? Hotels { get; set; }
        public DbSet<Room>? Rooms { get; set; }
        public DbSet<Employee>? Employees { get; set; }
        public DbSet<Customer>? Customers { get; set; }
        public DbSet<RoomCountDTO>? RoomCountDTO { get; set; }

        
        public HotelResDbContext(DbContextOptions<HotelResDbContext> options) : base(options) { }



    }
}

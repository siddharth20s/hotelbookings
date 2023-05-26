﻿using Microsoft.EntityFrameworkCore;
using pracapiapp.Models;

namespace pracapiapp.DB
{
    public class HotelResDbContext : DbContext
    {
        public DbSet<Hotel>? Hotels { get; set; }
        public DbSet<Room>? Rooms { get; set; }
        public DbSet<Employee>? Employees { get; set; }
        public DbSet<Customer>? Customers { get; set; }

        public HotelResDbContext(DbContextOptions<HotelResDbContext> options) : base(options) { }



    }
}

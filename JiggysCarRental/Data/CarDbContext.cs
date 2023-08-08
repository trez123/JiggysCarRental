
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace JiggysCarRental.Models
{
    public class CarDbContext : IdentityDbContext<IdentityUser>
    {
        public CarDbContext(DbContextOptions<CarDbContext> options) : base(options)
        { }

        public DbSet<Rental> Rentals { get; set; }

        public DbSet<Vehicle> Vehicles { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
    }
}


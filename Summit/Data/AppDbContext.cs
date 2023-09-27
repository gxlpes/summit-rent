using Microsoft.EntityFrameworkCore;
using Summit.Models;
using System.Collections.Generic;

namespace Summit.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Car> Car { get; set; }

        public DbSet<Customer> Customer { get; set; }

        public DbSet<Rent> Rent { get; set; }

        public DbSet<Insurance> Insurance { get; set; }

        public DbSet<Rating> Rating { get; set; }

        public DbSet<Payment> Payment { get; set; }

        public DbSet<Intent> Intent { get; set; }

        public DbSet<Destination> Destination { get; set; }

        public DbSet<Departure> Departure { get; set; }

        public DbSet<Dealership> Dealership { get; set; }

    }
}

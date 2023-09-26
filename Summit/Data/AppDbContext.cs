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

        public DbSet<Car> Car { get; set; }

        public DbSet<Summit.Models.Client> Client { get; set; }

        public DbSet<Summit.Models.Rent> Rent { get; set; }

    }
}

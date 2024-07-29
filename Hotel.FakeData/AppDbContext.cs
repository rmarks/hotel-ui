using Hotel.FakeData.Entities;
using Microsoft.EntityFrameworkCore;

namespace Hotel.FakeData;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions options) : base(options)
    {
    }

    public DbSet<Room> Rooms { get; set; }
}

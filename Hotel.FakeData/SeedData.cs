using Hotel.FakeData.Entities;

namespace Hotel.FakeData;

public class SeedData
{
    public static void Seed(AppDbContext db)
    {
        db.Database.EnsureCreated();

        db.Rooms.AddRange(
            new Room { RoomNo = "101", NumOfBeds = 1 },
            new Room { RoomNo = "102", NumOfBeds = 1 },
            new Room { RoomNo = "201", NumOfBeds = 2 },
            new Room { RoomNo = "202", NumOfBeds = 2 });

        db.SaveChanges();
    }
}

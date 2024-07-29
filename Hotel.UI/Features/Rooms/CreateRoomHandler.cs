using Hotel.FakeData.Entities;

namespace Hotel.UI.Features.Rooms;

public record CreateRoomRequest(RoomModel Model) : IRequest<bool>;

public class CreateRoomHandler : IRequestHandler<CreateRoomRequest, bool>
{
    private readonly AppDbContext _db;

    public CreateRoomHandler(AppDbContext db)
    {
        _db = db;
    }

    public async Task<bool> Handle(CreateRoomRequest request, CancellationToken cancellationToken)
    {
        var newRoom = new Room
        {
            RoomNo = request.Model.RoomNo,
            NumOfBeds = request.Model.NumOfBeds,
        };

        await _db.AddAsync(newRoom);
        await _db.SaveChangesAsync();

        return true;
    }
}

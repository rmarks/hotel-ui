
using Microsoft.EntityFrameworkCore;

namespace Hotel.UI.Features.Rooms;

public record GetRoomRequest(int Id) : IRequest<RoomModel?>;

public class GetRoomHandler : IRequestHandler<GetRoomRequest, RoomModel?>
{
    private readonly AppDbContext _db;

    public GetRoomHandler(AppDbContext db)
    {
        _db = db;
    }

    public async Task<RoomModel?> Handle(GetRoomRequest request, CancellationToken cancellationToken)
    {
        var room = await _db.Rooms.AsNoTracking().FirstOrDefaultAsync(r => r.Id == request.Id);

        if (room is null) return null;

        var model = new RoomModel
        {
            Id = room.Id,
            RoomNo = room.RoomNo,
            NumOfBeds = room.NumOfBeds,
        };

        return model;
    }
}

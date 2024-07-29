using Microsoft.EntityFrameworkCore;

namespace Hotel.UI.Features.Rooms;

public record GetRoomsRequest() : IRequest<IEnumerable<RoomListModel>>;

public class GetRoomsHandler : IRequestHandler<GetRoomsRequest, IEnumerable<RoomListModel>>
{
    private readonly AppDbContext _db;

    public GetRoomsHandler(AppDbContext db)
    {
        _db = db;
    }

    public async Task<IEnumerable<RoomListModel>> Handle(GetRoomsRequest request, CancellationToken cancellationToken)
    {
        return await _db.Rooms
            .AsNoTracking()
            .Select(r => new RoomListModel(r.Id, r.RoomNo, r.NumOfBeds))
            .ToListAsync();
    }
}

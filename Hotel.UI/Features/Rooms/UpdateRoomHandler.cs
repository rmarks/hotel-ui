namespace Hotel.UI.Features.Rooms;

public record UpdateRoomRequest(RoomModel Model) : IRequest<bool>;

public class UpdateRoomHandler : IRequestHandler<UpdateRoomRequest, bool>
{
    private readonly AppDbContext _db;

    public UpdateRoomHandler(AppDbContext db)
    {
        _db = db;
    }

    public async Task<bool> Handle(UpdateRoomRequest request, CancellationToken cancellationToken)
    {
        var room = await _db.Rooms.FindAsync(request.Model.Id);

        if (room is null) return false;

        _db.Entry(room).CurrentValues.SetValues(request.Model);
        await _db.SaveChangesAsync();

        return true;
    }
}

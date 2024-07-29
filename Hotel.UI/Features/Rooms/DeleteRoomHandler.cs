namespace Hotel.UI.Features.Rooms;

public record DeleteRoomRequest(int Id) : IRequest<bool>;

public class DeleteRoomHandler : IRequestHandler<DeleteRoomRequest, bool>
{
    private readonly AppDbContext _db;

    public DeleteRoomHandler(AppDbContext db)
    {
        _db = db;
    }

    public async Task<bool> Handle(DeleteRoomRequest request, CancellationToken cancellationToken)
    {
        var room = await _db.Rooms.FindAsync(request.Id);

        if (room is null) return false;

        _db.Remove(room);
        await _db.SaveChangesAsync();

        return true;
    }
}

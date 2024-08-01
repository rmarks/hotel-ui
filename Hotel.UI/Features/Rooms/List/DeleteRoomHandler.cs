namespace Hotel.UI.Features.Rooms.List;

public record DeleteRoomRequest(int Id) : IRequest<bool>;

public class DeleteRoomHandler : IRequestHandler<DeleteRoomRequest, bool>
{
    private readonly HttpClient _httpClient;

    public DeleteRoomHandler(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<bool> Handle(DeleteRoomRequest request, CancellationToken cancellationToken)
    {
        var httpResponse = await _httpClient.DeleteAsync($"/api/rooms/{request.Id}");

        httpResponse.EnsureSuccessStatusCode();

        return httpResponse.IsSuccessStatusCode;
    }
}

using System.Net.Http.Json;

namespace Hotel.UI.Features.Rooms.List;

public record GetRoomsRequest() : IRequest<IEnumerable<RoomListModel>?>;

public class GetRoomsHandler : IRequestHandler<GetRoomsRequest, IEnumerable<RoomListModel>?>
{
    private readonly HttpClient _httpClient;

    public GetRoomsHandler(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<IEnumerable<RoomListModel>?> Handle(GetRoomsRequest request, CancellationToken cancellationToken)
    {
        return await _httpClient.GetFromJsonAsync<IEnumerable<RoomListModel>>("api/rooms")
            ?? throw new Exception("Successful response has an empty response body");
    }
}

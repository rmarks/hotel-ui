using System.Net.Http.Json;

namespace Hotel.UI.Features.Rooms.Form;

public record GetRoomRequest(int Id) : IRequest<RoomModel>;

public class GetRoomHandler : IRequestHandler<GetRoomRequest, RoomModel>
{
    private readonly HttpClient _httpClient;

    public GetRoomHandler(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<RoomModel> Handle(GetRoomRequest request, CancellationToken cancellationToken)
    {
        return await _httpClient.GetFromJsonAsync<RoomModel>($"/api/rooms/{request.Id}")
            ?? throw new Exception("Successful response has an empty response body");
    }
}

using System.Net.Http.Json;

namespace Hotel.UI.Features.Rooms.Form;

public record CreateRoomRequest(RoomModel Model) : IRequest<bool>;

public class CreateRoomHandler : IRequestHandler<CreateRoomRequest, bool>
{
    private readonly HttpClient _httpClient;

    public CreateRoomHandler(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<bool> Handle(CreateRoomRequest request, CancellationToken cancellationToken)
    {
        var httpResponse = await _httpClient.PostAsJsonAsync("/api/rooms", request.Model);

        httpResponse.EnsureSuccessStatusCode();

        return httpResponse.IsSuccessStatusCode;
    }
}

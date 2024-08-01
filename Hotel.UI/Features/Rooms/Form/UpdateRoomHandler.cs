using System.Net.Http.Json;

namespace Hotel.UI.Features.Rooms.Form;

public record UpdateRoomRequest(RoomModel Model) : IRequest<bool>;

public class UpdateRoomHandler : IRequestHandler<UpdateRoomRequest, bool>
{
    private readonly HttpClient _httpClient;

    public UpdateRoomHandler(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<bool> Handle(UpdateRoomRequest request, CancellationToken cancellationToken)
    {
        var httpResponse = await _httpClient.PutAsJsonAsync($"/api/rooms/{request.Model.Id}", request.Model);

        httpResponse.EnsureSuccessStatusCode();

        return httpResponse.IsSuccessStatusCode;
    }
}
